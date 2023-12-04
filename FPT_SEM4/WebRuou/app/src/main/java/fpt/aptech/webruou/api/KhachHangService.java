package fpt.aptech.webruou.api;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.List;

import fpt.aptech.webruou.model.Cart;
import fpt.aptech.webruou.model.ChiTietDonHang;
import fpt.aptech.webruou.model.DetailsDonHang;
import fpt.aptech.webruou.model.DonHang;
import fpt.aptech.webruou.model.DonHangImage;
import fpt.aptech.webruou.model.FeedBack;
import fpt.aptech.webruou.model.KhachHang;
import fpt.aptech.webruou.model.SanPham;
import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;

public interface KhachHangService {
    String url = Utils.URL;
    //-----------------------------------------------------------
    Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd HH:mm:ss").create();
    KhachHangService apiService = new Retrofit.Builder().baseUrl(url).addConverterFactory(GsonConverterFactory.create(gson)).build().create(KhachHangService.class);
    //-----------------------------------------------------------
    @GET("KhachHang")
    Call<List<KhachHang>> findAll();
    @GET("KhachHang/{varLocal}")
    Call<KhachHang> findOne(@Path("varLocal") int varLocal);

    @GET("KhachHang/login/{varLocal1}/{varLocal2}")
    Call<KhachHang> checkLogin(@Path("varLocal1") String varLocal1,
                               @Path("varLocal2") String varLocal2);

    @GET("KhachHang/mail/{varLocal}")
    Call<KhachHang> findEmail(@Path("varLocal") String varLocal);

    @GET("KhachHang/xemdonhang/{varLocal}")
    Call<List<DonHang>> listDonHang(@Path("varLocal") int varLocal);
    @GET("KhachHang/getdonhang/{varLocal}")
    Call<DonHang> getDonHang(@Path("varLocal") int varLocal);

    @GET("KhachHang/xemdonhangimage/{varLocal}")
    Call<List<DonHangImage>> listDonHangImage(@Path("varLocal") int varLocal);

    @GET("KhachHang/gethuydonhang/{varLocal}")
    Call<List<DonHang>> listHuyDonHang(@Path("varLocal") int varLocal);

    @GET("KhachHang/gethuydonhangimage/{varLocal}")
    Call<List<DonHangImage>> listHuyDonHangImage(@Path("varLocal") int varLocal);

    @GET("KhachHang/chitietdonhang/{varLocal}")
    Call<List<DetailsDonHang>> detailsDonHang(@Path("varLocal") int varLocal);

    @PUT("KhachHang")
    Call<Boolean> editTable(@Body KhachHang varTable);
    @PUT("KhachHang/luugiohang")
    Call<Boolean> editGioHang(@Body Cart varTable);

    @POST("KhachHang")
    Call<Boolean> addTable(@Body KhachHang varTable);

    @POST("KhachHang/themdonhang")
    Call<Boolean> addDonHang(@Body DonHang varTable);

    @POST("KhachHang/themgiohang")
    Call<Boolean> addGioHang(@Body Cart varTable);
    @DELETE("KhachHang/xoagiohang/{varLocal}")
    Call<Boolean> deleteGioHang(@Path("varLocal") int varLocal);

    @GET("KhachHang/sanpham")
    Call<List<SanPham>> findSanPhamAll();
    @GET("KhachHang/sanpham/{varLocal}")
    Call<SanPham> findSanPhamOne(@Path("varLocal") int varLocal);

    @GET("KhachHang/searchsanpham/{varLocal}")
    Call<List<SanPham>> SearchSanPham(@Path("varLocal") String varLocal);
    @GET("KhachHang/xemgiohang/{varLocal}")
    Call<List<Cart>> listCartAll(@Path("varLocal") int varLocal);

    @GET("KhachHang/demgiohang/{varLocal}")
    Call<Cart> countCart(@Path("varLocal") int varLocal);

    @GET("KhachHang/demsanpham/{varLocal1}/{varLocal2}")
    Call<Cart> countSanPham(@Path("varLocal1") int varLocal1,@Path("varLocal2") int varLocal2);
    @PUT("KhachHang/huydonhang")
    Call<Boolean> CancelOrder(@Body DonHang varTable);

    @GET("KhachHang/getdanhgia/{varLocal1}/{varLocal2}/{varLocal3}")
    Call<FeedBack> getDanhgia(@Path("varLocal1") int varLocal1, @Path("varLocal2") int varLocal2, @Path("varLocal3") int varLocal3);

    @POST("KhachHang/setdanhgia")
    Call<Boolean> setDanhgia(@Body FeedBack varTable);

}
