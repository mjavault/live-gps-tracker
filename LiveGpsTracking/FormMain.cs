using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveGpsTracking
{
    public partial class FormMain : Form
    {
        private static bool TESTING = false;
        private static String LOG_FILE = "C:\\temp\\nmea-";

        private SerialPortThread thread;
        private SerialPortThread threadAux;
        private NmeaParser nema = new NmeaParser();
        private NmeaParser nemaAux = new NmeaParser();
        private GMapOverlay markersOverlay;
        private GMapOverlay polygonsOverlay;
        private GMapOverlay markersOverlayAux;
        private GMapRoute liveRoute;
        private StreamWriter writer = null;
        private ConcurrentQueue<Position> apiQueue = new ConcurrentQueue<Position>();
        private bool running = true;
        private Thread queueThread;
        private bool sendToApi = true;
        private DateTime lastValidNmeaDate;

        public FormMain()
        {
            InitializeComponent();
            serialPort.PortName = txtComPort.Text;
            serialPort.BaudRate = Convert.ToInt16(txtBaudrate.Text);
            
            queueThread = new Thread(new ThreadStart(processQueue));
            queueThread.Start();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //open logger
                writer = new StreamWriter(File.Open(LOG_FILE + DateTime.Now.ToUnixTime() + ".log", FileMode.Append, FileAccess.Write, FileShare.ReadWrite));
                writer.WriteLine("----- START " + DateTime.Now.ToString());
                //open serial port
                serialPort.PortName = txtComPort.Text;
                serialPort.BaudRate = Convert.ToInt16(txtBaudrate.Text);
                serialPort.Open();
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                thread = new SerialPortThread(serialPort);
                thread.Start();
                thread.LineReceived += thread_LineReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
        }

        void thread_LineReceived(string line)
        {
            //process line
            Invoke(new Action(() => txtConsole.AppendText(line + "\n")));
            nema.Update(line);
            Invoke(new Action(() => txtStatus.Text = nema.ToString()));
            lastValidNmeaDate = DateTime.Now;
            if (line.StartsWith("$GPGGA") && nema.HasFix())
            {
                Invoke(new Action(() => addValuesToGraph(new double[] { nema.Fix.AltitudeFt, nema.VerticalSpeedFpm })));
                addNewPositionOnMap(new Position(nema.Fix.Latitude, nema.Fix.Longitude, nema.Fix.Altitude, nema.Fix.Hdop));
            }

            //save line to file
            if (writer != null)
            {
                try
                {
                    writer.WriteLine(line);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void addNewPositionOnMap(Position position)
        {
            //adding map marker                
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(position.Latitude, position.Longitude), GMarkerGoogleType.green);
            markersOverlay.Markers.Clear();
            markersOverlay.Markers.Add(marker);
            //add polygon            
            liveRoute.Points.Add(new PointLatLng(position.Latitude, position.Longitude));
            //post the position to the external API            
            if (sendToApi && isInteresting(position))
            {
                lastInterestingPosition = position;
                queueForApi(position);
            }
        }

        private Position lastInterestingPosition = null;
        private bool isInteresting(Position position)
        {
            if (lastInterestingPosition == null)
            {
                return true;
            }
            else
            {
                //we are waiting for a new, good enough, location
                if (lastInterestingPosition.Accuracy - position.Accuracy >= 0.5)
                {
                    //new fix is 0.5 unit more precise than the last one
                    return true;
                }
                else if (position.Accuracy <= 5)
                {
                    //only force update if new fix has an acceptable dop
                    if (position.distanceTo(lastInterestingPosition) > 10.0)
                    {
                        //force update after moving more than 10 meters
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //init map provider
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gmap.SetPositionByKeywords("USA");
            gmap.MinZoom = 3;
            gmap.MaxZoom = 17;
            gmap.Zoom = 12;
            gmap.Position = new PointLatLng(37.580491, -122.300120);
            //create marker layer
            markersOverlay = new GMapOverlay("markers");
            gmap.Overlays.Add(markersOverlay);
            //create marker layer
            markersOverlayAux = new GMapOverlay("markers-aux");
            gmap.Overlays.Add(markersOverlayAux);
            //create polygon layer
            polygonsOverlay = new GMapOverlay("polygons");
            gmap.Overlays.Add(polygonsOverlay);
            //create empty polygon, ready to add new points
            List<PointLatLng> points = new List<PointLatLng>();
            liveRoute = new GMapRoute(points, "liveroute");
            liveRoute.Stroke = new Pen(Color.Green, 2);
            polygonsOverlay.Routes.Add(liveRoute);

            //if flightpath is available, load it
            String flightPathFile = "C:\\temp\\flight_path.csv";
            if (File.Exists(flightPathFile))
            {
                loadFlightPath(flightPathFile);
            }

            //if replay file is available, load it
            String replayFile = "C:\\temp\\replay.txt";
            if (File.Exists(replayFile))
            {
                replay(replayFile);
            }

            //testing fixtures            
            if (TESTING)
            {
                thread_LineReceived("$GPRMC,002454,A,3553.5295,N,13938.6570,E,0.0,43.1,180700,7.1,W,A*3F");
                thread_LineReceived("$GPGGA,183730,3907.356,N,12102.482,W,1,05,1.6,646.4,M,-24.1,M,,*75");
                thread_LineReceived("$GPGGA,002454,3553.5295,N,13938.6570,E,1,05,2.2,18.3,M,39.0,M,,*7F");
                thread_LineReceived("$GPGGA,002554,3553.5295,N,13938.6570,E,1,05,2.2,118.3,M,39.0,M,,*7F");
                thread_LineReceived("$GPGSV,3,1,09,01,38,103,37,02,23,215,00,04,38,297,37,05,00,328,00*70");
                thread_LineReceived("$GPGSV,3,2,09,07,77,299,47,11,07,087,00,16,74,041,47,20,38,044,43*73");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            stop();
            stopAux();
            if (queueThread != null)
            {
                try
                {
                    queueThread.Interrupt();
                }
                catch (Exception) { }
            }
        }

        private void stop()
        {
            if (writer != null)
            {
                writer.WriteLine("----- STOP " + DateTime.Now.ToString());
                writer.Close();
                writer = null;
            }
            if (thread != null)
            {
                thread.Stop();
                thread = null;
            }
            serialPort.Close();
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;

        }

        private void addValuesToGraph(double[] values)
        {
            for (int i = 0; i < 2; i++)
            {
                chartAltitude.Series[i].Points.Add(values[i]);
                if (chartAltitude.Series[i].Points.Count > chartAltitude.ChartAreas[i].AxisX.Maximum)
                    chartAltitude.Series[i].Points.RemoveAt(0);
            }
            chartAltitude.ChartAreas[0].RecalculateAxesScale();
        }

        private void replay(String filename)
        {
            sendToApi = false;
            StreamReader reader = new StreamReader(File.OpenRead(filename));
            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                if (line.StartsWith("$"))
                {
                    thread_LineReceived(line);
                }
            }
            reader.Close();
            sendToApi = true;
        }

        private void loadFlightPath(String filename)
        {
            StreamReader reader = new StreamReader(File.OpenRead(filename));

            //create polygon layer
            GMapOverlay overlay = new GMapOverlay("polygons");
            gmap.Overlays.Add(overlay);
            //create empty polygon, ready to add new points
            List<PointLatLng> points = new List<PointLatLng>();
            GMapRoute route = new GMapRoute(points, "flightpath");
            route.Stroke = new Pen(Color.Black, 3);
            overlay.Routes.Add(route);

            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                String[] items = line.Split(',');
                if (items.Length == 4) {
                    route.Points.Add(new PointLatLng(Convert.ToDouble(items[1]), Convert.ToDouble(items[2])));
                }               
            }
            reader.Close();
        }

        private void queueForApi(Position position)
        {
            apiQueue.Enqueue(position);        
        }

        private void processQueue()
        {
            while (running)
            {
                try
                {
                    Position result;
                    if (apiQueue.TryPeek(out result))
                    {                        
                        if (ExternalApi.PostLocation(result))
                        {
                            //effectively remove from the queue
                            apiQueue.TryDequeue(out result);
                        }
                    }
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void btnAuxConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //open serial port
                serialPortAux.PortName = txtAuxComPort.Text;
                serialPortAux.BaudRate = Convert.ToInt16(txtAuxBaudrate.Text);
                serialPortAux.Open();
                btnAuxConnect.Enabled = false;
                btnAuxDisconnect.Enabled = true;
                threadAux = new SerialPortThread(serialPortAux);
                threadAux.Start();
                threadAux.LineReceived += thread_LineReceivedAux;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAuxConnect.Enabled = true;
                btnAuxDisconnect.Enabled = false;
            }
        }

        private void btnAuxDisconnect_Click(object sender, EventArgs e)
        {
            stopAux();
        }

        void thread_LineReceivedAux(string line)
        {
            //process line
            nemaAux.Update(line);
            if (line.StartsWith("$GPGGA") && nemaAux.HasFix())
            {
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(nemaAux.Fix.Latitude, nemaAux.Fix.Longitude), GMarkerGoogleType.blue_dot);
                markersOverlayAux.Markers.Clear();
                markersOverlayAux.Markers.Add(marker);
                if (chkFollow.Checked)
                {
                    gmap.Position = new PointLatLng(nemaAux.Fix.Latitude, nemaAux.Fix.Longitude);
                }
            }
        }

        private void stopAux()
        {
            if (threadAux != null)
            {
                threadAux.Stop();
                threadAux = null;
            }
            serialPortAux.Close();
            btnAuxDisconnect.Enabled = false;
            btnAuxConnect.Enabled = true;
        }

        private void timerHeartbeat_Tick(object sender, EventArgs e)
        {
            if (lastValidNmeaDate != null)
            {
                if(DateTime.Now - lastValidNmeaDate > TimeSpan.FromSeconds(10)) {
                    txtConsole.BackColor = Color.LightCoral;
                }
                else
                {
                    txtConsole.BackColor = Color.White;
                }
            }
        }
    }
}
