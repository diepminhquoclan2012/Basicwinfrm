using System;
using WMPLib;
using System.Windows.Forms;

namespace BasicWinform
{
    public partial class happy_new_year : Form
    {
        WindowsMediaPlayer sound = new WindowsMediaPlayer();
        WindowsMediaPlayer sound1 = new WindowsMediaPlayer();

        public happy_new_year()
        {
            InitializeComponent();
        }
        int nums;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(input.Text) != 0)
                {
                     nums = int.Parse(input.Text);                  
                    output.Text = $"{nums / 60 / 60 / 24:0#} : {nums / 60 / 60 % 24:0#} : {nums / 60 % 60:0#} : {nums % 60:0#}";
                    timer1.Start();
                }
                else
                {
                    DateTime DayNow = DateTime.Now;
                    DateTime DayTo = new DateTime(2022,1,1,0,0,0);
                    TimeSpan interval = DayTo.Subtract(DayNow);
                    nums = (int)interval.TotalSeconds;                  
                    output.Text = $"{nums / 60 / 60 / 24:0#} : {nums / 60 / 60 % 24:0#} : {nums / 60 % 60:0#} : {nums % 60:0#}";
                    timer1.Start();
                }
            }
            catch(Exception)
            { }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
             nums--;
            output.Text = $"{nums / 60 / 60 / 24:0#} : {nums / 60 / 60 % 24:0#} : {nums / 60 % 60:0#} : {nums % 60:0#}";
            if (nums == 0)
            {
                timer1.Stop();
                try
                {
                    sound.URL = @"C:\Users\vovan\OneDrive\Desktop\LapTrinhC#\BasicWinform\BasicWinform\sound\phaohoa.mp3";
                    sound.controls.play();
                }
                catch { }
                      
                pictureBox1.Visible = true;                            
            }         
            if (nums==15)
            {
                sound1.URL = @"C:\Users\vovan\OneDrive\Desktop\LapTrinhC#\BasicWinform\BasicWinform\sound\HappyNewYear-ABBA-1595921.mp3";
                  sound1.controls.play();
              
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            sound.controls.stop();
            sound1.controls.stop();
        }

    }
}
