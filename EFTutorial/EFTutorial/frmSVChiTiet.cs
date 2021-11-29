using EFTutorial.BLL;
using EFTutorial.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFTutorial
{
    public partial class frmSVChiTiet : Form
    {
        SinhVienVM svm;
        long id;
        public frmSVChiTiet(long id,SinhVienVM svv )
        {
            this.id = id;
            this.svm = svv;
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            
            errorProvider5.Clear();
            var MSV = textBox1.Text;
            if (string.IsNullOrEmpty(MSV))
            {
                errorProvider1.SetError(textBox1, "MSV không được để trống");
                return;
            }
            var First = textBox2.Text;
            if (string.IsNullOrEmpty(First))
            {
                errorProvider2.SetError(textBox2, "FirstName không được để trống");
                return;
            }
            var Last = textBox3.Text;
            if (string.IsNullOrEmpty(Last))
            {
                errorProvider3.SetError(textBox3, "LastName không được để trống");
                return;
            }
           
           
            var POB = textBox5.Text;
            if (string.IsNullOrEmpty(POB))
            {
                errorProvider5.SetError(textBox5, "POB không được để trống");
                return;
            }
            var rs = KETQUA.ThanhCong;
            if (svm == null)
            {
                // thêm vào csdl
                rs = SinhVienBLL.Add(new SinhVienVM {
                    IDStudent = MSV,
                    FirstName = First,
                    LastName = Last,
                    DOB = dateTimePicker1.Value,
                    POB = POB,
                    IDLop = id
                }) ;

            }
            if (rs == KETQUA.ThanhCong)
            {
                DialogResult = DialogResult.OK;
            }
            else if (rs == KETQUA.TenTrung)
            {
                MessageBox.Show("Mã Sinh Viên không được trung nhau ", " Thông báo");
            }
        }
    }
}
