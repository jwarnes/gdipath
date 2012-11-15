using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace gdipath
{
    public partial class mainForm : Form
    {
        #region TimeStep Fields
        public int tick;
        
        Stopwatch stopWatch = Stopwatch.StartNew();
        readonly TimeSpan TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 60);
        readonly TimeSpan MaxElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 10);

        TimeSpan accumulatedTime;
        TimeSpan lastTime;

        Timer timer;
        #endregion

        GameStateManager manager;
        Graphics g;

        public mainForm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = (int)TargetElapsedTime.TotalMilliseconds;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            manager = new GameStateManager();
        }

        void redrawGraphics()
        {
            pic.Image = new Bitmap(panel1.Width, panel1.Height);
            g = Graphics.FromImage(pic.Image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        //fixed timestep loop
        void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan currentTime = stopWatch.Elapsed;
            TimeSpan elapsedTime = currentTime - lastTime;
            lastTime = currentTime;

            if (elapsedTime > MaxElapsedTime)
            {
                elapsedTime = MaxElapsedTime;
            }

            accumulatedTime += elapsedTime;

            bool updated = false;

            while (accumulatedTime >= TargetElapsedTime)
            {
                Process();

                accumulatedTime -= TargetElapsedTime;
                updated = true;
            }

            if (updated)
            {
                Draw();
            }
            
        }

        public void Process()
        {
            manager.Process();
        }

        public void Draw()
        {
            g.Clear(Color.CornflowerBlue);
            manager.Draw(g);
            pic.Refresh();
            
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            redrawGraphics();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            redrawGraphics();
        }
    }
}
