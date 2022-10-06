using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Home : UserControl
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public Home()
        {
            InitializeComponent();
        }

        private void StartSession_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Session Started","Info");
            start();
        }
        private static void start()
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 1000;
            myTimer.Start();

            //Application.DoEvents();
            
        }
        private static void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            //get battery percentage value
            var battery = SystemInformation.PowerStatus.BatteryLifePercent;
            //get battery status
            var status = SystemInformation.PowerStatus.PowerLineStatus;
            myTimer.Stop();

            if (battery < 0.23 && status == PowerLineStatus.Offline)
            {
                //Play Asterisk  sound
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Battery is Low, please plug in the charger", "Alert", MessageBoxButtons.OK);
                //sleep for 5 seconds
                System.Threading.Thread.Sleep(1000);
                Application.Exit();
            }
            else if (battery > 0.89 && status == PowerLineStatus.Online)
            {
                //Play Asterisk  sound
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Battery is more than Limit, it is better unplug the charger", "Alert", MessageBoxButtons.OK);
                System.Threading.Thread.Sleep(1000);
                Application.Exit();
            }
            else
            {
                //Play Asterisk  sound
                myTimer.Enabled = true;
            }
            /*else
            {
                if (MessageBox.Show("Battery is fine, do you want to continue?", "Battery Status", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    myTimer.Enabled = true;
                }
                else
                {
                    exitFlag = true;
                }
            }*/
            // Displays a message box asking whether to continue running the timer.

        }
    }
}
