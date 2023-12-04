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

public class ResetPasswordKhachHangActivity extends AppCompatActivity {
    TextView txtNext,txtLogin,txtBack;
    EditText txtEmail;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reset_password_khach_hang);

        getSupportActionBar().hide();
        //-----
        Back();Login();Next();
        txtEmail.requestFocus();
    }
    //-----
    private void Back() {
        txtBack = findViewById(R.id.txtBack);
        txtBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(), LoginKhachHangActivity.class);
                startActivity(intent);
            }
        });
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
    private void Next() {
        txtEmail = findViewById(R.id.txtEmail);
        txtNext = findViewById(R.id.txtNext);
        txtNext.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String emailToSend = txtEmail.getText().toString().trim();
                if (!(emailToSend.matches("[a-zA-Z0-9._-]+@[a-z]+\\.+[a-z]+") && emailToSend.length() > 0)){
                    setAlertDialog("Invalid Email...","Error");
                    txtEmail.requestFocus();
                    return;
                }
                //-----
                KhachHangService.apiService.findEmail(emailToSend).enqueue(new Callback<KhachHang>() {
                    @Override
                    public void onResponse(Call<KhachHang> call, Response<KhachHang> response) {
                        KhachHang varTable = response.body();
                        if (varTable==null){
                            setAlertDialog("Email not found on system!!!","Error");
                            txtEmail.requestFocus();
                            return;
                        }else{
                            Utils utils = new Utils();
                            String m_Email = emailToSend;
                            String m_Token = utils.RandomNumber(6);

                            String subjectToSend = "Password recovery";
                            String messageToSend = "Hello "+varTable.getUserName().trim()+
                                    " You have sent a password reset request to the system."+
                                    "Please enter the code "+m_Token+" on the ForgotPassword page to recover your password";

                            utils.SendMail(getApplicationContext(),emailToSend,subjectToSend,messageToSend);

                            Intent intent = new Intent(getApplicationContext(), ForgotPasswordKhachHangActivity.class);
                            intent.putExtra("m_Email", m_Email);
                            intent.putExtra("m_Token", m_Token);
                            startActivity(intent);
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