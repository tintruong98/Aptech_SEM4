package fpt.aptech.webruou.model;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import fpt.aptech.webruou.R;

public class SanPhamViewHolder extends RecyclerView.ViewHolder {
    ImageView imageview,imgthemgiohang;
    TextView name,description,price,soluong,themgiohang;
    public SanPhamViewHolder(@NonNull View itemView) {
        super(itemView);
        imageview = itemView.findViewById(R.id.imageview);
        name = itemView.findViewById(R.id.name);
        description = itemView.findViewById(R.id.description);
        price = itemView.findViewById(R.id.price);
        soluong = itemView.findViewById(R.id.soluong);
        themgiohang = itemView.findViewById(R.id.themgiohang);
        imgthemgiohang = itemView.findViewById(R.id.imgthemgiohang);
    }
}
