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
import fpt.aptech.webruou.model.DetailsDonHang;
import fpt.aptech.webruou.model.DonHang;
import fpt.aptech.webruou.model.ListDetailsDonHangAdapter;
import fpt.aptech.webruou.model.ListDonHangAdapter;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ListDetailsDonHangActivity extends AppCompatActivity {
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
    List<DetailsDonHang> datalist;
    Integer iddonhang_;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_details_don_hang);
        getSupportActionBar().hide();

        getSession();
        Back();
        listView=findViewById(R.id.listView);

        Intent intent = getIntent();
        iddonhang_ = intent.getIntExtra("iddonhang_", 0);

        SearchView();
    }
    //-----
    private void Back(){
        txtBack = findViewById(R.id.txtBack);
        txtBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent =  new Intent(getApplicationContext(),ListDonHangActivity.class);
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
        KhachHangService.apiService.detailsDonHang(iddonhang_).enqueue(new Callback<List<DetailsDonHang>>() {
            @Override
            public void onResponse(Call<List<DetailsDonHang>> call, Response<List<DetailsDonHang>> response) {
                datalist= response.body();
                ListDetailsDonHangAdapter adapter = new ListDetailsDonHangAdapter(ListDetailsDonHangActivity.this,datalist);
                listView.setAdapter(adapter);
            }

            @Override
            public void onFailure(Call<List<DetailsDonHang>> call, Throwable t) {
                Toast.makeText(getApplicationContext(),"Load data error",Toast.LENGTH_LONG).show();
            }
        });
    }
}