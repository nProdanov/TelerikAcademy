package com.example.nikolayprodanow.tanavdemo.fragments;


import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.nikolayprodanow.tanavdemo.R;
import com.example.nikolayprodanow.tanavdemo.activities.BooksDetailsActivity;
import com.example.nikolayprodanow.tanavdemo.models.Book;

/**
 * A simple {@link Fragment} subclass.
 */
public class BookDetailsFragment extends Fragment {

    TextView mTvTitle, mTvIsbn;


    public BookDetailsFragment() {
        // Required empty public constructor
    }


    public static BookDetailsFragment createFragment(Book book) {
        Bundle bundle = new Bundle();
        bundle.putParcelable("book", book);
        BookDetailsFragment fragment = new BookDetailsFragment();
        fragment.setArguments(bundle);
        return fragment;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_book_details, container, false);

        Bundle arguments = this.getArguments();
        mTvTitle = (TextView) rootView.findViewById(R.id.tv_title);
        mTvIsbn = (TextView) rootView.findViewById(R.id.tb_isbn);

        if (arguments != null) {
            Book book = arguments.getParcelable("book");

            mTvTitle.setText(book.getTitle());
            mTvIsbn.setText(book.getIsbn());
        }

        return rootView;
    }

}
