using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMini.DataStore;
using GoogleMini.FolderManagement;
using GoogleMini.TextProcessing;
using GoogleMini.Util;

namespace GoogleMini.UI
{
    public partial class SplashForm : Form
    {
        private const int MaxWaveSpeed = 2, MinSplashTime = 5000, MaxMessageStep = 10;
        private const double _A = 40, _B = 500, _C = 40, _X = 75, _Y = 25, _Z = -70;
        private readonly Color fillColor = Color.White;
        private readonly Color strokeColor = Color.Orange;
        private readonly string[] messages = new[]
        {
            "initializing the text file processor",
            "loading the wordToIdMap.b+tree file",
            "loading the idToWordMap.b+tree file",
            "loading the fileCompoundIdToWordCompoundIdsMap.b+tree file",
            "loading the wordCompoundIdToOccurrenceMap.b+tree file",
            "initializing the folder manager",
            "loading the filePathToIdMap.b+tree file",
            "loading the idToFilePathMap.b+tree file",
            "loading the watchedFolders.b+tree file",
            "initializing the identity store",
            "loading the indexDbIdentities.b+tree file",
            "attaching the text file processor to the folder manager events",
            "listening for file changes",
            "starting..."
        };

        private IncrementalIdentityStore identityStore;
        private TextFileProcessor textFileProcessor;
        private FolderManager folderManager;

        private Task initTask;
        private Timer animationTimer;
        private System.Threading.Timer messageTimer;

        private GraphicsPath path;
        private LinearGradientBrush brush;

        private bool requestNextFrame;
        private int a, messageIndex, messageStep, frameNumber, speed, speedDelta;

        public SplashForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            animationTimer?.Dispose();
            brush?.Dispose();
            path?.Dispose();
            animationTimer = null;
            brush = null;
            path = null;

            base.Dispose(disposing);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            requestNextFrame = true;
            Refresh();
            requestNextFrame = false;
        }

        private void MinimizeLabel_Click(object sender, EventArgs e)
        {
            minimizeLabel.ForeColor = Color.FromArgb(165, 165, 165);
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = true;
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CancelLabel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LabelMouseDown(object sender, MouseEventArgs e)
        {
            var label = (Label)sender;
            label.ForeColor = label == cancelLabel ? Color.Black : Color.Gold;
        }

        private void LabelMouseEnter(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.ForeColor = label == cancelLabel ? Color.DimGray : Color.Red;
        }

        private void LabelMouseLeave(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.ForeColor = label == cancelLabel ? Color.Gray : Color.FromArgb(165, 165, 165);
        }

        private void LabelMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var label = (Label)sender;
            if (e.Location.X > label.Width || e.Location.X < 0 || e.Location.Y > label.Height || e.Location.Y < 0)
            {
                label.ForeColor = label == cancelLabel ? Color.Gray : Color.FromArgb(165, 165, 165);
            }
            else
            {
                label.ForeColor = label == cancelLabel ? Color.Black : Color.Gold;
            }
        }

