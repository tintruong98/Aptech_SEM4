package fpt.aptech.webruou.model;

public class DonHang {
    private Integer id;
    private Integer idKhachHang;
    private Boolean daThanhToan;
    private String ngayDat;
    private String ngayGiao;
    private Integer soLuong;
    private Integer tongTien;
    private Integer trangThaiGH;

    public DonHang() {
    }

    public DonHang(Integer idKhachHang, Boolean daThanhToan, String ngayDat, String ngayGiao, Integer soLuong, Integer tongTien, Integer trangThaiGH) {
        this.idKhachHang = idKhachHang;
        this.daThanhToan = daThanhToan;
        this.ngayDat = ngayDat;
        this.ngayGiao = ngayGiao;
        this.soLuong = soLuong;
        this.tongTien = tongTien;
        this.trangThaiGH = trangThaiGH;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getIdKhachHang() {
        return idKhachHang;
    }

    public void setIdKhachHang(Integer idKhachHang) {
        this.idKhachHang = idKhachHang;
    }

    public Boolean getDaThanhToan() {
        return daThanhToan;
    }

    public void setDaThanhToan(Boolean daThanhToan) {
        this.daThanhToan = daThanhToan;
    }

    public String getNgayDat() {
        return ngayDat;
    }

    public void setNgayDat(String ngayDat) {
        this.ngayDat = ngayDat;
    }

    public String getNgayGiao() {
        return ngayGiao;
    }

    public void setNgayGiao(String ngayGiao) {
        this.ngayGiao = ngayGiao;
    }

    public Integer getSoLuong() {
        return soLuong;
    }

    public void setSoLuong(Integer soLuong) {
        this.soLuong = soLuong;
    }

    public Integer getTongTien() {
        return tongTien;
    }

    public void setTongTien(Integer tongTien) {
        this.tongTien = tongTien;
    }

    public Integer getTrangThaiGH() {
        return trangThaiGH;
    }

    public void setTrangThaiGH(Integer trangThaiGH) {
        this.trangThaiGH = trangThaiGH;
    }
}
