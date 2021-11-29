using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicWinform
{
    public partial class FrmTimer : Form
    {
        public FrmTimer()
        {
            InitializeComponent();
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Cứ 1 s thì gọi hàm này 1 lần .
            // enuble = true
            if (total_second == 0 )
                timer1.Stop(); 
            else
            {                
                total_second--;

                lblTimer.Text = $"{total_second / 60:0#} : {total_second % 60:0#}";
            }
           

        }
        int total_second = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
           var minute =(int) nbTimer.Value;
            total_second = minute * 60;
             
             timer1.Start();
        }

        private void nbTimer_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
