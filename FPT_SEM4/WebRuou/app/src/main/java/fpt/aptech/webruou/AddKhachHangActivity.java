package fpt.aptech.webruou;

import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.List;

import fpt.aptech.webruou.api.KhachHangService;
import fpt.aptech.webruou.api.Utils;
import fpt.aptech.webruou.model.KhachHang;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AddKhachHangActivity extends AppCompatActivity {
    //--- Bien luu Session
    Integer id_;
    String userName_;
    String email_;
    String password_;
    String address_;
    String phone_;
    Integer status_;
    //-----
    private EditText fullname;
    private EditText password;
    private EditText email;
    private EditText address;
    private EditText phone;
    private Button btnCreate;
    private Button btnBack;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_khach_hang);

        getSupportActionBar().hide();
        getSession();
        if (!userName_.isEmpty()){
            Toast.makeText(getApplicationContext(),"You are logged in with your account "+userName_,Toast.LENGTH_SHORT).show();
            Intent intent = new Intent(getApplicationContext(), MainActivity.class);
            startActivity(intent);
        }
        Back();
        Create();
        fullname.requestFocus();
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
    private void Back(){
        btnBack = findViewById(R.id.btnBack);
        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent =  new Intent(AddKhachHangActivity.this,LoginKhachHangActivity.class);
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
    private void Create() {
        fullname = findViewById(R.id.fullname);
        password = findViewById(R.id.password);
        email = findViewById(R.id.email);
        address = findViewById(R.id.address);
        phone = findViewById(R.id.phone);
        btnCreate = findViewById(R.id.btnCreate);
        btnCreate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (fullname.getText().toString().equals("")){
                    setAlertDialog("Fullname is required...","Error");
                    fullname.requestFocus();
                    return;
                }
                if (password.getText().toString().equals("")){
                    setAlertDialog("Password is required...","Error");
                    password.requestFocus();
                    return;
                }
                String varLocal = email.getText().toString().trim();
                if (!(varLocal.matches("[a-zA-Z0-9._-]+@[a-z]+\\.+[a-z]+") && varLocal.length() > 0)){
                    setAlertDialog("Invalid Email...","Error");
                    email.requestFocus();
                    return;
                }
                if (address.getText().toString().equals("")){
                    setAlertDialog("Address is required...","Error");
                    address.requestFocus();
                    return;
                }
                if (phone.getText().toString().equals("")){
                    setAlertDialog("Phone is required...","Error");
                    address.requestFocus();
                    return;
                }
                // Add new
                KhachHang varTable = new KhachHang();
                varTable.setUserName(fullname.getText().toString());
                varTable.setPassword(password.getText().toString());
                varTable.setEmail(email.getText().toString());
                varTable.setAddress(address.getText().toString());
                varTable.setPhone(phone.getText().toString());
                varTable.setStatus(1);
                // Kiem tra trung email
                KhachHangService.apiService.findEmail(varTable.getEmail()).enqueue(new Callback<KhachHang>() {
                    @Override
                    public void onResponse(Call<KhachHang> call, Response<KhachHang> response) {
                        KhachHang varTable1 = response.body();
                        if (varTable1!=null){
                            setAlertDialog("Email address already in use!","Error");
                            email.requestFocus();
                            return;
                        }
                        else{
                            Utils utils = new Utils();
                            //varTable.setPassword(utils.encrypt(varTable.getPassword().trim()));
                            KhachHangService.apiService.addTable(varTable).enqueue(new Callback<Boolean>() {
                                @Override
                                public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                    if (response.body()){
                                        Toast.makeText(AddKhachHangActivity.this,"Add new Sucsess",Toast.LENGTH_SHORT).show();
                                        Intent intent = new Intent(getApplicationContext(), LoginKhachHangActivity.class);
                                        startActivity(intent);
                                    }else{
                                        Toast.makeText(getApplicationContext(),"Add new fail",Toast.LENGTH_LONG).show();
                                    }
                                }
                                @Override
                                public void onFailure(Call<Boolean> call, Throwable t) {
                                    Toast.makeText(getApplicationContext(),"Add new Error...",Toast.LENGTH_LONG).show();
                                }
                            });
                        }
                    }
                    @Override
                    public void onFailure(Call<KhachHang> call, Throwable t) {
                        Toast.makeText(getApplicationContext(),"Search email fail",Toast.LENGTH_LONG).show();
                        return;
                    }
                });
            }
        });
    }
}