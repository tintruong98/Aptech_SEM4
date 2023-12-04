package fpt.aptech.webruou;

import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import fpt.aptech.webruou.api.KhachHangService;
import fpt.aptech.webruou.api.Utils;
import fpt.aptech.webruou.model.KhachHang;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ChangePasswordKhachHangActivity extends AppCompatActivity {
    //--- Bien luu Session
    Integer id_;
    String userName_;
    String email_;
    String password_;
    String address_;
    String phone_;
    Integer status_;
    //-----
    private EditText oldpassword;
    private EditText newpassword;
    private EditText confirmpassword;

    private Button btnChange;
    private Button btnBack;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_password_khach_hang);

        getSupportActionBar().hide();
        getSession();
        Back();
        Change();
        oldpassword.requestFocus();
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
    private void Change() {
        oldpassword = findViewById(R.id.oldpassword);
        newpassword = findViewById(R.id.newpassword);
        confirmpassword = findViewById(R.id.confirmpassword);
        btnChange = findViewById(R.id.btnChange);
        btnChange.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (oldpassword.getText().toString().equals("")){
                    setAlertDialog("Old password is required...","Error");
                    oldpassword.requestFocus();
                    return;
                }
                if (newpassword.getText().toString().equals("")){
                    setAlertDialog("New password is required...","Error");
                    newpassword.requestFocus();
                    return;
                }
                if (confirmpassword.getText().toString().equals("")){
                    setAlertDialog("Confirm password is required...","Error");
                    confirmpassword.requestFocus();
                    return;
                }
                if (!newpassword.getText().toString().equals(confirmpassword.getText().toString())){
                    setAlertDialog("New password and confirmation Password is not the same...","Error");
                    newpassword.requestFocus();
                    return;
                }
                // Change password
                Utils utils = new Utils();
                //String mahoa = utils.encrypt(oldpassword.getText().toString().trim());
                String mahoa = oldpassword.getText().toString().trim();
                KhachHangService.apiService.checkLogin(email_,mahoa).enqueue(new Callback<KhachHang>() {
                    @Override
                    public void onResponse(Call<KhachHang> call, Response<KhachHang> response) {
                        KhachHang varTable = response.body();
                        if (varTable!=null){
                            varTable.setPassword(newpassword.getText().toString().trim());

                            Toast.makeText(getApplicationContext(),varTable.getPassword(),Toast.LENGTH_SHORT).show();

                            //varTable.setPassword(utils.encrypt(varTable.getPassword().trim()));

                            KhachHangService.apiService.editTable(varTable).enqueue(new Callback<Boolean>() {
                                @Override
                                public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                    if (response.body()){
                                        MoveSession();
                                        Toast.makeText(ChangePasswordKhachHangActivity.this,"Change Password Sucsess",Toast.LENGTH_SHORT).show();
                                        Intent intent = new Intent(getApplicationContext(), LoginKhachHangActivity.class);
                                        startActivity(intent);
                                    }else{
                                        Toast.makeText(getApplicationContext(),"Change Password fail",Toast.LENGTH_LONG).show();
                                    }
                                }
                                @Override
                                public void onFailure(Call<Boolean> call, Throwable t) {
                                    Toast.makeText(getApplicationContext(),"Change Password Error...",Toast.LENGTH_LONG).show();
                                }
                            });
                        }else{
                            setAlertDialog("Invalid old password ...","Error");
                            newpassword.requestFocus();
                            return;
                        }
                    }
                    @Override
                    public void onFailure(Call<KhachHang> call, Throwable t) {
                        Toast.makeText(getApplicationContext(),"Change password fail",Toast.LENGTH_LONG).show();
                    }
                });
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
}