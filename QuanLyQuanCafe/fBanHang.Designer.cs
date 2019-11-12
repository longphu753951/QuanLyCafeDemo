namespace QuanLyQuanCafe
{
    partial class fBanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fLPContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.gBTTSP = new System.Windows.Forms.GroupBox();
            this.flpDoUong = new System.Windows.Forms.FlowLayoutPanel();
            this.flpTTSP = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnSoLuongXacNhan = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuyDon = new System.Windows.Forms.Button();
            this.cbLoaiSanPham = new System.Windows.Forms.ComboBox();
            this.gBOrder = new System.Windows.Forms.GroupBox();
            this.lsvOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelTinhTien = new System.Windows.Forms.Panel();
            this.lbMonDangChon = new System.Windows.Forms.Label();
            this.lbMon = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.lbTinhTrang = new System.Windows.Forms.Label();
            this.lblNgayHienTai = new System.Windows.Forms.Label();
            this.txttotalPrice = new System.Windows.Forms.TextBox();
            this.lbThoiGian = new System.Windows.Forms.Label();
            this.txtTenBan = new System.Windows.Forms.TextBox();
            this.lbTenBan = new System.Windows.Forms.Label();
            this.gbBan = new System.Windows.Forms.GroupBox();
            this.FLPBan = new System.Windows.Forms.FlowLayoutPanel();
            this.flpStaff = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.fLPContainer.SuspendLayout();
            this.gBTTSP.SuspendLayout();
            this.flpTTSP.SuspendLayout();
            this.gBOrder.SuspendLayout();
            this.panelTinhTien.SuspendLayout();
            this.gbBan.SuspendLayout();
            this.flpStaff.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLPContainer
            // 
            this.fLPContainer.BackColor = System.Drawing.SystemColors.Window;
            this.fLPContainer.Controls.Add(this.gBTTSP);
            this.fLPContainer.Controls.Add(this.gBOrder);
            this.fLPContainer.Controls.Add(this.panelTinhTien);
            this.fLPContainer.Controls.Add(this.gbBan);
            this.fLPContainer.Controls.Add(this.flpStaff);
            this.fLPContainer.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.fLPContainer.Location = new System.Drawing.Point(-2, -2);
            this.fLPContainer.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.fLPContainer.Name = "fLPContainer";
            this.fLPContainer.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.fLPContainer.Size = new System.Drawing.Size(1223, 585);
            this.fLPContainer.TabIndex = 0;
            // 
            // gBTTSP
            // 
            this.gBTTSP.BackColor = System.Drawing.SystemColors.Window;
            this.gBTTSP.Controls.Add(this.flpDoUong);
            this.gBTTSP.Controls.Add(this.flpTTSP);
            this.gBTTSP.Controls.Add(this.cbLoaiSanPham);
            this.gBTTSP.Location = new System.Drawing.Point(8, 98);
            this.gBTTSP.Name = "gBTTSP";
            this.gBTTSP.Size = new System.Drawing.Size(315, 484);
            this.gBTTSP.TabIndex = 0;
            this.gBTTSP.TabStop = false;
            this.gBTTSP.Text = "Thông tin sản phẩm";
            // 
            // flpDoUong
            // 
            this.flpDoUong.BackColor = System.Drawing.SystemColors.Window;
            this.flpDoUong.Location = new System.Drawing.Point(1, 111);
            this.flpDoUong.Name = "flpDoUong";
            this.flpDoUong.Size = new System.Drawing.Size(309, 367);
            this.flpDoUong.TabIndex = 5;
            // 
            // flpTTSP
            // 
            this.flpTTSP.Controls.Add(this.txtSoLuong);
            this.flpTTSP.Controls.Add(this.btnSoLuongXacNhan);
            this.flpTTSP.Controls.Add(this.btnXoa);
            this.flpTTSP.Controls.Add(this.btnHuyDon);
            this.flpTTSP.Location = new System.Drawing.Point(4, 58);
            this.flpTTSP.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.flpTTSP.Name = "flpTTSP";
            this.flpTTSP.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.flpTTSP.Size = new System.Drawing.Size(318, 45);
            this.flpTTSP.TabIndex = 4;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSoLuong.Location = new System.Drawing.Point(4, 3);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ReadOnly = true;
            this.txtSoLuong.Size = new System.Drawing.Size(75, 35);
            this.txtSoLuong.TabIndex = 19;
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoLuong.Click += new System.EventHandler(this.txtSoLuong_Click);
            // 
            // btnSoLuongXacNhan
            // 
            this.btnSoLuongXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoLuongXacNhan.Location = new System.Drawing.Point(85, 3);
            this.btnSoLuongXacNhan.Name = "btnSoLuongXacNhan";
            this.btnSoLuongXacNhan.Size = new System.Drawing.Size(66, 38);
            this.btnSoLuongXacNhan.TabIndex = 2;
            this.btnSoLuongXacNhan.Text = "Xác nhận";
            this.btnSoLuongXacNhan.UseVisualStyleBackColor = true;
            this.btnSoLuongXacNhan.Click += new System.EventHandler(this.btnSoLuongXacNhan_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(157, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(69, 38);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHuyDon
            // 
            this.btnHuyDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDon.Location = new System.Drawing.Point(232, 3);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(76, 38);
            this.btnHuyDon.TabIndex = 20;
            this.btnHuyDon.Text = "Hủy đơn";
            this.btnHuyDon.UseVisualStyleBackColor = true;
            this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);
            // 
            // cbLoaiSanPham
            // 
            this.cbLoaiSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiSanPham.FormattingEnabled = true;
            this.cbLoaiSanPham.Location = new System.Drawing.Point(6, 19);
            this.cbLoaiSanPham.Name = "cbLoaiSanPham";
            this.cbLoaiSanPham.Size = new System.Drawing.Size(303, 33);
            this.cbLoaiSanPham.TabIndex = 0;
            this.cbLoaiSanPham.SelectedIndexChanged += new System.EventHandler(this.cbLoaiSanPham_SelectedIndexChanged);
            // 
            // gBOrder
            // 
            this.gBOrder.BackColor = System.Drawing.SystemColors.Window;
            this.gBOrder.Controls.Add(this.lsvOrder);
            this.gBOrder.Location = new System.Drawing.Point(329, 178);
            this.gBOrder.Name = "gBOrder";
            this.gBOrder.Size = new System.Drawing.Size(548, 404);
            this.gBOrder.TabIndex = 1;
            this.gBOrder.TabStop = false;
            this.gBOrder.Text = "Order sản phẩm";
            // 
            // lsvOrder
            // 
            this.lsvOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvOrder.GridLines = true;
            this.lsvOrder.HideSelection = false;
            this.lsvOrder.Location = new System.Drawing.Point(5, 19);
            this.lsvOrder.Name = "lsvOrder";
            this.lsvOrder.Size = new System.Drawing.Size(537, 376);
            this.lsvOrder.TabIndex = 0;
            this.lsvOrder.UseCompatibleStateImageBehavior = false;
            this.lsvOrder.View = System.Windows.Forms.View.Details;
            this.lsvOrder.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lsvOrder_ColumnWidthChanging);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 157;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Đếm";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá tiền";
            this.columnHeader3.Width = 139;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng cộng";
            this.columnHeader4.Width = 186;
            // 
            // panelTinhTien
            // 
            this.panelTinhTien.BackColor = System.Drawing.SystemColors.Window;
            this.panelTinhTien.Controls.Add(this.lbMonDangChon);
            this.panelTinhTien.Controls.Add(this.lbMon);
            this.panelTinhTien.Controls.Add(this.btnThanhToan);
            this.panelTinhTien.Controls.Add(this.label1);
            this.panelTinhTien.Controls.Add(this.txtTinhTrang);
            this.panelTinhTien.Controls.Add(this.lbTinhTrang);
            this.panelTinhTien.Controls.Add(this.lblNgayHienTai);
            this.panelTinhTien.Controls.Add(this.txttotalPrice);
            this.panelTinhTien.Controls.Add(this.lbThoiGian);
            this.panelTinhTien.Controls.Add(this.txtTenBan);
            this.panelTinhTien.Controls.Add(this.lbTenBan);
            this.panelTinhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panelTinhTien.Location = new System.Drawing.Point(329, 25);
            this.panelTinhTien.Name = "panelTinhTien";
            this.panelTinhTien.Size = new System.Drawing.Size(548, 147);
            this.panelTinhTien.TabIndex = 4;
            // 
            // lbMonDangChon
            // 
            this.lbMonDangChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMonDangChon.Location = new System.Drawing.Point(65, 11);
            this.lbMonDangChon.Name = "lbMonDangChon";
            this.lbMonDangChon.Size = new System.Drawing.Size(223, 30);
            this.lbMonDangChon.TabIndex = 21;
            this.lbMonDangChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMon
            // 
            this.lbMon.AutoSize = true;
            this.lbMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMon.Location = new System.Drawing.Point(3, 16);
            this.lbMon.Name = "lbMon";
            this.lbMon.Size = new System.Drawing.Size(60, 25);
            this.lbMon.TabIndex = 20;
            this.lbMon.Text = "Món:";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(305, 96);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(228, 35);
            this.btnThanhToan.TabIndex = 19;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(3, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Tổng cộng:";
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Enabled = false;
            this.txtTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTinhTrang.Location = new System.Drawing.Point(406, 52);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(127, 31);
            this.txtTinhTrang.TabIndex = 17;
            // 
            // lbTinhTrang
            // 
            this.lbTinhTrang.AutoSize = true;
            this.lbTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTinhTrang.Location = new System.Drawing.Point(294, 54);
            this.lbTinhTrang.Name = "lbTinhTrang";
            this.lbTinhTrang.Size = new System.Drawing.Size(115, 25);
            this.lbTinhTrang.TabIndex = 16;
            this.lbTinhTrang.Text = "Tình trạng:";
            // 
            // lblNgayHienTai
            // 
            this.lblNgayHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNgayHienTai.Location = new System.Drawing.Point(139, 54);
            this.lblNgayHienTai.Name = "lblNgayHienTai";
            this.lblNgayHienTai.Size = new System.Drawing.Size(149, 30);
            this.lblNgayHienTai.TabIndex = 15;
            this.lblNgayHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttotalPrice
            // 
            this.txttotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txttotalPrice.Location = new System.Drawing.Point(129, 99);
            this.txttotalPrice.Name = "txttotalPrice";
            this.txttotalPrice.ReadOnly = true;
            this.txttotalPrice.Size = new System.Drawing.Size(140, 31);
            this.txttotalPrice.TabIndex = 11;
            this.txttotalPrice.Text = "0";
            this.txttotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbThoiGian
            // 
            this.lbThoiGian.AutoSize = true;
            this.lbThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbThoiGian.Location = new System.Drawing.Point(3, 54);
            this.lbThoiGian.Name = "lbThoiGian";
            this.lbThoiGian.Size = new System.Drawing.Size(143, 25);
            this.lbThoiGian.TabIndex = 2;
            this.lbThoiGian.Text = "Thời gian đặt:";
            // 
            // txtTenBan
            // 
            this.txtTenBan.Enabled = false;
            this.txtTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenBan.Location = new System.Drawing.Point(406, 14);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(127, 31);
            this.txtTenBan.TabIndex = 1;
            // 
            // lbTenBan
            // 
            this.lbTenBan.AutoSize = true;
            this.lbTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTenBan.Location = new System.Drawing.Point(312, 16);
            this.lbTenBan.Name = "lbTenBan";
            this.lbTenBan.Size = new System.Drawing.Size(97, 25);
            this.lbTenBan.TabIndex = 0;
            this.lbTenBan.Text = "Tên bàn:";
            // 
            // gbBan
            // 
            this.gbBan.BackColor = System.Drawing.SystemColors.Window;
            this.gbBan.Controls.Add(this.FLPBan);
            this.gbBan.Location = new System.Drawing.Point(883, 98);
            this.gbBan.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.gbBan.Name = "gbBan";
            this.gbBan.Padding = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.gbBan.Size = new System.Drawing.Size(332, 484);
            this.gbBan.TabIndex = 1;
            this.gbBan.TabStop = false;
            this.gbBan.Text = "Thông tin bàn";
            // 
            // FLPBan
            // 
            this.FLPBan.AutoScroll = true;
            this.FLPBan.BackColor = System.Drawing.SystemColors.Window;
            this.FLPBan.Location = new System.Drawing.Point(6, 16);
            this.FLPBan.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.FLPBan.Name = "FLPBan";
            this.FLPBan.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.FLPBan.Size = new System.Drawing.Size(320, 462);
            this.FLPBan.TabIndex = 0;
            // 
            // flpStaff
            // 
            this.flpStaff.BackColor = System.Drawing.SystemColors.Window;
            this.flpStaff.Controls.Add(this.btnDangXuat);
            this.flpStaff.Controls.Add(this.btnAdmin);
            this.flpStaff.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpStaff.Location = new System.Drawing.Point(883, 25);
            this.flpStaff.Name = "flpStaff";
            this.flpStaff.Size = new System.Drawing.Size(332, 69);
            this.flpStaff.TabIndex = 5;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(258, 3);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(71, 57);
            this.btnDangXuat.TabIndex = 0;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(181, 3);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(71, 57);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // fBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 572);
            this.Controls.Add(this.fLPContainer);
            this.Name = "fBanHang";
            this.Text = "fBanHang";
            this.Load += new System.EventHandler(this.fBanHang_Load);
            this.fLPContainer.ResumeLayout(false);
            this.gBTTSP.ResumeLayout(false);
            this.flpTTSP.ResumeLayout(false);
            this.flpTTSP.PerformLayout();
            this.gBOrder.ResumeLayout(false);
            this.panelTinhTien.ResumeLayout(false);
            this.panelTinhTien.PerformLayout();
            this.gbBan.ResumeLayout(false);
            this.flpStaff.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fLPContainer;
        private System.Windows.Forms.GroupBox gBTTSP;
        private System.Windows.Forms.GroupBox gBOrder;
        private System.Windows.Forms.GroupBox gbBan;
        private System.Windows.Forms.Panel panelTinhTien;
        private System.Windows.Forms.FlowLayoutPanel FLPBan;
        private System.Windows.Forms.Label lbTenBan;
        private System.Windows.Forms.TextBox txtTenBan;
        private System.Windows.Forms.Label lbThoiGian;
        private System.Windows.Forms.Label lblNgayHienTai;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label lbTinhTrang;
        private System.Windows.Forms.ListView lsvOrder;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttotalPrice;
        private System.Windows.Forms.ComboBox cbLoaiSanPham;
        private System.Windows.Forms.Button btnSoLuongXacNhan;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.FlowLayoutPanel flpTTSP;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.FlowLayoutPanel flpDoUong;
        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.FlowLayoutPanel flpStaff;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Label lbMonDangChon;
        private System.Windows.Forms.Label lbMon;
    }
}