package fpt.aptech.webruou.model;

import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import fpt.aptech.webruou.R;

public class CartViewHolder extends RecyclerView.ViewHolder {
    ImageView imageview;
    TextView ten,dongia,txtSoluong;
    Button btnMin,btnMax;
    public CartViewHolder(@NonNull View itemView) {
        super(itemView);
        imageview = itemView.findViewById(R.id.imageview);
        ten = itemView.findViewById(R.id.ten);
        dongia = itemView.findViewById(R.id.dongia);
        txtSoluong = itemView.findViewById(R.id.txtSoluong);
        btnMin = itemView.findViewById(R.id.btnMin);
        btnMax = itemView.findViewById(R.id.btnMax);
    }
}
