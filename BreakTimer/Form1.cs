using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Resources;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakTimer
{
    public partial class Form1 : Form
    {
        enum AlertStyle
        {
            Popup = 0,
            Sound = 1
        }

        enum Duration
        {
            One = 1,
            Five = 5,
            Ten = 10,
            Quarter = 15,
            Twenty = 20,
            Half = 30,
            ThreeQuarters = 45,
        }

        NotifyIcon trayIcon;
        int Minutes = (int) Duration.Twenty;
        int Style = (int) AlertStyle.Popup;
        new bool Enabled = true;

        SoundPlayer player;
        string SelectedSound = null;

        TopMostWindow window = new TopMostWindow();

        Thread thread = null;

        private readonly string[] sounds = { 
            "alarm", 
            "Bell", 
            "cassette", 
            "games", 
            "smoke", 
            "tubular", 
            "war", 
            "zerino" 
        };

        void SaveOnClose()
        {
            PersistentData data = new PersistentData()
            {
                _Enabled = Enabled,
                _Minutes = Minutes,
                _Style = Style,
                _SelectedSound = SelectedSound,
                _TxtCaption = TxtCaption.Text
            };

            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write);

                formatter.Serialize(stream, data);
                stream.Close();
            } catch (Exception ex) {
            }
        }

        void LoadOnStartup()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                var stream = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
                var data = (PersistentData)formatter.Deserialize(stream);
                stream.Close();

                Enabled = data._Enabled;
                Style = data._Style;
                Minutes = data._Minutes;
                SelectedSound = data._SelectedSound;
                TxtCaption.Text = data._TxtCaption;

            }
            catch (Exception e) { }
        }

        public Form1()
        {
            InitializeComponent();

            // Initialize icon, system tray stuff
            var ts = new ContextMenuStrip();

            ts.Items.Add("Exit", null, exit);
            ts.Items.Add("Open", null, open);
            ts.Items.Add("Minimize", null, minimize);

            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.icon,
                ContextMenuStrip = ts,
                Visible = true
            };

            trayIcon.MouseClick += TrayIcon_MouseClick;

            this.Icon = Properties.Resources.icon;

            LoadOnStartup();

            // Initialize comboboxes
            CmbStyle.DataSource = Enum.GetValues(typeof(AlertStyle));
            CmbStyle.SelectedItem = (AlertStyle) Style;

            CmbSound.Visible = ((AlertStyle)Style == AlertStyle.Sound);
            LblSound.Visible = ((AlertStyle)Style == AlertStyle.Sound);

            CmbStyle.SelectedIndexChanged += CmbStyle_SelectedIndexChanged;

            CmbDuration.DataSource = Enum.GetValues(typeof(Duration));
            CmbDuration.SelectedItem = (Duration) Minutes;
            CmbDuration.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;

            CmbSound.DataSource = sounds;
            CmbSound.SelectedIndex = 0;
            for (int i = 0; i < sounds.Length; i++)
            {
                if (sounds[i] == SelectedSound) CmbSound.SelectedIndex = i;
            }
            CmbSound.SelectedIndexChanged += CmbSound_SelectedIndexChanged;

            ChbEnabled.CheckedChanged += ChbEnabled_EnabledChanged;
            ChbEnabled.Checked = Enabled;

            window.SetCaption(TxtCaption.Text);
        }

        private void ChbEnabled_EnabledChanged(object sender, EventArgs e)
        {
            Enabled = ChbEnabled.Checked;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Minutes = (int)CmbDuration.SelectedValue;
        }

        #region system tray
        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        void open(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        void exit (object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            trayIcon.Icon.Dispose();
            trayIcon.Dispose();


            Application.Exit();
        }

        void minimize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            } else
            {
                this.ShowInTaskbar = true;
            }
        }

        void AlertThread()
        {
            int secondsElapsed = 0;
            while (true && thread != null)
            {
                Thread.Sleep(1 * 1000);
                secondsElapsed++;

                double completion = (secondsElapsed / (Minutes * 60)) * 100;

                try
                {
                    this.Invoke(new MethodInvoker(() => {
                        LblTimer.Text = secondsElapsed.ToString() + "s / " + (Minutes * 60).ToString() + "s";
                    }));
                } catch (Exception e)
                {
                }

                if (secondsElapsed >= Minutes * 60)
                {
                    secondsElapsed = 0;

                    if ((AlertStyle) Style == AlertStyle.Popup)
                    {
                        // show popup
                        if (!Enabled) continue;

                        try
                        {
                            this.Invoke(new MethodInvoker(() => {
                                if (window.WindowState != FormWindowState.Minimized)
                                {
                                    window.Show();
                                }
                            }));
                        }
                        catch (Exception e)
                        {
                        }
                    }
                    else if ((AlertStyle) Style == AlertStyle.Sound)
                    {
                        // play sound
                        if (!Enabled) continue;
                        player = new SoundPlayer((Stream)Properties.Resources.ResourceManager.GetObject(SelectedSound));
                        try
                        {
                            player.Play();
                        }
                        catch (Exception xe)
                        {
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(AlertThread));
            thread.Start();
        }

        private void CmbSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSound = (string)CmbSound.SelectedItem;
            player = new SoundPlayer((Stream) Properties.Resources.ResourceManager.GetObject(SelectedSound) );
            try
            {
                player.Play();
            }
            catch (Exception xe)
            {
            }
        }

        private void CmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Style = (int) CmbStyle.SelectedItem;

            LblSound.Visible = (AlertStyle) Style == AlertStyle.Sound;
            CmbSound.Visible = (AlertStyle) Style == AlertStyle.Sound;
        }

        private void TxtCaption_TextChanged(object sender, EventArgs e)
        {
            window.SetCaption(TxtCaption.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveOnClose();
            thread = null;
        }
    }
}
