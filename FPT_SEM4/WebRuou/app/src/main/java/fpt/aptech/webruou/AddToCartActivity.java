package fpt.aptech.webruou;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.text.DecimalFormat;
import java.util.List;

import fpt.aptech.webruou.api.KhachHangService;
import fpt.aptech.webruou.model.Cart;
import fpt.aptech.webruou.model.CartAdapter;
import fpt.aptech.webruou.model.DetailsDonHang;
import fpt.aptech.webruou.model.ListDetailsDonHangAdapter;
import fpt.aptech.webruou.model.SanPham;
import fpt.aptech.webruou.model.SanPhamAdapter;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AddToCartActivity extends AppCompatActivity {
    //--- Bien luu Session
    Integer id_;
    String userName_;
    String email_;
    String password_;
    String address_;
    String phone_;
    Integer status_;
    //-----
    TextView txtBack,tvTongTien;
    TextView tvempty;
    Button btnThanhtoan;
    List<Cart> datalist;
    RecyclerView recyclerviewCart;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_to_cart);

        getSupportActionBar().hide();
        tvTongTien = findViewById(R.id.tvTongTien);
        btnThanhtoan = findViewById(R.id.btnThanhtoan);
        tvempty = findViewById(R.id.tvempty);
        recyclerviewCart = findViewById(R.id.recyclerviewCart);
        getSession();
        Back();
        ViewGiohang();
        CountCart();
        Thanhtoan();
    }
    //-----
    private void Thanhtoan() {
        btnThanhtoan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                KhachHangService.apiService.countCart(id_).enqueue(new Callback<Cart>() {
                    @Override
                    public void onResponse(Call<Cart> call, Response<Cart> response) {
                        Cart countcart = response.body();
                        Intent intent =  new Intent(getApplicationContext(),PaymentActivity.class);
                        intent.putExtra("TongTien_",countcart.getTongtien() );
                        intent.putExtra("SoLuong_",countcart.getSoLuong() );
                        startActivity(intent);
                    }
                    @Override
                    public void onFailure(Call<Cart> call, Throwable t) {
                    }
                });
            }
        });
    }
    //-----
    private void CountCart() {
        KhachHangService.apiService.countCart(id_).enqueue(new Callback<Cart>() {
            @Override
            public void onResponse(Call<Cart> call, Response<Cart> response) {
                Cart countcart = response.body();
                if (countcart==null){
                    tvTongTien.setText("0 VND");
                }else{
                    DecimalFormat formatter = new DecimalFormat("#,###,###");
                    tvTongTien.setText(formatter.format(countcart.getTongtien())+" VND");
                }
            }

            @Override
            public void onFailure(Call<Cart> call, Throwable t) {
                Toast.makeText(getApplicationContext(),"Load data error",Toast.LENGTH_LONG).show();
            }
        });
    }
    //-----
    private void ViewGiohang(){
        KhachHangService.apiService.listCartAll(id_).enqueue(new Callback<List<Cart>>() {
            @Override
            public void onResponse(Call<List<Cart>> call, Response<List<Cart>> response) {
                datalist= response.body();
                if (datalist==null || datalist.size()==0){
                    btnThanhtoan.setEnabled(false);
                    tvempty.setVisibility(View.VISIBLE);
                }
                else{
                    btnThanhtoan.setEnabled(true);
                    tvempty.setVisibility(View.GONE);
                }
                LinearLayoutManager layoutManager =
                        new LinearLayoutManager(AddToCartActivity.this, LinearLayoutManager.VERTICAL, false);

                RecyclerView recyclerView = findViewById(R.id.recyclerviewCart);
                recyclerView.setLayoutManager(layoutManager);
                recyclerView.setAdapter(new CartAdapter(AddToCartActivity.this,datalist,id_));
            }

            @Override
            public void onFailure(Call<List<Cart>> call, Throwable t) {
                Toast.makeText(getApplicationContext(),"Load data error",Toast.LENGTH_LONG).show();
            }
        });
    }
    //-----
    private void Back(){
        txtBack = findViewById(R.id.txtBack);
        txtBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent =  new Intent(getApplicationContext(),MainActivity.class);
                startActivity(intent);
            }
        });
    }
    //-----
    private void getSession(){
        SharedPreferences sharedPreferences = getSharedPreferences("KhachHangInfo", Context.MODE_PRIVATE);
        id_ = sharedPreferences.getInt("id_",0);
        userName_ = sharedPreferences.getString("userName_","");
        email_ = sharedPreferences.getString("email_","");
        password_ = sharedPreferences.getString("password_","");
        address_ = sharedPreferences.getString("address_","");
        phone_ = sharedPreferences.getString("phone_","");
        status_ = sharedPreferences.getInt("status_",0);
    }
    //-----
    private void setAlertDialog(String message,String kieu){
        AlertDialog.Builder adb = new AlertDialog.Builder(AddToCartActivity.this);
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