using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXON.Common
{
    public partial class NotificationBox : Form
    {
        public NotificationBox(string _message, AlertType type)
        {
            InitializeComponent();
            message.Text = _message;
            switch (type)
            {
                case AlertType.success:
                    this.BackColor = Color.SeaGreen;
                    icon.Image = imageList1.Images[0];
                    break;

                case AlertType.info:
                    this.BackColor = Color.Gray;
                    icon.Image = imageList1.Images[1];
                    break;

                case AlertType.warnig:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    icon.Image = imageList1.Images[1];
                    break;

                case AlertType.error:
                    this.BackColor = Color.Crimson;
                    icon.Image = imageList1.Images[2];
                    break;
            }
        }

        /// <summary>
        /// Alerts the specified message.
        /// </summary>
        /// <param name="_message">The message.</param>
        /// <param name="type">The type.</param>
        public static void Show(string message, AlertType type)
        {
            new EXON.Common.NotificationBox(message, type).Show();
        }

        private void alert_Load(object sender, EventArgs e)
        {
            //set position to top left...
            this.Top = -1 * (this.Height);
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 50;

            show.Start();
        }

        public enum AlertType
        {
            success, info, warnig, error
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            closealert.Start();
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            closealert.Start();
        }

        private int interval = 0;

        //show transition
        private void show_Tick(object sender, EventArgs e)
        {
            if (this.Top < 60)
            {
                this.Top += interval; // drop the alert
                interval += 2; // double the speed
            }
            else
            {
                show.Stop();
            }
        }

        private void close_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.2; //reduce opacity to zero
            }
            else
            {
                this.Close(); //then close
            }
        }
    }
}