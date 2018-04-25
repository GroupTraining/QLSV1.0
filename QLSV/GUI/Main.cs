using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnGV_Click(object sender, EventArgs e)
        {
            GUI.ThemGV ad = new GUI.ThemGV();
            ad.Show();
        }

        private void btnHS_Click(object sender, EventArgs e)
        {
            GUI.ThemHS ad = new GUI.ThemHS();
            ad.Show();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            GUI.ThemDiem ad = new GUI.ThemDiem();
            ad.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GUI.Search search = new GUI.Search();
            search.Show();
        }

        private void editGV_Click(object sender, EventArgs e)
        {
            GUI.EditTeacher edit = new GUI.EditTeacher();
            edit.Show();
        }

        private void editHS_Click(object sender, EventArgs e)
        {
            GUI.frmSuaXoaSV edit = new GUI.frmSuaXoaSV();
            edit.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            GUI.ThongKe tk = new GUI.ThongKe();
            tk.Show();
        }
    }
}
