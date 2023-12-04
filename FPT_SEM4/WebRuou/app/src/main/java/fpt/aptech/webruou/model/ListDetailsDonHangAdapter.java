package fpt.aptech.webruou.model;

import android.app.Activity;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.text.DecimalFormat;
import java.util.List;

import fpt.aptech.webruou.ListDetailsDonHangActivity;
import fpt.aptech.webruou.R;

public class ListDetailsDonHangAdapter extends BaseAdapter {
    Activity activity;
    List<DetailsDonHang> datalist;

    public ListDetailsDonHangAdapter(Activity activity, List<DetailsDonHang> datalist) {
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
        return datalist.get(i).getIdSanPham();
    }
    //----- DETAILS co bao nhieu doi tuong thi khai bao bay nhieu trong CustomeView
    public static class CustomeView{
        ImageView imgViewAll;
        TextView tvidDonHang;
        TextView tvidSanPham;
        TextView tvname;
        TextView tvdescription;
        TextView tvsoLuong;
        TextView tvgiaTien;
        TextView tvthanhTien;
        TextView tvpromotion;
    }
    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        View dataView;
        ListDetailsDonHangAdapter.CustomeView customeView;
        LayoutInflater inflater = activity.getLayoutInflater();
        if (view==null){
            customeView=new ListDetailsDonHangAdapter.CustomeView();
            dataView=inflater.inflate(R.layout.details_chitietdonhang,null,true);

            customeView.imgViewAll=dataView.findViewById(R.id.imgViewAll);
            customeView.tvidDonHang=dataView.findViewById(R.id.tvidDonHang);
            customeView.tvidSanPham=dataView.findViewById(R.id.tvidSanPham);
            customeView.tvname=dataView.findViewById(R.id.tvname);
            customeView.tvdescription=dataView.findViewById(R.id.tvdescription);
            customeView.tvsoLuong=dataView.findViewById(R.id.tvsoLuong);
            customeView.tvgiaTien=dataView.findViewById(R.id.tvgiaTien);
            customeView.tvthanhTien=dataView.findViewById(R.id.tvthanhTien);
            customeView.tvpromotion=dataView.findViewById(R.id.tvpromotion);

            dataView.setTag(customeView);
        }else{
            customeView=(ListDetailsDonHangAdapter.CustomeView) view.getTag();
            dataView = view;
        }
        DecimalFormat formatter = new DecimalFormat("#,###,###");

        String cnvImages = datalist.get(i).getUrlImage().trim().substring(7);
        cnvImages = cnvImages.substring(0,cnvImages.length()-4);

        int imgID = activity.getResources().getIdentifier(cnvImages, "drawable", activity.getApplicationContext().getPackageName());
        customeView.imgViewAll.setImageResource(imgID);
        customeView.tvidDonHang.setText(String.valueOf(datalist.get(i).getIdDonHang()));
        customeView.tvidSanPham.setText(String.valueOf(datalist.get(i).getIdSanPham()));
        customeView.tvname.setText(datalist.get(i).getName());
        customeView.tvdescription.setText(datalist.get(i).getDescription());
        customeView.tvsoLuong.setText(formatter.format(datalist.get(i).getSoLuong()));
        customeView.tvgiaTien.setText(formatter.format(datalist.get(i).getGiaTien())+" VND");
        customeView.tvthanhTien.setText(formatter.format(datalist.get(i).getThanhTien())+" VND");
        customeView.tvpromotion.setText(String.valueOf(datalist.get(i).getPromotion())+"%");

        final int newPosition=i;
        //-----
        return dataView;
    }
}
