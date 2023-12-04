package fpt.aptech.webruou;

import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import fpt.aptech.webruou.api.KhachHangService;
import fpt.aptech.webruou.model.Cart;
import fpt.aptech.webruou.model.DonHang;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class PaymentActivity extends AppCompatActivity {
    //--- Bien luu Session
    Integer id_;
    String userName_;
    String email_;
    String password_;
    String address_;
    String phone_;
    Integer status_;
    //-----
    TextView txtBack, tvUserName, tvAddress, tvEmail, tvPhone, tvTongTien,tvPayment;
    EditText tvAccount,message;
    ImageView imgView;
    Spinner spbank;
    private Integer TongTien,SoLuong;
    ArrayList<String> arayString;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_payment);

        getSupportActionBar().hide();
        spbank = findViewById(R.id.spbank);
        tvUserName = findViewById(R.id.tvUserName);
        tvAddress = findViewById(R.id.tvAddress);
        tvEmail = findViewById(R.id.tvEmail);
        tvPhone = findViewById(R.id.tvPhone);
        tvAccount = findViewById(R.id.tvAccount);
        tvTongTien = findViewById(R.id.tvTongTien);
        message = findViewById(R.id.message);
        tvPayment = findViewById(R.id.tvPayment);
        imgView = findViewById(R.id.imgView);
        //---
        arayString = new ArrayList<String>();
        arayString.add("  Techcombank (khuyên dùng) ");
        arayString.add("  Sacombank    ");
        arayString.add("  BIDV         ");
        arayString.add("  ACB          ");
        //--
        ArrayAdapter arrayAdapter = new ArrayAdapter(this, R.layout.spin_bank,R.id.text,arayString);
        spbank.setAdapter(arrayAdapter);

        getSession();
        loadInfo();
        Payment();
        Back();
    }
    //-----
    private void Payment() {
        tvPayment.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Calendar c = Calendar.getInstance();
                Date date1 = c.getTime();
                c.add(Calendar.DAY_OF_YEAR, 7);
                Date date2 = c.getTime();
                SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
                String ngaydat = dateFormat.format(date1);
                String ngaygiao = dateFormat.format(date2);

                DonHang donHang = new DonHang();
                donHang.setIdKhachHang(id_);
                donHang.setDaThanhToan(true);
                donHang.setNgayDat(ngaydat);
                donHang.setNgayGiao(ngaygiao);
                donHang.setSoLuong(SoLuong);
                donHang.setTongTien(TongTien);
                donHang.setTrangThaiGH(0);
                KhachHangService.apiService.addDonHang(donHang).enqueue(new Callback<Boolean>() {
                    @Override
                    public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                        Toast.makeText(getApplicationContext(),"Order payment successful",Toast.LENGTH_LONG).show();
                        Intent intent = new Intent(getApplicationContext(),MainActivity.class);
                        startActivity(intent);
                    }
                    @Override
                    public void onFailure(Call<Boolean> call, Throwable t) {
                    }
                });
            }
        });
    }
    //-----
    private void loadInfo(){
        tvUserName.setText(userName_);
        tvAddress.setText(address_);
        tvEmail.setText(email_);
        tvPhone.setText(phone_);
        Intent intent = getIntent();
        TongTien = intent.getIntExtra("TongTien_", 0);
        SoLuong = intent.getIntExtra("SoLuong_", 0);

        DecimalFormat formatter = new DecimalFormat("#,###,###");
        tvTongTien.setText(formatter.format(TongTien)+" VNĐ");
        message.setText(userName_+" Payment orders");
    }
    //-----
    private void Back(){
        txtBack = findViewById(R.id.txtBack);
        txtBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(),AddToCartActivity.class);
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
        AlertDialog.Builder adb = new AlertDialog.Builder(this);
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