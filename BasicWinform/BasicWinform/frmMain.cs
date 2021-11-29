using System;
using System.Numerics;
using System.Windows.Forms;

namespace BasicWinform
{
    public partial class frmMain : Form
    {
        private BigInteger numa ,numb;
        public frmMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.convert();
            this.lableKetQua.Text = (this.numa - this.numb).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                 this.convert();
                this.lableKetQua.Text = (numa + numb).ToString();        
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            this.convert();
            this.lableKetQua.Text = (numa * numb).ToString();
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            this.convert();
            numa *= 10000;
            BigInteger kq = numa / numb;
            this.lableKetQua.Text = ((double)kq/10000).ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.lableKetQua.Text = "0";
            this.txtSoThuNhat.Text = String.Empty;
            this.txtSoThuHai.Text = String.Empty;
        }

        private void convert()
        {
            string texta = this.txtSoThuNhat.Text;
            string textb = this.txtSoThuHai.Text;
            try
            {
                numa = BigInteger.Parse(texta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập lại số thứ nhất. Chi tiết lỗi: " + ex.Message,
                    "Thông báo lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                numb = BigInteger.Parse(textb);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập lại số thứ hai. Chi tiết lỗi: " + ex.Message,
                   "Thông báo lỗi",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }
        }
    }
}
