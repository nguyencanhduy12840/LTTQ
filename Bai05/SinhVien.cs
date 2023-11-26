using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class SinhVien
    {
        private int dgvSTT;
        private string dgvMSSV;
        private string dgvTenSV;
        private string dgvKhoa;
        private float dgvDiemTB;
        public int STT
        {
            get { return dgvSTT; }
            set { dgvSTT = value; }
        }

        public string MSSV
        {
            get { return dgvMSSV; }
            set { dgvMSSV = value; }
        }

        public string TenSV
        {
            get { return dgvTenSV; }
            set { dgvTenSV = value; }
        }

        public string Khoa
        {
            get { return dgvKhoa; }
            set { dgvKhoa = value; }
        }

        public float DiemTB
        {
            get { return dgvDiemTB; }
            set { dgvDiemTB = value; }
        }
    }
}
