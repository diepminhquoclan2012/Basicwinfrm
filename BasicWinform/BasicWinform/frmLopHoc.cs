using System;
using BasicWinform.Entities;
using System.Windows.Forms;

namespace BasicWinform
{
    public partial class frmLopHoc : Form
    {
        public frmLopHoc()
        {
            InitializeComponent();
           
           // Cái này t sẽ vẽ lại
            cmbKhoa.DataSource= Faculty.GetList();
            cmbKhoa.DisplayMember = "Name";
            cmbKhoa.ValueMember = "Id";
           
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            // Làm lại cái Girl View
                int index = cmbKhoa.SelectedIndex;
                var item = cmbKhoa.SelectedItem as Faculty;
                // Unbox
                var lsPerson = Person.GetList(item.Id);
                gridPerson.DataSource = lsPerson;
            
        }
    }
}
