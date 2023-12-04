package fpt.aptech.webruou;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.List;

import fpt.aptech.webruou.api.KhachHangService;
import fpt.aptech.webruou.model.DonHang;
import fpt.aptech.webruou.model.DonHangImage;
import fpt.aptech.webruou.model.ListHuyDonHangAdapter;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class CancelOrderActivity extends AppCompatActivity {
    //--- Bien luu Session
    Integer id_;
    String userName_;
    String email_;
    String password_;
    String address_;
    String phone_;
    Integer status_;
    //-----
    TextView txtBack;
    ListView listView;
    List<DonHangImage> datalist;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cancel_order);

        getSupportActionBar().hide();
        getSession();
        Back();
        listView=findViewById(R.id.listView);
        SearchView();
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
    private void SearchView(){
        KhachHangService.apiService.listHuyDonHangImage(id_).enqueue(new Callback<List<DonHangImage>>() {
            @Override
            public void onResponse(Call<List<DonHangImage>> call, Response<List<DonHangImage>> response) {
                datalist= response.body();
                ListHuyDonHangAdapter adapter = new ListHuyDonHangAdapter(CancelOrderActivity.this,datalist);
                listView.setAdapter(adapter);
            }
            @Override
            public void onFailure(Call<List<DonHangImage>> call, Throwable t) {
                Toast.makeText(getApplicationContext(),"Load data error",Toast.LENGTH_LONG).show();
            }
        });
    }
}