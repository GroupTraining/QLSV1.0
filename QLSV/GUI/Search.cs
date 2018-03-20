using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;

namespace QLSV.GUI
{
    public partial class Search : Form
    {
        Bus bus = new Bus();
        public Search()
        {
            InitializeComponent();
            dgvSinhVien.DataSource = bus.getData2();
            this.dgvSinhVien.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvSinhVien.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvSinhVien.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvSinhVien.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        DataDiagramDataContext data = new DataDiagramDataContext();
        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void btnSEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSinhVien.DataSource = bus.SearchByKey(searchtxt.Text);
            }
            catch
            {

            }
        }
    }
}
