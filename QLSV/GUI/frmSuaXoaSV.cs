using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QLSV.GUI
{
    public partial class frmSuaXoaSV : Form
    {
        Bus db = new Bus();
        public frmSuaXoaSV()
        {
            InitializeComponent();

            dataGridView1.DataSource = db.getData2();
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa học sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.editStudent(txtMasv.Text, txtTensv.Text, cbGt.Text, dtpNs.Text, txtMalop.Text);
            }

            dataGridView1.DataSource = db.getData2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa học sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.deleteStudent(txtMasv.Text);
                dataGridView1.DataSource = db.getData2();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMasv.Text = dataGridView1.CurrentRow.Cells["MaHS"].Value.ToString();
            if (dataGridView1.CurrentRow.Cells["HoTen"].Value == null)
            {
                txtTensv.Text = "";
            }
            else
            {
                txtTensv.Text = dataGridView1.CurrentRow.Cells["HoTen"].Value.ToString();
            }
            if (dataGridView1.CurrentRow.Cells["NgaySinh"].Value == null)
            {
                dtpNs.Text = "";
            }
            else
            {
                dtpNs.Text = dataGridView1.CurrentRow.Cells["NgaySinh"].Value.ToString();
            }
            if (dataGridView1.CurrentRow.Cells["GioiTinh"].Value == null)
            {
                cbGt.Text = "";
            }
            else if (dataGridView1.CurrentRow.Cells["GioiTinh"].Value.ToString() == "False")
            {
                cbGt.Text = "Nam";
            }
            else
            {
                cbGt.Text = "Nữ";
            }
            if (dataGridView1.CurrentRow.Cells["MaLop"].Value == null)
            {
                txtMalop.Text = "";
            }
            else
            {
                txtMalop.Text = dataGridView1.CurrentRow.Cells["MaLop"].Value.ToString();
            }
        }
    }
}
