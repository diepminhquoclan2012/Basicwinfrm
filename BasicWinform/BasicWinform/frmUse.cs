using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicWinform.Entities;

namespace BasicWinform
{
    public partial class frmUse : Form
    {
        Person person;
        public frmUse(string idPerson ="1")
        {
            InitializeComponent();
            person = Person.Get(idPerson);
            if (person != null)
            {
                txtHoTen.Text = $"{person.LastName} " +
                    $"{person.FirstName}";

                dtpNgaySinh.Value = person.DOB;
                if (person.Sex == EGioiTinh.Nam)
                    rdNam.Checked = true;
                else if (person.Sex == EGioiTinh.Nu)
                    rdNu.Checked = true;
                else
                    rdKhac.Checked = true;
                txtNoiSinh.Text = person.HomeTown;
                txtQueQuan.Text = person.HomeTown;
            }
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            // tạo 1 hộp thoại chon file
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "File ảnh(*.png,*.jpg)|*.png;*.jpg";
            dialog.Title = "Chọn ảnh đại diện ";
  
            if(dialog.ShowDialog()== DialogResult.OK)
            {
                var fileName = dialog.FileName;
                picAvatar.ImageLocation = fileName;

            }
        }
    }
}
