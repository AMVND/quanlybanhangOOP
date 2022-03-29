using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class frmMatHang : Form
    {
        public frmMatHang()
        {
            InitializeComponent();
        }

        private void HienChiTiet(Boolean hien)
        {
            txtMaSP.Enabled = hien;
            txtTenSP.Enabled = hien;
            dtpNgayHH.Enabled = hien;
            dtpNgaySX.Enabled = hien;
            txtDonVi.Enabled = hien;
            txtDonGia.Enabled = hien;
            txtGhiChu.Enabled = hien;
            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
        }
        // hàm xóa chi tiết sản phẩm
        public void XoaTrangChiTiet(string masp, string tensp, DateTime ngaysx, DateTime ngayhh, string donvi, string dongia, string ghichu)
        {
            masp = "";
            tensp = "";
            ngaysx = DateTime.Today;
            ngayhh = DateTime.Today;
            donvi = "";
            dongia = "";
            ghichu = "";
        }

        // =======================================================================
        // TÌM KIẾM
        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            lblTieuDe.Text = "TÌM KIẾM MẶT HÀNG";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            MatHang sp = new MatHang();
            dgvKetQua.DataSource = sp.searchProduct(txtTKTenSP.Text);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            lblTieuDe.Text = "THÊM MẶT HÀNG";
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            dtpNgaySX.Value = DateTime.Today;
            dtpNgayHH.Value = DateTime.Today;
            txtDonGia.Text = "";
            txtDonVi.Text = "";
            txtGhiChu.Text = "";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            lblTieuDe.Text = "CẬP NHẬT MẶT HÀNG";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            HienChiTiet(true);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa mã mặt hàng " + txtMaSP.Text + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lblTieuDe.Text = "XÓA MẶT HÀNG";
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    HienChiTiet(true);
                }
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {

            if (btnThem.Enabled == true)
            {
                MatHang sp = new MatHang();
                sp.insertProduct(txtMaSP.Text, txtTenSP.Text, dtpNgaySX.Value, dtpNgayHH.Value, txtDonVi.Text, txtDonGia.Text, txtGhiChu.Text);
                dgvKetQua.DataSource = sp.showProduct();
            }
            if (btnSua.Enabled == true)
            {
                MatHang sp = new MatHang();
                sp.updateProduct(txtMaSP.Text, txtTenSP.Text, dtpNgaySX.Value, dtpNgayHH.Value, txtDonVi.Text, txtDonGia.Text, txtGhiChu.Text);
                dgvKetQua.DataSource = sp.showProduct();
            }
            if (btnXoa.Enabled == true)
            {
                MatHang sp = new MatHang();
                sp.delProduct(txtMaSP.Text);
                dgvKetQua.DataSource = sp.showProduct();
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;

            XoaTrangChiTiet(txtMaSP.Text, txtTenSP.Text, dtpNgaySX.Value, dtpNgayHH.Value, txtDonVi.Text, txtDonGia.Text, txtGhiChu.Text);

            HienChiTiet(false);

        }

        private void dgvKetQua_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;

            try
            {
                txtMaSP.Text = dgvKetQua[0, e.RowIndex].Value.ToString();
                txtTenSP.Text = dgvKetQua[1, e.RowIndex].Value.ToString();
                dtpNgaySX.Value = (DateTime)dgvKetQua[2, e.RowIndex].Value;
                dtpNgayHH.Value = (DateTime)dgvKetQua[3, e.RowIndex].Value;
                txtDonVi.Text = dgvKetQua[4, e.RowIndex].Value.ToString();
                txtDonGia.Text = dgvKetQua[5, e.RowIndex].Value.ToString();
                txtGhiChu.Text = dgvKetQua[6, e.RowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
