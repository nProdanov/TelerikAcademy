package com.example.nikolayprodanow.softunidemo;

import android.graphics.Color;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.example.nikolayprodanow.softunidemo.models.Category;

import java.util.List;

/**
 * Created by nikolayprodanow on 1/29/17.
 */

public class MyRecyclerViewAdapter extends RecyclerView.Adapter<MyRecyclerViewAdapter.ViewHolder> {

    private static List<Category> mDataset;
    private static IOnItemClicked mCallback;

        public void setCallback(IOnItemClicked callback) {
        mCallback = callback;
    }

    public MyRecyclerViewAdapter(List<Category> data, IOnItemClicked callback) {
        this.mDataset = data;
        this.setCallback(callback);
    }

    public static class ViewHolder extends RecyclerView.ViewHolder {
        public TextView mTextTitle;
        public TextView mTextDescription;
        public ImageView mImage;
        public RelativeLayout mParent;

        public ViewHolder(View v) {
            super(v);

            mTextTitle = (TextView) v.findViewById(R.id.tv_title);
            mTextDescription = (TextView) v.findViewById(R.id.tv_description);
            mImage = (ImageView) v.findViewById(R.id.iv_row_view);
            mParent = (RelativeLayout) v.findViewById(R.id.rl_parent);

            mParent.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    if (mCallback != null){
                        mCallback.onItemSelectedEvent(getAdapterPosition());
                    }
                }
            });
        }
    }

    @Override
    public MyRecyclerViewAdapter.ViewHolder onCreateViewHolder(ViewGroup parent,
                                                               int viewType) {
        View v = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.recycler_view_row, parent, false);

        ViewHolder vh = new ViewHolder(v);
        return vh;
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {

        holder.mTextTitle.setText(mDataset.get(position).getmCategoryName());
        holder.mTextDescription.setText(mDataset.get(position).getmSubCategoryName());
        holder.mImage.setImageResource(mDataset.get(position).getmImageElementInMemory());
        holder.mParent.setBackgroundColor(Color.parseColor(mDataset.get(position).getmItemColor()));
    }

    @Override
    public int getItemCount() {
        return mDataset.size();
    }
}