package com.example.nikolayprodanow.tanavdemo.adapters;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.nikolayprodanow.tanavdemo.R;
import com.example.nikolayprodanow.tanavdemo.models.Book;

import java.util.List;

/**
 * Created by nikolayprodanow on 2/2/17.
 */

public class BooksListAdapter extends RecyclerView.Adapter<BooksListAdapter.ViewHolder> {
    private List<Book> mBooksSet;
    private static IOnItemClicked mCallback;

    public static class ViewHolder extends RecyclerView.ViewHolder {
        public TextView mTvBookTitle;

        public ViewHolder(View v) {
            super(v);
            mTvBookTitle = (TextView) v.findViewById(R.id.tv_title);

            mTvBookTitle.setOnClickListener(view ->{
                if (mCallback != null){
                    mCallback.onItemClickedHandler(getAdapterPosition());
                }
            });
        }
    }

    public BooksListAdapter(List<Book> myDataset, IOnItemClicked callback) {
        mBooksSet = myDataset;
        mCallback = callback;
    }

    @Override
    public BooksListAdapter.ViewHolder onCreateViewHolder(ViewGroup parent,
                                                          int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.book_list_row, parent, false);
        ViewHolder vh = new ViewHolder(view);
        return vh;
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        holder.mTvBookTitle.setText(mBooksSet.get(position).getTitle());
    }

    @Override
    public int getItemCount() {
        return mBooksSet.size();
    }
}