        private async void SplashForm_Load(object sender, EventArgs e)
        {
            a = 0;
            frameNumber = 0;
            speed = MaxWaveSpeed;
            speedDelta = -1;
            messageIndex = 0;
            messageStep = 0;
            requestNextFrame = true;

            animationTimer = new Timer();
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Interval = 100;
            animationTimer.Start();

            messageTimer = new System.Threading.Timer(_ =>
            {
                messageStep++;
                if (messageStep == MaxMessageStep + 1)
                {
                    messageStep = 0;
                    messageIndex++;
                    if (messageIndex == messages.Length)   // disable the timer
                    {
                        messageIndex--;
                        messageTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                    }
                }
            }, null, 0, MinSplashTime / (messages.Length * MaxMessageStep));

            try
            {
                initTask = Task.Run(() =>
                {
                    var dataDirectory = Path.Combine(Environment.CurrentDirectory, "datastore");
                    identityStore = new IncrementalIdentityStore(dataDirectory);
                    folderManager = new FolderManager(dataDirectory, identityStore);
                    textFileProcessor = new TextFileProcessor(dataDirectory, identityStore);

                    folderManager.TextFileCreated = (arg) => textFileProcessor.TextFileCreated(arg.FileId, arg.FilePath, arg.OnCompleted);
                    folderManager.TextFileChanged = (arg) => textFileProcessor.TextFileChanged(arg.FileId, arg.FilePath, arg.OnCompleted);
                    folderManager.TextFileRemoved = (arg) => textFileProcessor.TextFilesRemoved(new[] { arg.FileId }, arg.OnCompleted);
                    folderManager.MultipleTextFilesDeleted = (arg) => textFileProcessor.TextFilesRemoved(arg.FileIds, arg.OnCompleted);

                    textFileProcessor.StartRequestProcessingLoop();
                    folderManager.StartWatching();
                });
                await Task.WhenAll(Task.Delay(MinSplashTime), initTask);
                var shellForm = new ShellForm(textFileProcessor, folderManager, identityStore);
                StartShellForm(shellForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            finally
            {
                messageTimer?.Dispose();
                animationTimer?.Dispose();
                path?.Dispose();
                brush?.Dispose();
            }
        }

        private void SplashForm_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0xA1, HTCAPTION = 0x2;
            if (e.Button == MouseButtons.Left)
            {
                Capture = false;
                var msg = Message.Create(Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);
                DefWndProc(ref msg);
            }
        }

        private void SplashForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(165, 165, 165)), new Rectangle(0, 0, Width - 1, Height - 1));
            waveCanvas.Refresh();
        }

        private void WaveCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (requestNextFrame)
            {
                path?.Dispose();
                path = Drawcurve();

                brush?.Dispose();
                brush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), strokeColor, fillColor, a);
            }

            if (path == null || brush == null)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.Clear(Color.White);
            e.Graphics.FillPath(brush, path);
            e.Graphics.DrawPath(new Pen(strokeColor, 3), path);

            using (var tx = new GraphicsPath())
            {
                tx.AddString("Google", new FontFamily("Times New Roman"), (int)FontStyle.Regular, 36, new Point(4, 100), StringFormat.GenericDefault);
                tx.AddString("Mini", new FontFamily("Times New Roman"), (int)FontStyle.Regular, 36, new Point(4, 140), StringFormat.GenericDefault);
                e.Graphics.FillPath(new SolidBrush(Color.Black), tx);
            }

            using (var tx = new GraphicsPath())
            {
                var deltaY = -messageStep/2;
                var alpha = (int)Math.Min(255, messageStep * 18.5);
                var index = messageIndex;
                if (index == messages.Length - 1 && !(initTask?.IsCompleted ?? false))
                {
                    index--;
                }
                tx.AddString(
                    messages[messageIndex],
                    new FontFamily("Segoe UI"),
                    (int)FontStyle.Regular, 12,
                    new Point(4, 245 + deltaY),
                    StringFormat.GenericDefault
                );
                e.Graphics.FillPath(new SolidBrush(Color.FromArgb(alpha,0,0,0)), tx);
            }
        }

        private GraphicsPath Drawcurve()
        {
            a += speed;
            a %= 360;
            frameNumber++;

            if (frameNumber == 14)
            {
                speed += speedDelta;
                if (speed < 1 || speed > MaxWaveSpeed)
                {
                    speed -= 2 * speedDelta;
                    speedDelta *= -1;
                }
                frameNumber = 0;
            }

            double centerX = Width / 2, centerY = Height / 2, startX = 0.0, startY = 0.0, endX = 0.0, endY = 0.0;
            var path = new GraphicsPath();
            var d = a * Math.PI / 180.0;

            for (var i = 0; i <= 360; i++)
            {
                var c = i * Math.PI / 180.0;

                if (a < 147)
                {
                    endX = centerX + _A * Math.Sin(2 * c + d) + _B * Math.Sin(c + 2 * d) + _C * Math.Sin(c + d);
                    endY = centerY + _X * Math.Sin(0.5 * d + c) + _Y * Math.Sin(0.5 * d + 2 * c) + _Z * Math.Sin(c + d);
                }
                else
                {
                    endX = centerX + _A * Math.Cos(2 * c + d) + _B * Math.Cos(c + 2 * d) + _C * Math.Cos(c + d);
                    endY = centerY + _X * Math.Cos(0.5 * d + c) + _Y * Math.Cos(0.5 * d + 2 * c) + _Z * Math.Cos(c + d);
                }

                if (i > 0)
                    path.AddLine((float)startX, (float)startY, (float)endX, (float)endY);

                startX = endX;
                startY = endY;
            }
            return path;
        }

        private void StartShellForm(ShellForm shellForm)
        {
            if (shellForm == null)
                return;

            shellForm.WindowState = WindowState;
            var t = new System.Threading.Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(shellForm);
            });
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            Close();
        }
    }
}
