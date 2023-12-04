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
import fpt.aptech.webruou.model.KhachHang;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ChangeInformationKhachHangActivity extends AppCompatActivity {
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
    private EditText email;
    private EditText address;
    private EditText phone;
    private Button btnChange;
    private Button btnBack;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_information_khach_hang);

        getSupportActionBar().hide();
        getSession();
        fullname = findViewById(R.id.fullname);
        email = findViewById(R.id.email);
        address = findViewById(R.id.address);
        phone = findViewById(R.id.phone);
        Back();
        LoadInfo();
        Change();
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
    private void Back() {
        btnBack = findViewById(R.id.btnBack);
        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(),MainActivity.class);
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
    private void LoadInfo() {
        KhachHangService.apiService.findOne(id_).enqueue(new Callback<KhachHang>() {
            @Override
            public void onResponse(Call<KhachHang> call, Response<KhachHang> response) {
                KhachHang varTable = response.body();
                fullname.setText(varTable.getUserName());
                email.setText(varTable.getEmail());
                address.setText(varTable.getAddress());
                phone.setText(varTable.getPhone());
            }
            @Override
            public void onFailure(Call<KhachHang> call, Throwable t) {
                Toast.makeText(getApplicationContext(),"Update Error...",Toast.LENGTH_LONG).show();
                Intent intent = new Intent(getApplicationContext(),MainActivity.class);
                startActivity(intent);
            }
        });
    }
    //-----
    private void Change() {
        btnChange = findViewById(R.id.btnChange);
        btnChange.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (fullname.getText().toString().equals("")){
                    setAlertDialog("Fullname is required...","Error");
                    fullname.requestFocus();
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
                // Change Information
                KhachHang varTable = new KhachHang();
                varTable.setId(id_);
                varTable.setUserName(fullname.getText().toString());
                varTable.setPassword(password_);
                varTable.setEmail(email.getText().toString());
                varTable.setAddress(address.getText().toString());
                varTable.setPhone(phone.getText().toString());
                varTable.setStatus(status_);
                // Kiem tra trung email
                KhachHangService.apiService.findEmail(varTable.getEmail()).enqueue(new Callback<KhachHang>() {
                    @Override
                    public void onResponse(Call<KhachHang> call, Response<KhachHang> response) {
                        KhachHang varTable1 = response.body();
                        if (varTable1!=null){
                            if (!varTable.getEmail().trim().equals(email_)){
                                setAlertDialog("Email address already in use!","Error");
                                email.requestFocus();
                                return;
                            }
                        }
                        KhachHangService.apiService.editTable(varTable).enqueue(new Callback<Boolean>() {
                            @Override
                            public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                if (response.body()){
                                    Toast.makeText(getApplicationContext(),"Change Information Sucsess",Toast.LENGTH_SHORT).show();
                                    if (varTable1!=null){
                                        setSession(varTable);
                                        Intent intent = new Intent(getApplicationContext(),MainActivity.class);
                                        startActivity(intent);
                                    }else{
                                        MoveSession();
                                        Intent intent = new Intent(getApplicationContext(), LoginKhachHangActivity.class);
                                        startActivity(intent);
                                    }
                                }else{
                                    Toast.makeText(getApplicationContext(),"Change Information fail",Toast.LENGTH_LONG).show();
                                }
                            }
                            @Override
                            public void onFailure(Call<Boolean> call, Throwable t) {
                                Toast.makeText(getApplicationContext(),"Change Information Error...",Toast.LENGTH_LONG).show();
                            }
                        });
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