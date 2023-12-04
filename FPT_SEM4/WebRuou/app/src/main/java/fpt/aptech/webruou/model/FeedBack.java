package fpt.aptech.webruou.model;

public class FeedBack {
    private Integer id;
    private Integer idKhachHang;
    private Integer idDonHang;
    private Integer idSanPham;
    private String contents;
    private String  thoiGianFeed;
    private Integer evaluate;

    public FeedBack() {
    }

    public FeedBack(Integer idKhachHang, Integer idDonHang, Integer idSanPham, String contents, String thoiGianFeed, Integer evaluate) {
        this.idKhachHang = idKhachHang;
        this.idDonHang = idDonHang;
        this.idSanPham = idSanPham;
        this.contents = contents;
        this.thoiGianFeed = thoiGianFeed;
        this.evaluate = evaluate;
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

    public String getContents() {
        return contents;
    }

    public void setContents(String contents) {
        this.contents = contents;
    }

    public String getThoiGianFeed() {
        return thoiGianFeed;
    }

    public void setThoiGianFeed(String thoiGianFeed) {
        this.thoiGianFeed = thoiGianFeed;
    }

    public Integer getEvaluate() {
        return evaluate;
    }

    public void setEvaluate(Integer evaluate) {
        this.evaluate = evaluate;
    }
}
