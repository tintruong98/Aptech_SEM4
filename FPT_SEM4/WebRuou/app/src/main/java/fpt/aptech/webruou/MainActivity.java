package fpt.aptech.webruou;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

import fpt.aptech.webruou.api.KhachHangService;
import fpt.aptech.webruou.model.Cart;
import fpt.aptech.webruou.model.DonHang;
import fpt.aptech.webruou.model.KhachHang;
import fpt.aptech.webruou.model.SanPham;
import fpt.aptech.webruou.model.SanPhamAdapter;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {
    //--- Bien luu Session
    Integer id_;
    String userName_;
    String email_;
    String password_;
    String address_;
    String phone_;
    Integer status_;

    //---
    TextView txtLogin, txtXemDonhang, txtCancel, txtGiohang;
    EditText editSearch;
    ImageView imgGiohang,imgSearch;
    LinearLayout menu;
    LinearLayout imageHome;
    RecyclerView recyclerviewSP;
    Spinner spLogin;
    ArrayList<String> arayLogin;
    List<SanPham> datalist;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        getSupportActionBar().hide();

        getSession();

        spLogin = findViewById(R.id.spLogin);
        txtLogin = findViewById(R.id.txtLogin);
        txtXemDonhang = findViewById(R.id.txtXemDonhang);
        txtCancel = findViewById(R.id.txtCancel);
        txtGiohang = findViewById(R.id.txtGiohang);
        imgGiohang = findViewById(R.id.imgGiohang);
        imgSearch  = findViewById(R.id.imgSearch);
        editSearch = findViewById(R.id.editSearch);
        menu = findViewById(R.id.menu);
        imageHome = findViewById(R.id.imageHome);
        recyclerviewSP = findViewById(R.id.recyclerviewSP);

        arayLogin = new ArrayList<String>();
        arayLogin.add("  "+userName_+"  ");
        arayLogin.add("  Change the pasword  ");
        arayLogin.add("  Change information  ");
        arayLogin.add("  Logout              ");
        arayLogin.add("  Exit                ");
        ArrayAdapter arrayAdapter = new ArrayAdapter(this, R.layout.spin_login,R.id.text,arayLogin);
        spLogin.setAdapter(arrayAdapter);

        if (userName_.isEmpty()){
            txtLogin.setVisibility(View.VISIBLE);
            spLogin.setVisibility(View.GONE);
            menu.setVisibility(View.GONE);
            imageHome.setVisibility(View.VISIBLE);
            recyclerviewSP.setVisibility(View.GONE);
        }else{
            txtLogin.setVisibility(View.GONE);
            spLogin.setVisibility(View.VISIBLE);
            menu.setVisibility(View.VISIBLE);
            imageHome.setVisibility(View.GONE);
            recyclerviewSP.setVisibility(View.VISIBLE);
            ViewSanPham();
            CountCart();
            Cancel();
        }

//            KhachHangService.apiService.countSanPham(1,1).enqueue(new Callback<Cart>() {
//            @Override
//            public void onResponse(Call<Cart> call, Response<Cart> response) {
//                Cart varTable = response.body();
//                Toast.makeText(MainActivity.this,varTable.getSoLuong().toString(),Toast.LENGTH_SHORT).show();
//            }
//
//            @Override
//            public void onFailure(Call<Cart> call, Throwable t) {
//
//            }
//        });

        Login();
        spLogin();
        XemDonhang();
        XemGiohang();
        Search();
    }
    //-----
    private void Search() {
        imgSearch.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent=new Intent(MainActivity.this,MainActivity.class);
                String searchsanpham = editSearch.getText().toString().trim();
                intent.putExtra("searchsanpham",searchsanpham);
                startActivity(intent);
            }
        });
    }
    //-----
    private void Cancel() {
        txtCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent=new Intent(MainActivity.this,CancelOrderActivity.class);
                startActivity(intent);
            }
        });
    }
    //-----
    private void XemGiohang() {
        imgGiohang.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent=new Intent(MainActivity.this,AddToCartActivity.class);
                startActivity(intent);
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
                    txtGiohang.setText("0");
                }else{
                    txtGiohang.setText(countcart.getSoLuong().toString());
                }
            }

            @Override
            public void onFailure(Call<Cart> call, Throwable t) {
                Toast.makeText(getApplicationContext(),"Load data error",Toast.LENGTH_LONG).show();
            }
        });
    }
    //-----
    private void ViewSanPham(){
        Intent intent = getIntent();
        String searchsanpham;
        if (intent.getStringExtra("searchsanpham")==null){
            searchsanpham="";
        }else{
            searchsanpham = intent.getStringExtra("searchsanpham");
        }
        if (searchsanpham.isEmpty() || searchsanpham.equals("")){
            KhachHangService.apiService.findSanPhamAll().enqueue(new Callback<List<SanPham>>() {
                @Override
                public void onResponse(Call<List<SanPham>> call, Response<List<SanPham>> response) {
                    datalist= response.body();
                    LinearLayoutManager layoutManager =
                            new LinearLayoutManager(MainActivity.this, LinearLayoutManager.VERTICAL, false);

                    RecyclerView recyclerView = findViewById(R.id.recyclerviewSP);
                    recyclerView.setLayoutManager(layoutManager);
                    recyclerView.setAdapter(new SanPhamAdapter(MainActivity.this,datalist,id_));
                }

                @Override
                public void onFailure(Call<List<SanPham>> call, Throwable t) {
                    Toast.makeText(getApplicationContext(),"Load data error",Toast.LENGTH_LONG).show();
                }
            });
        }
        else{
            KhachHangService.apiService.SearchSanPham(searchsanpham).enqueue(new Callback<List<SanPham>>() {
                @Override
                public void onResponse(Call<List<SanPham>> call, Response<List<SanPham>> response) {
                    datalist= response.body();
                    LinearLayoutManager layoutManager =
                            new LinearLayoutManager(MainActivity.this, LinearLayoutManager.VERTICAL, false);

                    RecyclerView recyclerView = findViewById(R.id.recyclerviewSP);
                    recyclerView.setLayoutManager(layoutManager);
                    recyclerView.setAdapter(new SanPhamAdapter(MainActivity.this,datalist,id_));
                }
                @Override
                public void onFailure(Call<List<SanPham>> call, Throwable t) {
                    Toast.makeText(getApplicationContext(),"Load data error",Toast.LENGTH_LONG).show();
                }
            });
        }
    }
    //-----
    private void XemDonhang() {
        txtXemDonhang.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                KhachHangService.apiService.listDonHang(id_).enqueue(new Callback<List<DonHang>>() {
                    @Override
                    public void onResponse(Call<List<DonHang>> call, Response<List<DonHang>> response) {
                        if(response.body().size()>0){
                            Intent intent=new Intent(MainActivity.this,ListDonHangActivity.class);
                            startActivity(intent);
                        }
                        else{
                            setAlertDialog("You do not have any orders in the system. Please place an order and create a new order!","Info");
                        }
                    }

                    @Override
                    public void onFailure(Call<List<DonHang>> call, Throwable t) {
                        Toast.makeText(getApplicationContext(),"Load data error",Toast.LENGTH_LONG).show();
                    }
                });
            }
        });
    }
    //-----
    private void Login() {
        txtLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent=new Intent(MainActivity.this,LoginKhachHangActivity.class);
                startActivity(intent);
            }
        });
    }
    //-----
    private void spLogin() {
        spLogin.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                Intent intent;
                switch (i){
                    case 0:
                        break;
                    case 1:
                        intent=new Intent(MainActivity.this, ChangePasswordKhachHangActivity.class);
                        startActivity(intent);
                        break;
                    case 2:
                        intent=new Intent(MainActivity.this, ChangeInformationKhachHangActivity.class);
                        startActivity(intent);
                        break;
                    case 3:
                        MoveSession();
                        intent=new Intent(MainActivity.this,MainActivity.class);
                        startActivity(intent);
                        break;
                    case 4:
                        finishAffinity();
                        System.exit(0);
                        break;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {}
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
    private void MoveSession(){
        SharedPreferences sharedPreferences = getSharedPreferences("KhachHangInfo", Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.remove("id_");
        editor.remove("userName_");
        editor.remove("email_");
        editor.remove("password_");
        editor.remove("address_");
        editor.remove("phone_");
        editor.remove("status_");
        editor.clear();
        editor.apply();
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
    //-----
}