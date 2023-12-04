package fpt.aptech.webruou.model;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import java.text.DecimalFormat;
import java.util.List;
import fpt.aptech.webruou.AddToCartActivity;
import fpt.aptech.webruou.LoginKhachHangActivity;
import fpt.aptech.webruou.MainActivity;
import fpt.aptech.webruou.R;
import fpt.aptech.webruou.api.KhachHangService;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class SanPhamAdapter extends RecyclerView.Adapter<SanPhamViewHolder> {
    Activity activity;
    List<SanPham> datalist;
    Integer idKhachHang_;

    public SanPhamAdapter(Activity activity , List<SanPham> datalist, int idKhachHang_) {
        this.activity = activity;
        this.datalist = datalist;
        this.idKhachHang_ =idKhachHang_;
    }

    @NonNull
    @Override
    public SanPhamViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        return new SanPhamViewHolder(LayoutInflater.from(activity).inflate(R.layout.item_view_sanpham,parent,false));
    }

    @Override
    public void onBindViewHolder(@NonNull SanPhamViewHolder holder, int position) {

        DecimalFormat formatter = new DecimalFormat("#,###,###");

        String cnvImages = datalist.get(position).getUrlImage().trim().substring(7);
        cnvImages = cnvImages.substring(0,cnvImages.length()-4);

        int imgID = activity.getResources().getIdentifier(cnvImages, "drawable", activity.getApplicationContext().getPackageName());

        holder.imageview.setImageResource(imgID);
        holder.name.setText(datalist.get(position).getName());
        holder.description.setText(datalist.get(position).getDescription());
        holder.price.setText(formatter.format(datalist.get(position).getPrice())+" VND");
        holder.soluong.setText(formatter.format(datalist.get(position).getSoluong())+" products left");
        final int newPosition=position;

        holder.imgthemgiohang.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                KhachHangService.apiService.countSanPham(idKhachHang_,datalist.get(newPosition).getId()).enqueue(new Callback<Cart>() {
                    @Override
                    public void onResponse(Call<Cart> call, Response<Cart> response) {
                        Integer slhang = 1;
                        Cart giohang = new Cart();
                        if (response.body()==null){
                            slhang = 1;
                        }
                        else{
                            slhang = response.body().getSoLuong()+1;
                            giohang.setId(response.body().getId());
                        }
                        if (datalist.get(newPosition).getSoluong()>=slhang){
                            giohang.setIdKhachHang(idKhachHang_);
                            giohang.setIdSanPham(datalist.get(newPosition).getId());
                            giohang.setTen(datalist.get(newPosition).getName());
                            giohang.setUrl(datalist.get(newPosition).getUrlImage());
                            giohang.setSoLuong(slhang);
                            giohang.setDonGia(datalist.get(newPosition).getPrice());
                            giohang.setTongtien(datalist.get(newPosition).getPrice()*(slhang));
                            if (slhang==1){
                                KhachHangService.apiService.addGioHang(giohang).enqueue(new Callback<Boolean>() {
                                    @Override
                                    public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                    }

                                    @Override
                                    public void onFailure(Call<Boolean> call, Throwable t) {
                                    }
                                });
                            }else{
                                KhachHangService.apiService.editGioHang(giohang).enqueue(new Callback<Boolean>() {
                                    @Override
                                    public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                    }
                                    @Override
                                    public void onFailure(Call<Boolean> call, Throwable t) {
                                    }
                                });
                            }
                            Intent intent = new Intent(activity, AddToCartActivity.class);
                            activity.startActivity(intent);
                        }
                        else{
                            setAlertDialog("out of stock!","Info");
                        }
                    }
                    @Override
                    public void onFailure(Call<Cart> call, Throwable t) {
                    }
                });
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
