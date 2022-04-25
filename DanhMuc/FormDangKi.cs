using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET.DanhMuc
{
    public partial class FormDangKi : Form
    {
        public FormDangKi()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtPass.Text == txtCheck.Text && txtUser.Text != "" && txtPass.Text != "")
            {
                BS_Layer.BLDangNhap dk = new BS_Layer.BLDangNhap();
                dk.AddUser(txtUser.Text, txtPass.Text);
                MessageBox.Show("Done!");
                this.Close();
            }
        }
    }
}
