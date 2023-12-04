package fpt.aptech.webruou.model;

public class ChiTietDonHang {
    private Integer idDonHang;
    private Integer idSanPham;
    private Integer soLuong;
    private Integer giaTien;
    private String name;
    private String description;
    private String urlImage;
    private Integer promotion;

    public ChiTietDonHang() {
    }

    public ChiTietDonHang(Integer idDonHang, Integer idSanPham, Integer soLuong, Integer giaTien, String name, String description, String urlImage, Integer promotion) {
        this.idDonHang = idDonHang;
        this.idSanPham = idSanPham;
        this.soLuong = soLuong;
        this.giaTien = giaTien;
        this.name = name;
        this.description = description;
        this.urlImage = urlImage;
        this.promotion = promotion;
    }

    public Integer getIdDonHang() {
        return idDonHang;
    }

    public void setIdDonHang(Integer idDonHang) {
        this.idDonHang = idDonHang;
    }

    public Integer getIdSanPham() {
        return idSanPham;
    }

    public void setIdSanPham(Integer idSanPham) {
        this.idSanPham = idSanPham;
    }

    public Integer getSoLuong() {
        return soLuong;
    }

    public void setSoLuong(Integer soLuong) {
        this.soLuong = soLuong;
    }

    public Integer getGiaTien() {
        return giaTien;
    }

    public void setGiaTien(Integer giaTien) {
        this.giaTien = giaTien;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getUrlImage() {
        return urlImage;
    }

    public void setUrlImage(String urlImage) {
        this.urlImage = urlImage;
    }

    public Integer getPromotion() {
        return promotion;
    }

    public void setPromotion(Integer promotion) {
        this.promotion = promotion;
    }
}
