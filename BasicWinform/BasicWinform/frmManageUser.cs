using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BasicWinform.Entities;

namespace BasicWinform
{
    public partial class frmManageUser : Form
    {
        public frmManageUser()
        {
            InitializeComponent();
            var ls = Person.GetList();
            personBindingSource.DataSource = ls;
            gridSinhVien.DataSource = personBindingSource;
        }
        public Person SelectedPerson
        {
            get
            {
                var p = personBindingSource.Current as Person;
                return p;
            }
        }
        private void gridSinhVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(SelectedPerson!=null)
            {
                var f = new frmUse(SelectedPerson.Id);
                f.Show();
            }    
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (SelectedPerson != null)
            {
                var result = MessageBox.Show(
                     "Bạn có chắc là muốn xóa sinh viên này không?",
                     "Chú ý",
                     MessageBoxButtons.OKCancel,
                     MessageBoxIcon.Question
                     );
                if (result == DialogResult.OK)
                {
                    personBindingSource.RemoveCurrent();
                }
            }
        }

        
    }
}
