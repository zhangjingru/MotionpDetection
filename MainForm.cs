using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using videosource;

namespace motion
{
	/// <summary>
	/// Summary description for MainForm
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		// statistics
		private const int	statLength = 15;
		private int			statIndex = 0, statReady = 0;
		private int[]		statCount = new int[statLength];

		private IMotionDetector detector = new MotionDetector3Optimized();
		private int			detectorType = 4;

		private System.Windows.Forms.MenuItem fileItem;
		private System.Windows.Forms.MenuItem openFileItem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem exitFileItem;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Timers.Timer timer;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel fpsPanel;
		private System.Windows.Forms.Panel panel;
		private motion.CameraWindow cameraWindow;
		private System.Windows.Forms.MenuItem motionItem;
		private System.Windows.Forms.MenuItem noneMotionItem;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem detector1MotionItem;
		private System.Windows.Forms.MenuItem detector2MotionItem;
		private System.Windows.Forms.MenuItem detector3MotionItem;
		private System.Windows.Forms.MenuItem detector3OptimizedMotionItem;
		private System.Windows.Forms.MenuItem openURLFileItem;
		private System.Windows.Forms.MenuItem openMMSFileItem;
		private System.Windows.Forms.MenuItem openLocalFileItem;
		private System.Windows.Forms.MenuItem openMJEPGFileItem;
		private IContainer components;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileItem = new System.Windows.Forms.MenuItem();
            this.openFileItem = new System.Windows.Forms.MenuItem();
            this.openURLFileItem = new System.Windows.Forms.MenuItem();
            this.openMJEPGFileItem = new System.Windows.Forms.MenuItem();
            this.openMMSFileItem = new System.Windows.Forms.MenuItem();
            this.openLocalFileItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.exitFileItem = new System.Windows.Forms.MenuItem();
            this.motionItem = new System.Windows.Forms.MenuItem();
            this.noneMotionItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.detector1MotionItem = new System.Windows.Forms.MenuItem();
            this.detector2MotionItem = new System.Windows.Forms.MenuItem();
            this.detector3MotionItem = new System.Windows.Forms.MenuItem();
            this.detector3OptimizedMotionItem = new System.Windows.Forms.MenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.timer = new System.Timers.Timer();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.fpsPanel = new System.Windows.Forms.StatusBarPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.cameraWindow = new motion.CameraWindow();
            ((System.ComponentModel.ISupportInitialize)(this.timer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPanel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileItem,
            this.motionItem});
            // 
            // fileItem
            // 
            this.fileItem.Index = 0;
            this.fileItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.openFileItem,
            this.openURLFileItem,
            this.openMJEPGFileItem,
            this.openMMSFileItem,
            this.openLocalFileItem,
            this.menuItem1,
            this.exitFileItem});
            this.fileItem.Text = "&File";
            // 
            // openFileItem
            // 
            this.openFileItem.Index = 0;
            this.openFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.openFileItem.Text = "&Open";
            this.openFileItem.Click += new System.EventHandler(this.openFileItem_Click);
            // 
            // openURLFileItem
            // 
            this.openURLFileItem.Index = 1;
            this.openURLFileItem.Text = "Open JPEG &URL";
            this.openURLFileItem.Click += new System.EventHandler(this.openURLFileItem_Click);
            // 
            // openMJEPGFileItem
            // 
            this.openMJEPGFileItem.Index = 2;
            this.openMJEPGFileItem.Text = "Open M&JPEG URL";
            this.openMJEPGFileItem.Click += new System.EventHandler(this.openMJEPGFileItem_Click);
            // 
            // openMMSFileItem
            // 
            this.openMMSFileItem.Index = 3;
            this.openMMSFileItem.Text = "Open &MMS Stream";
            this.openMMSFileItem.Click += new System.EventHandler(this.openMMSFileItem_Click);
            // 
            // openLocalFileItem
            // 
            this.openLocalFileItem.Index = 4;
            this.openLocalFileItem.Text = "Open &Local Device";
            this.openLocalFileItem.Click += new System.EventHandler(this.openLocalFileItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 5;
            this.menuItem1.Text = "-";
            // 
            // exitFileItem
            // 
            this.exitFileItem.Index = 6;
            this.exitFileItem.Text = "E&xit";
            this.exitFileItem.Click += new System.EventHandler(this.exitFileItem_Click);
            // 
            // motionItem
            // 
            this.motionItem.Index = 1;
            this.motionItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.noneMotionItem,
            this.menuItem2,
            this.detector1MotionItem,
            this.detector2MotionItem,
            this.detector3MotionItem,
            this.detector3OptimizedMotionItem});
            this.motionItem.Text = "&Motion";
            this.motionItem.Popup += new System.EventHandler(this.motionItem_Popup);
            // 
            // noneMotionItem
            // 
            this.noneMotionItem.Index = 0;
            this.noneMotionItem.Text = "&None";
            this.noneMotionItem.Click += new System.EventHandler(this.noneMotionItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // detector1MotionItem
            // 
            this.detector1MotionItem.Index = 2;
            this.detector1MotionItem.Text = "Detector &1";
            this.detector1MotionItem.Click += new System.EventHandler(this.detector1MotionItem_Click);
            // 
            // detector2MotionItem
            // 
            this.detector2MotionItem.Index = 3;
            this.detector2MotionItem.Text = "Detector &2";
            this.detector2MotionItem.Click += new System.EventHandler(this.detector2MotionItem_Click);
            // 
            // detector3MotionItem
            // 
            this.detector3MotionItem.Index = 4;
            this.detector3MotionItem.Text = "Detector &3";
            this.detector3MotionItem.Click += new System.EventHandler(this.detector3MotionItem_Click);
            // 
            // detector3OptimizedMotionItem
            // 
            this.detector3OptimizedMotionItem.Index = 5;
            this.detector3OptimizedMotionItem.Text = "Detector 3 - Optimized";
            this.detector3OptimizedMotionItem.Click += new System.EventHandler(this.detector3OptimizedMotionItem_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "AVI files (*.avi)|*.avi";
            this.ofd.Title = "Open movie";
            // 
            // timer
            // 
            this.timer.Interval = 1000D;
            this.timer.SynchronizingObject = this;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 321);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.fpsPanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(408, 24);
            this.statusBar.TabIndex = 1;
            // 
            // fpsPanel
            // 
            this.fpsPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.fpsPanel.Name = "fpsPanel";
            this.fpsPanel.Width = 391;
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.cameraWindow);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(408, 321);
            this.panel.TabIndex = 2;
            // 
            // cameraWindow
            // 
            this.cameraWindow.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cameraWindow.Camera = null;
            this.cameraWindow.Location = new System.Drawing.Point(41, 37);
            this.cameraWindow.Name = "cameraWindow";
            this.cameraWindow.Size = new System.Drawing.Size(322, 242);
            this.cameraWindow.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(408, 345);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Motion detector";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.timer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPanel)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		// On form closing
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			CloseFile();		
		}

		// Close the main form
		private void exitFileItem_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		// Open file
		private void openFileItem_Click(object sender, System.EventArgs e)
		{
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				// create video source
				VideoFileSource fileSource = new VideoFileSource();
				fileSource.VideoSource = ofd.FileName;

				// open it
				OpenVideoSource(fileSource);
			}		
		}

		// Open URL
		private void openURLFileItem_Click(object sender, System.EventArgs e)
		{
			URLForm	form = new URLForm();

			form.Description = "Enter URL of an updating JPEG from a web camera:";
			form.URLs = new string[]
				{
					"http://aleksandriacamk1.it.helsinki.fi/axis-cgi/jpg/image.cgi?resolution=320x240",
					"http://stareat.it.helsinki.fi/axis-cgi/jpg/image.cgi?resolution=320x240",
					"http://194.18.89.220/axis-cgi/jpg/image.cgi?resolution=320x240",
					"http://212.247.228.34/axis-cgi/jpg/image.cgi?resolution=352x240"
				};

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				// create video source
				JPEGSource jpegSource = new JPEGSource();
				jpegSource.VideoSource = form.URL;

				// open it
				OpenVideoSource(jpegSource);
			}
		}

		// Open MJPEG URL
		private void openMJEPGFileItem_Click(object sender, System.EventArgs e)
		{
			URLForm	form = new URLForm();

			form.Description = "Enter URL of an MJPEG video stream:";
			form.URLs = new string[]
				{
					"http://sun.jerseyinsight.com/trafficbeaumont/nph-update.cgi",
					"http://peeper.axisinc.com/nph-manupdate.cgi",
					"http://marc15ter.vac.hu/nphMotionJpeg?Resolution=320x240&Quality=Standard",
					"http://213.200.232.69:8080/axis-cgi/mjpg/video.cgi?resolution=320x240"
				};

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				// create video source
				MJPEGSource mjpegSource = new MJPEGSource();
				mjpegSource.VideoSource = form.URL;

				// open it
				OpenVideoSource(mjpegSource);
			}
		}

		// Open MMS
		private void openMMSFileItem_Click(object sender, System.EventArgs e)
		{
			MMSForm	form = new MMSForm();

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				// create video source
				VideoStream mmsSource = new VideoStream();
				mmsSource.VideoSource = form.URL;

				// open it
				OpenVideoSource(mmsSource);
			}
		}

		// Open local capture device
		private void openLocalFileItem_Click(object sender, System.EventArgs e)
		{
			CaptureDeviceForm form = new CaptureDeviceForm();

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				// create video source
				CaptureDevice localSource = new CaptureDevice();
				localSource.VideoSource = form.Device;

				// open it
				OpenVideoSource(localSource);
			}
		}

		// Open video source
		private void OpenVideoSource(IVideoSource source)
		{
			// set busy cursor
			this.Cursor = Cursors.WaitCursor;

			// close previous file
			CloseFile();

			// create camera
			Camera camera = new Camera(source, detector);
			// start camera
			camera.Start();

			// attach camera to camera window
			cameraWindow.Camera = camera;

			// reset statistics
			statIndex = statReady = 0;

			// start timer
			timer.Start();

			this.Cursor = Cursors.Default;
		}

		// Close current file
		private void CloseFile()
		{
			Camera	camera = cameraWindow.Camera;

			if (camera != null)
			{
				// detach camera from camera window
				cameraWindow.Camera = null;

				// signal camera to stop
				camera.SignalToStop();
				// wait for the camera
				camera.WaitForStop();

				camera = null;

				if (detector != null)
					detector.Reset();
			}
		}

		// On timer event - gather statistic
		private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Camera	camera = cameraWindow.Camera;
		
			if (camera != null)
			{
				// get number of frames for the last second
				statCount[statIndex] = camera.FramesReceived;

				// increment indexes
				if (++statIndex >= statLength)
					statIndex = 0;
				if (statReady < statLength)
					statReady++;

				float	fps = 0;

				// calculate average value
				for (int i = 0; i < statReady; i++)
				{
					fps += statCount[i];
				}
				fps /= statReady;

				statCount[statIndex] = 0;

				fpsPanel.Text = fps.ToString("F2") + " fps";
			}
		}

		// Remove any motion detectors
		private void noneMotionItem_Click(object sender, System.EventArgs e)
		{
			detector = null;
			detectorType = 0;
			SetMotionDetector();
		}

		// Select detector 1
		private void detector1MotionItem_Click(object sender, System.EventArgs e)
		{
			detector = new MotionDetector1();
			detectorType = 1;
			SetMotionDetector();
		}

		// Select detector 2
		private void detector2MotionItem_Click(object sender, System.EventArgs e)
		{
			detector = new MotionDetector2();
			detectorType = 2;
			SetMotionDetector();
		}

		// Select detector 3
		private void detector3MotionItem_Click(object sender, System.EventArgs e)
		{
			detector = new MotionDetector3();
			detectorType = 3;
			SetMotionDetector();
		}

		// Select detector 3 - optimized
		private void detector3OptimizedMotionItem_Click(object sender, System.EventArgs e)
		{
			detector = new MotionDetector3Optimized();
			detectorType = 4;
			SetMotionDetector();
		}

		// Update motion detector
		private void SetMotionDetector()
		{
			Camera	camera = cameraWindow.Camera;
		
			if (camera != null)
			{
				camera.Lock();
				camera.MotionDetector = detector;

				// reset statistics
				statIndex = statReady = 0;
				camera.Unlock();
			}
		}

		// On "Motion" menu item popup
		private void motionItem_Popup(object sender, System.EventArgs e)
		{
			MenuItem[]	items = new MenuItem[]
			{
				noneMotionItem, detector1MotionItem,
				detector2MotionItem, detector3MotionItem, detector3OptimizedMotionItem
			};

			for (int i = 0; i < items.Length; i++)
			{
				items[i].Checked = (i == detectorType);
			}
		}
	}
}
