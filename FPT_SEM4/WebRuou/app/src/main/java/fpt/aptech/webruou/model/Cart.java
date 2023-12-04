package fpt.aptech.webruou.model;

public class Cart {
    private Integer id;
    private Integer idKhachHang;
    private Integer idSanPham;
    private String ten;
    private String url;
    private Integer soLuong;
    private Integer donGia;
    private Integer tongtien;

    public Cart() {
    }

    public Cart(Integer idKhachHang, Integer idSanPham, String ten, String url, Integer soLuong, Integer donGia, Integer tongtien) {
        this.idKhachHang = idKhachHang;
        this.idSanPham = idSanPham;
        this.ten = ten;
        this.url = url;
        this.soLuong = soLuong;
        this.donGia = donGia;
        this.tongtien = tongtien;
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

    public Integer getIdSanPham() {
        return idSanPham;
    }

    public void setIdSanPham(Integer idSanPham) {
        this.idSanPham = idSanPham;
    }

    public String getTen() {
        return ten;
    }

    public void setTen(String ten) {
        this.ten = ten;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public Integer getSoLuong() {
        return soLuong;
    }

    public void setSoLuong(Integer soLuong) {
        this.soLuong = soLuong;
    }

    public Integer getDonGia() {
        return donGia;
    }

    public void setDonGia(Integer donGia) {
        this.donGia = donGia;
    }

    public Integer getTongtien() {
        return tongtien;
    }

    public void setTongtien(Integer tongtien) {
        this.tongtien = tongtien;
    }
}
