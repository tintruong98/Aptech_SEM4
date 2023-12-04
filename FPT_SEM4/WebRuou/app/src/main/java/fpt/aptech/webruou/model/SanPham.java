package fpt.aptech.webruou.model;

public class SanPham {
    private Integer id;
    private String name;
    private String description;
    private String urlImage;
    private Integer price;
    private Integer promotion;
    private Integer soluong;

    public SanPham() {
    }

    public SanPham(String name, String description, String urlImage, Integer price, Integer promotion, Integer soluong) {
        this.name = name;
        this.description = description;
        this.urlImage = urlImage;
        this.price = price;
        this.promotion = promotion;
        this.soluong = soluong;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
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

    public Integer getPrice() {
        return price;
    }

    public void setPrice(Integer price) {
        this.price = price;
    }

    public Integer getPromotion() {
        return promotion;
    }

    public void setPromotion(Integer promotion) {
        this.promotion = promotion;
    }

    public Integer getSoluong() {
        return soluong;
    }

    public void setSoluong(Integer soluong) {
        this.soluong = soluong;
    }
}
