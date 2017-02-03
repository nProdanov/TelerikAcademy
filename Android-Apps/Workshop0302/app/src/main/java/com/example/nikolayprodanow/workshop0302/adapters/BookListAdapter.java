package com.example.nikolayprodanow.workshop0302.adapters;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextClock;
import android.widget.TextView;

import com.example.nikolayprodanow.workshop0302.R;
import com.example.nikolayprodanow.workshop0302.interfaces.IOnItemClickHandler;
import com.example.nikolayprodanow.workshop0302.models.Book;

import java.util.List;

/**
 * Created by nikolayprodanow on 2/3/17.
 */

public class BookListAdapter extends RecyclerView.Adapter<BookListAdapter.ViewHolder> {
    private List<Book> mDataset;
    static IOnItemClickHandler mCallback;

    public static class ViewHolder extends RecyclerView.ViewHolder {
        private TextView mTitleText;
        private TextView mAuthorText;
        private LinearLayout mParent;

        public ViewHolder(View v) {
            super(v);
            this.mTitleText = (TextView) v.findViewById(R.id.tv_title);
            this.mAuthorText= (TextView) v.findViewById(R.id.tv_author);

            this.mParent = (LinearLayout) v.findViewById(R.id.parent_layout);
            mParent.setOnClickListener(view ->{
                if (mCallback != null){
                    mCallback.onItemClickHandle(getAdapterPosition());
                }
            });
        }
    }

    public BookListAdapter(List<Book> myDataset, IOnItemClickHandler callback) {
        mDataset = myDataset;
        mCallback = callback;
    }

    @Override
    public BookListAdapter.ViewHolder onCreateViewHolder(ViewGroup parent,
                                                         int viewType) {
        View v = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.current_book_row, parent, false);
        ViewHolder vh = new ViewHolder(v);

        return vh;
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        Book book = this.mDataset.get(position);
        holder.mTitleText.setText(book.getTitle());
        holder.mAuthorText.setText(book.getAuthor());
    }

    @Override
    public int getItemCount() {
        return mDataset.size();
    }
}

