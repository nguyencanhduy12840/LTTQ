using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form1 : Form
    {
        DanhSach danhsach = new DanhSach();
        private int STT = 0;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            if(frm2.ShowDialog() == DialogResult.OK)
            {
                SinhVien sinhVien = new SinhVien();
                STT++;
                string mssv = frm2.txtMSSV.Text.ToString();
                string hoten = frm2.txtTen.Text.ToString();
                string khoa = frm2.cbKhoa.Text.ToString();
                float diemtb = Convert.ToSingle(frm2.txtDiem.Text.ToString());
                sinhVien.STT = STT;
                sinhVien.MSSV = mssv;
                sinhVien.TenSV = hoten;
                sinhVien.Khoa = khoa;
                sinhVien.DiemTB = diemtb;
                dgvThongTin.Rows.Add(STT, mssv, hoten, khoa, diemtb);
                danhsach.sinhViens.Add(sinhVien);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                SinhVien sinhVien = new SinhVien();
                STT++;
                string mssv = frm2.txtMSSV.Text.ToString();
                string hoten = frm2.txtTen.Text.ToString();
                string khoa = frm2.cbKhoa.Text.ToString();
                float diemtb = Convert.ToSingle(frm2.txtDiem.Text.ToString());
                sinhVien.STT = STT;
                sinhVien.MSSV = mssv;
                sinhVien.TenSV = hoten;
                sinhVien.Khoa = khoa;
                sinhVien.DiemTB = diemtb;
                dgvThongTin.Rows.Add(STT, mssv, hoten, khoa, diemtb);
                danhsach.sinhViens.Add(sinhVien);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = toolStripTextBox1.Text.ToLower();
            var filteredList = danhsach.sinhViens.Where(sv => sv.TenSV.ToLower().Contains(searchTerm)).ToList();
            dgvThongTin.DataSource = new List<SinhVien>(filteredList);
        }
    }
}
