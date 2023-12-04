package fpt.aptech.webruou;

import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.content.Intent;
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

public class ForgotPasswordKhachHangActivity extends AppCompatActivity {
    String m_Email;
    String m_Token;

    private EditText txtToken,newpassword,confirmpassword;
    private TextView txtEmail,txtChange,txtLogin,txtBack;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_forgot_password_khach_hang);

        getSupportActionBar().hide();

        Intent intent = getIntent();
        m_Email = intent.getStringExtra("m_Email");
        m_Token = intent.getStringExtra("m_Token");

        Back();Login();Change();
        txtEmail.setText(m_Email);
        txtToken.requestFocus();
    }
    //-----
    private void Login() {
        txtLogin = findViewById(R.id.txtLogin);
        txtLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(), LoginKhachHangActivity.class);
                startActivity(intent);
            }
        });
    }
    //-----
    private void Back() {
        txtBack = findViewById(R.id.txtBack);
        txtBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(), ResetPasswordKhachHangActivity.class);
                startActivity(intent);
            }
        });
    }
    //-----
    private void setAlertDialog(String message,String kieu){
        AlertDialog.Builder adb = new AlertDialog.Builder(this);
        if (kieu=="Info"){
            adb.setTitle("Info");
        }else{
            adb.setTitle("Error");
        }
        adb.setMessage(message);
        adb.setPositiveButton("Ok", null);
        adb.show();
    }
    //-----
    private void Change() {
        txtEmail = findViewById(R.id.txtEmail);
        txtToken = findViewById(R.id.txtToken);
        newpassword = findViewById(R.id.newpassword);
        confirmpassword = findViewById(R.id.confirmpassword);
        txtChange = findViewById(R.id.txtChange);
        txtChange.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (!txtToken.getText().toString().trim().equals(m_Token)){
                    setAlertDialog("Invalid Code Token...","Error");
                    txtToken.requestFocus();
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
                KhachHangService.apiService.findEmail(m_Email).enqueue(new Callback<KhachHang>() {
                    @Override
                    public void onResponse(Call<KhachHang> call, Response<KhachHang> response) {
                        KhachHang varTable = response.body();
                        if (varTable==null){
                            setAlertDialog("Email not found on system!!!","Error");
                            newpassword.requestFocus();
                            return;
                        }else{
                            varTable.setPassword(newpassword.getText().toString());

                            Utils utils = new Utils();
                            //varTable.setPassword(utils.encrypt(varTable.getPassword().trim()));

                            KhachHangService.apiService.editTable(varTable).enqueue(new Callback<Boolean>() {
                                @Override
                                public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                    if (response.body()){
                                        Toast.makeText(getApplicationContext(),"Change Password Sucsess",Toast.LENGTH_SHORT).show();
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