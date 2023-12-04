package fpt.aptech.webruou.model;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.text.DecimalFormat;
import java.util.List;

import fpt.aptech.webruou.ListDetailsDonHangActivity;
import fpt.aptech.webruou.ListDonHangActivity;
import fpt.aptech.webruou.R;
import fpt.aptech.webruou.api.KhachHangService;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ListDonHangAdapter extends BaseAdapter {
    Activity activity;
    List<DonHangImage> datalist;

    public ListDonHangAdapter(Activity activity, List<DonHangImage> datalist) {
        this.activity = activity;
        this.datalist = datalist;
    }

    @Override
    public int getCount() {
        return datalist.size();
    }

    @Override
    public Object getItem(int i) {
        return datalist.get(i);
    }

    @Override
    public long getItemId(int i) {
        return datalist.get(i).getId();
    }

    //----- DETAILS co bao nhieu doi tuong thi khai bao bay nhieu trong CustomeView
    public static class CustomeView{
        TextView tvId;
        TextView tvNgayDat;
        TextView tvNgayGiao;
        TextView tvSoluong;
        TextView tvTongTien;
        TextView tvTrangThaiGH;
        ImageView imageView;
        TextView tvViewDetails;
    }
    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        View dataView;
        CustomeView customeView;
        LayoutInflater inflater = activity.getLayoutInflater();
        if (view==null){
            customeView=new CustomeView();
            dataView=inflater.inflate(R.layout.details_donhang,null,true);

            customeView.tvId=dataView.findViewById(R.id.tvId);
            customeView.tvNgayDat=dataView.findViewById(R.id.tvNgayDat);
            customeView.tvNgayGiao=dataView.findViewById(R.id.tvNgayGiao);
            customeView.tvSoluong=dataView.findViewById(R.id.tvSoluong);
            customeView.tvTongTien=dataView.findViewById(R.id.tvTongTien);
            customeView.tvTrangThaiGH=dataView.findViewById(R.id.tvTrangThaiGH);
            customeView.tvViewDetails=dataView.findViewById(R.id.tvViewDetails);
            customeView.imageView=dataView.findViewById(R.id.imageView);

            dataView.setTag(customeView);
        }else{
            customeView=(CustomeView) view.getTag();
            dataView = view;
        }
        DecimalFormat formatter = new DecimalFormat("#,###,###");

        customeView.tvId.setText(String.valueOf(datalist.get(i).getId()));
        customeView.tvNgayDat.setText(datalist.get(i).getNgayDat().substring(0,10));
        customeView.tvNgayGiao.setText(datalist.get(i).getNgayGiao().substring(0,10));
        customeView.tvSoluong.setText(formatter.format(datalist.get(i).getSoLuong()));
        customeView.tvTongTien.setText(formatter.format(datalist.get(i).getTongTien())+" VNĐ");

        String cnvImages = datalist.get(i).getUrl().trim().substring(7);
        cnvImages = cnvImages.substring(0,cnvImages.length()-4);
        int imgID = activity.getResources().getIdentifier(cnvImages, "drawable", activity.getApplicationContext().getPackageName());
        customeView.imageView.setImageResource(imgID);


        if (datalist.get(i).getTrangThaiGH()==0){
            customeView.tvTrangThaiGH.setText("Preparing");
        }
        if (datalist.get(i).getTrangThaiGH()==1){
            customeView.tvTrangThaiGH.setText("Delivering");
        }
        if (datalist.get(i).getTrangThaiGH()==2){
            customeView.tvTrangThaiGH.setText("Delivered");
        }
        if (datalist.get(i).getTrangThaiGH()==3){
            customeView.tvTrangThaiGH.setText("Reject");
        }
        final int newPosition=i;
        final int idDonHang_=datalist.get(i).getId();

        //----- Xem chi tiet don hang
        customeView.tvViewDetails.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                KhachHangService.apiService.detailsDonHang(idDonHang_).enqueue(new Callback<List<DetailsDonHang>>() {
                    @Override
                    public void onResponse(Call<List<DetailsDonHang>> call, Response<List<DetailsDonHang>> response) {
                        if (response.body().size()>0){
                            Intent intent=new Intent(activity, ListDetailsDonHangActivity.class);
                            intent.putExtra("iddonhang_", datalist.get(newPosition).getId());
                            activity.startActivity(intent);
                        }
                        else{
                            setAlertDialog("Orders have no products!","Info");
                        }
                    }
                    @Override
                    public void onFailure(Call<List<DetailsDonHang>> call, Throwable t) {
                        Toast.makeText(activity,"Load data error",Toast.LENGTH_LONG).show();
                    }
                });
            }
        });
        //-----
        return dataView;
    }
    //-----
    private void setAlertDialog(String message,String kieu){
        AlertDialog.Builder adb = new AlertDialog.Builder(activity);
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
