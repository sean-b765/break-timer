using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BreakTimer
{
    public partial class TopMostWindow : Form
    {
        public TopMostWindow()
        {
            InitializeComponent();
            this.TopMost = true;

            LblCaption.Text = "Alert!";
            LblCaption.ForeColor = Color.Black;
        }

        public void SetCaption(string text)
        {
            LblCaption.Text = text;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TopMostWindow_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width - 50, Screen.PrimaryScreen.Bounds.Height - Height - 100);
        }

        int c = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            c++;

            if (c % 2 == 0)
            {
                LblCaption.ForeColor = Color.Red;
            } else
            {
                LblCaption.ForeColor = Color.Black;
            }
        }
    }
}
