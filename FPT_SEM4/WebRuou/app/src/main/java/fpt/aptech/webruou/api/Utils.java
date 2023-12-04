package fpt.aptech.webruou.api;

import android.content.Context;
import android.os.StrictMode;
import android.util.Base64;
import android.widget.Toast;

import java.security.InvalidAlgorithmParameterException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.util.Properties;
import java.util.Random;

import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

public class Utils {
    public static final String URL = "http://192.168.1.2:7134/api/";
    //public static final String URL = "http://192.168.1.139:7134/api/";
    //public static final String URL = "http://172.16.3.199:7134/api/";
    //-------------
    public static final String PASSWORDDEFAULT = "t6fPueiys3Y=";
    private static final String ALGORITHM ="Blowfish";
    private static final String MODE ="Blowfish/CBC/PKCS5Padding";
    private static final String IV ="abcdefgh";
    private static final String Key ="SECRETKEY";
    //-------------
    public void SendMail(Context context,String emailToSend, String subjectToSend, String messageToSend){
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        final String username="ngotranhunganh08@gmail.com";
        final String password="rskmoptqfqcacxvs";
        Properties properties = new Properties();
        properties.put("mail.smtp.auth","true");
        properties.put("mail.smtp.starttls.enable","true");
        properties.put("mail.smtp.host","smtp.gmail.com");
        properties.put("mail.smtp.port","587");
        Session session = Session.getInstance(properties,
                new javax.mail.Authenticator(){
                    @Override
                    protected PasswordAuthentication getPasswordAuthentication() {
                        return new PasswordAuthentication(username,password);
                    }
                });
        try {
            MimeMessage mes = new MimeMessage(session);
            mes.setFrom(new InternetAddress(username));
            mes.setRecipients(Message.RecipientType.TO,InternetAddress.parse(emailToSend));
            mes.setSubject(subjectToSend);
            mes.setText(messageToSend);
            Transport.send(mes);
            Toast.makeText(context, "Email send successfully", Toast.LENGTH_SHORT).show();
        }catch (MessagingException e){
            Toast.makeText(context, "Email send error", Toast.LENGTH_LONG).show();
            throw new RuntimeException(e);
        }
    }
    //-----
    public String RandomNumber(Integer size)
    {
        Random random = new Random();
        String ch = "";
        for (int i = 0; i < size; i++)
        {
            ch = ch + random.nextInt(9);
        }
        return ch.trim();
    }
    //-------------
    public String encrypt(String value) {
        SecretKeySpec secretKeySpec = new SecretKeySpec(Key.getBytes(),ALGORITHM);
        Cipher cipher = null;
        try {
            cipher = Cipher.getInstance(MODE);
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        } catch (NoSuchPaddingException e) {
            e.printStackTrace();
        }
        try {
            cipher.init(Cipher.ENCRYPT_MODE,secretKeySpec,new IvParameterSpec(IV.getBytes()));
        } catch (InvalidAlgorithmParameterException e) {
            e.printStackTrace();
        } catch (InvalidKeyException e) {
            e.printStackTrace();
        }
        byte[] values = new byte[0];
        try {
            values = cipher.doFinal(value.getBytes());
        } catch (BadPaddingException e) {
            e.printStackTrace();
        } catch (IllegalBlockSizeException e) {
            e.printStackTrace();
        }
        return Base64.encodeToString(values,Base64.DEFAULT).trim();
    }
    //-------------
    public String decrypt(String value) {
        byte[] values = Base64.decode(value,Base64.DEFAULT);
        SecretKeySpec secretKeySpec = new SecretKeySpec(Key.getBytes(),ALGORITHM);
        Cipher cipher = null;
        try {
            cipher = Cipher.getInstance(MODE);
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        } catch (NoSuchPaddingException e) {
            e.printStackTrace();
        }
        try {
            cipher.init(Cipher.DECRYPT_MODE,secretKeySpec,new IvParameterSpec(IV.getBytes()));
        } catch (InvalidAlgorithmParameterException e) {
            e.printStackTrace();
        } catch (InvalidKeyException e) {
            e.printStackTrace();
        }

        try {
            return new String(cipher.doFinal(values)).trim();
        } catch (BadPaddingException e) {
            e.printStackTrace();
        } catch (IllegalBlockSizeException e) {
            e.printStackTrace();
        }
        return "";
    }
    //-------------
//        datalist.forEach((e) -> {
//        });
}