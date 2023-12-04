package fpt.aptech.webruou;

import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import fpt.aptech.webruou.api.KhachHangService;
import fpt.aptech.webruou.api.Utils;
import fpt.aptech.webruou.model.KhachHang;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginKhachHangActivity extends AppCompatActivity {
    //--- Bien luu Session
    Integer id_;
    String userName_;
    String email_;
    String password_;
    String address_;
    String phone_;
    Integer status_;
    //-----
    private EditText txtEmail;
    private EditText txtPassword;
    private TextView btnLogin;
    private TextView btnBack;
    private TextView registry,forgot;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_khach_hang);
        getSupportActionBar().hide();

        getSession();
        checkLogin();
        Back();
        registry();
        forgot();
        txtEmail.requestFocus();
    }
    //-----
    private void Back(){
        btnBack = findViewById(R.id.btnBack);
        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent =  new Intent(LoginKhachHangActivity.this,MainActivity.class);
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
    private void setSession(KhachHang varTable){
        SharedPreferences  sharedPreferences = getSharedPreferences("KhachHangInfo", Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.putInt("id_", varTable.getId());
        editor.putString("userName_", varTable.getUserName());
        editor.putString("email_", varTable.getEmail());
        editor.putString("password_", varTable.getPassword());
        editor.putString("address_", varTable.getAddress());
        editor.putString("phone_", varTable.getPhone());
        editor.putInt("status_", varTable.getStatus());
        editor.commit();
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
    private void checkLogin(){
        txtEmail = findViewById(R.id.txtEmail);
        txtPassword = findViewById(R.id.txtPassword);
        btnLogin = findViewById(R.id.btnLogin);
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String varLocal1 = txtEmail.getText().toString().trim();
                String varLocal2 = txtPassword.getText().toString().trim();
                if (!(varLocal1.matches("[a-zA-Z0-9._-]+@[a-z]+\\.+[a-z]+") && varLocal1.length() > 0)){
                    setAlertDialog("Invalid Email...","Error");
                    txtEmail.requestFocus();
                    return;
                }
                if (varLocal2.equals("")){
                    setAlertDialog("Password is required...","Error");
                    txtPassword.requestFocus();
                    return;
                }
                Utils utils = new Utils();
                //String mahoa=utils.encrypt(varLocal2).trim();
                String mahoa=varLocal2;
                KhachHangService.apiService.checkLogin(varLocal1,mahoa).enqueue(new Callback<KhachHang>() {
                    @Override
                    public void onResponse(Call<KhachHang> call, Response<KhachHang> response) {
                        KhachHang varTable = response.body();
                        if (varTable!=null){
                            setSession(varTable);
                            Toast.makeText(LoginKhachHangActivity.this,"Login Success",Toast.LENGTH_SHORT).show();
                            Intent intent =  new Intent(LoginKhachHangActivity.this,MainActivity.class);
                            startActivity(intent);
                        }else{
                            setAlertDialog("Invalid Email or Password...","Error");
                            txtEmail.requestFocus();
                            return;
                        }
                    }

                    @Override
                    public void onFailure(Call<KhachHang> call, Throwable t) {
                        Toast.makeText(LoginKhachHangActivity.this,"Login Error",Toast.LENGTH_LONG).show();
                    }
                });
            }
        });
    }
    //-----
    private void registry(){
        registry = findViewById(R.id.registry);
        registry.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (!userName_.isEmpty()){
                    setAlertDialog("Please logout before registering an account!","Infomation");
                    return;
                }
                Intent intent =  new Intent(LoginKhachHangActivity.this, AddKhachHangActivity.class);
                startActivity(intent);
            }
        });
    }
    //-----
    private void forgot() {
        forgot = findViewById(R.id.forgot);
        forgot.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent =  new Intent(LoginKhachHangActivity.this, ResetPasswordKhachHangActivity.class);
                startActivity(intent);
            }
        });
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

    //-----
}