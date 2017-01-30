package com.example.nikolayprodanow.softunidemo;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.example.nikolayprodanow.softunidemo.models.CategoryItems;
import com.squareup.picasso.Picasso;

import java.text.NumberFormat;
import java.util.Currency;
import java.util.List;

/**
 * Created by nikolayprodanow on 1/29/17.
 */
public class SelectedCategoryAdapter extends RecyclerView.Adapter<SelectedCategoryAdapter.ViewHolder> {
    public static Context mCtx;

    private static List<CategoryItems> mDataset;
    private static IOnItemClicked mCallback;

    public SelectedCategoryAdapter(Context ctx, List<CategoryItems> data, IOnItemClicked callback) {
        mDataset = data;
        mCtx = ctx;
        mCallback = callback;
    }

    @Override
    public SelectedCategoryAdapter.ViewHolder onCreateViewHolder(ViewGroup parent,
                                                                 int viewType) {
        View v = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.selected_item_view_row_layout, parent, false);

        SelectedCategoryAdapter.ViewHolder vh = new SelectedCategoryAdapter.ViewHolder(v);

        return vh;
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        holder.mTextItemName.setText(mDataset.get(position).getmItemTitle());
        holder.mTextItemSubName.setText(mDataset.get(position).getmItemDescription());
        holder.mTextCategoryName.setText(mDataset.get(position).getmItemCategoryIdentifier());

        NumberFormat format = NumberFormat.getCurrencyInstance();
        double price = Double.parseDouble(mDataset.get(position).getmItemPrice());
        holder.mTextPrice.setText(format.format(price));

        Picasso
                .with(mCtx)
                .load(mDataset.get(position).getmImageURI())
                .into(holder.mImageViewSelectedPicture);
    }

    @Override
    public int getItemCount() {
        return mDataset.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {
        public TextView mTextItemName, mTextItemSubName, mTextCategoryName, mTextPrice;
        public LinearLayout mLinearLayoutParent;
        public ImageView mImageViewSelectedPicture;

        public ViewHolder(View v) {
            super(v);

            mTextItemName = (TextView) v.findViewById(R.id.textView);
            mTextItemSubName = (TextView) v.findViewById(R.id.textView2);
            mTextCategoryName = (TextView) v.findViewById(R.id.textView3);
            mTextPrice = (TextView) v.findViewById(R.id.textView4);

            mLinearLayoutParent = (LinearLayout) v.findViewById(R.id.rl_parent);
            mImageViewSelectedPicture = (ImageView) v.findViewById(R.id.imageView);

            mLinearLayoutParent.setOnClickListener(this);
        }

        @Override
        public void onClick(View v) {
            if (mCallback != null){
                mCallback.onItemSelectedEvent(this.getAdapterPosition());
            }
        }
    }

}
