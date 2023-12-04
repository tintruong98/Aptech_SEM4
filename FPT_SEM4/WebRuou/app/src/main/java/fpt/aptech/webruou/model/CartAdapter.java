package fpt.aptech.webruou.model;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.text.DecimalFormat;
import java.util.List;

import fpt.aptech.webruou.AddToCartActivity;
import fpt.aptech.webruou.R;
import fpt.aptech.webruou.api.KhachHangService;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class CartAdapter extends RecyclerView.Adapter<CartViewHolder> {
    Activity activity;
    List<Cart> datalist;
    Integer idKhachHang_;

    public CartAdapter(Activity activity , List<Cart> datalist, int idKhachHang_) {
        this.activity = activity;
        this.datalist = datalist;
        this.idKhachHang_ =idKhachHang_;
    }

    @NonNull
    @Override
    public CartViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        return new CartViewHolder(LayoutInflater.from(activity).inflate(R.layout.item_view_giohang,parent,false));
    }

    @Override
    public void onBindViewHolder(@NonNull CartViewHolder holder, int position) {

        DecimalFormat formatter = new DecimalFormat("#,###,###");

        String cnvImages = datalist.get(position).getUrl().trim().substring(7);
        cnvImages = cnvImages.substring(0,cnvImages.length()-4);

        int imgID = activity.getResources().getIdentifier(cnvImages, "drawable", activity.getApplicationContext().getPackageName());
        holder.imageview.setImageResource(imgID);
        holder.ten.setText(datalist.get(position).getTen());
        holder.dongia.setText(formatter.format(datalist.get(position).getDonGia())+" VND");
        holder.txtSoluong.setText(formatter.format(datalist.get(position).getSoLuong()));
        final int newPosition=position;
        //---
        holder.btnMax.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                KhachHangService.apiService.findSanPhamOne(datalist.get(newPosition).getIdSanPham()).enqueue(new Callback<SanPham>() {
                    @Override
                    public void onResponse(Call<SanPham> call, Response<SanPham> response) {
                        if (datalist.get(newPosition).getSoLuong()<response.body().getSoluong()){
                            Cart giohang = new Cart();
                            Integer slhang = datalist.get(newPosition).getSoLuong()+1;
                            if (slhang>10){
                                slhang=10;
                            }else{
                                giohang.setId(datalist.get(newPosition).getId());
                                giohang.setIdKhachHang(idKhachHang_);
                                giohang.setIdSanPham(datalist.get(newPosition).getIdSanPham());
                                giohang.setTen(datalist.get(newPosition).getTen());
                                giohang.setUrl(datalist.get(newPosition).getUrl());
                                giohang.setSoLuong(slhang);
                                giohang.setDonGia(datalist.get(newPosition).getDonGia());
                                giohang.setTongtien(datalist.get(newPosition).getDonGia()*(slhang));
                                KhachHangService.apiService.editGioHang(giohang).enqueue(new Callback<Boolean>() {
                                    @Override
                                    public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                        Intent intent = new Intent(activity, AddToCartActivity.class);
                                        activity.startActivity(intent);
                                    }
                                    @Override
                                    public void onFailure(Call<Boolean> call, Throwable t) {
                                    }
                                });
                            }
                        }else{
                            setAlertDialog("out of stock!","Info");
                        }
                    }
                    @Override
                    public void onFailure(Call<SanPham> call, Throwable t) {
                    }
                });
            }
        });
        //---
        holder.btnMin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Cart giohang = new Cart();
                Integer slhang = datalist.get(newPosition).getSoLuong()-1;
                if (slhang<1){
                    slhang=1;
                    new AlertDialog.Builder(activity)
                            .setTitle("Delete item")
                            .setMessage("Are you sure you want to delete this " + datalist.get(newPosition).getTen().trim() + " ?")
                            .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int which) {
                                    KhachHangService.apiService.deleteGioHang(datalist.get(newPosition).getId()).enqueue(new Callback<Boolean>() {
                                        @Override
                                        public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                            Intent intent = new Intent(activity, AddToCartActivity.class);
                                            activity.startActivity(intent);
                                        }

                                        @Override
                                        public void onFailure(Call<Boolean> call, Throwable t) {

                                        }
                                    });
                                }
                            })
                            .setNegativeButton(android.R.string.no, null)
                            .setIcon(android.R.drawable.ic_dialog_alert)
                            .show();

                }else{
                    giohang.setId(datalist.get(newPosition).getId());
                    giohang.setIdKhachHang(idKhachHang_);
                    giohang.setIdSanPham(datalist.get(newPosition).getIdSanPham());
                    giohang.setTen(datalist.get(newPosition).getTen());
                    giohang.setUrl(datalist.get(newPosition).getUrl());
                    giohang.setSoLuong(slhang);
                    giohang.setDonGia(datalist.get(newPosition).getDonGia());
                    giohang.setTongtien(datalist.get(newPosition).getDonGia()*(slhang));
                    KhachHangService.apiService.editGioHang(giohang).enqueue(new Callback<Boolean>() {
                        @Override
                        public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                            Intent intent = new Intent(activity, AddToCartActivity.class);
                            activity.startActivity(intent);
                        }

                        @Override
                        public void onFailure(Call<Boolean> call, Throwable t) {

                        }
                    });
                }
            }
        });

    }

    @Override
    public int getItemCount() {
        return datalist.size();
    }
    //-----
    private void setAlertDialog(String message,String kieu){
        AlertDialog.Builder adb = new AlertDialog.Builder(activity);
        if (kieu=="Info"){
            adb.setTitle("Infomation");
        }else{
            adb.setTitle("Error");
        }
        adb.setMessage(message);
        adb.setPositiveButton("Ok", null);
        adb.show();
    }
}
