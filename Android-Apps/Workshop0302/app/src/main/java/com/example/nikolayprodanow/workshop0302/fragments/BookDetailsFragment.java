package com.example.nikolayprodanow.workshop0302.fragments;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.nikolayprodanow.workshop0302.R;
import com.example.nikolayprodanow.workshop0302.fragments.tabs.BooksListTabFragment;
import com.example.nikolayprodanow.workshop0302.models.Book;

/**
 * A simple {@link Fragment} subclass.
 */
public class BookDetailsFragment extends Fragment {


    private TextView mTitleView;
    private TextView mAuthorView;
    private TextView mIsbnView;

    public BookDetailsFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_book_details, container, false);

        Bundle args = getArguments();
        Book book = args.getParcelable(BooksListTabFragment.BOOK_KEY);

        this.mTitleView = (TextView) rootView.findViewById(R.id.tv_title);
        this.mAuthorView= (TextView) rootView.findViewById(R.id.tv_author);
        this.mIsbnView = (TextView) rootView.findViewById(R.id.tv_isbn);


        this.mTitleView.setText(book.getTitle());
        this.mAuthorView.setText(book.getAuthor());
        this.mIsbnView.setText(book.getIsbn());
        return  rootView;
    }

}
