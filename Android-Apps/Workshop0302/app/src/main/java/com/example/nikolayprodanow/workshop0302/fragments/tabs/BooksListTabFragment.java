package com.example.nikolayprodanow.workshop0302.fragments.tabs;


import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.nikolayprodanow.workshop0302.R;
import com.example.nikolayprodanow.workshop0302.activities.BookDetailsActivity;
import com.example.nikolayprodanow.workshop0302.adapters.BookListAdapter;
import com.example.nikolayprodanow.workshop0302.interfaces.IOnItemClickHandler;
import com.example.nikolayprodanow.workshop0302.models.Book;

import java.util.ArrayList;
import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 */
public class BooksListTabFragment extends Fragment implements IOnItemClickHandler {

    private static BooksListTabFragment instance;

    public static String BOOK_KEY = "book";

    private RecyclerView mRecyclerView;
    private RecyclerView.Adapter mAdapter;
    private RecyclerView.LayoutManager mLayoutManager;

    private List<Book> mBooks;

    public BooksListTabFragment() {
        // Required empty public constructor
    }

    public static BooksListTabFragment getInstance() {
        if (instance == null) {
            instance = new BooksListTabFragment();
        }

        return instance;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_books_list, container, false);

        if (instance == null) {
            instance = this;
        }

        mRecyclerView = (RecyclerView) rootView.findViewById(R.id.my_recycler_view);

        mRecyclerView.setHasFixedSize(true);

        mLayoutManager = new LinearLayoutManager(rootView.getContext());
        mRecyclerView.setLayoutManager(mLayoutManager);

        mBooks = this.generateBooks();

        mAdapter = new BookListAdapter(mBooks, this);
        mRecyclerView.setAdapter(mAdapter);

        return rootView;
    }

    private List<Book> generateBooks(){
        List<Book> books = new ArrayList<>();

        books.add(new Book("King Rat", "James Clavell", "12345678"));
        books.add(new Book("Shogun", "James Clavell", "132456789"));
        books.add(new Book("East of eden", "John Steinbeck", "14345678"));

        return  books;
    }

    @Override
    public void onItemClickHandle(int position) {
        Book bookToSend = this.mBooks.get(position);
        Intent intent = new Intent(this.getActivity(), BookDetailsActivity.class);

        intent.putExtra(BOOK_KEY, bookToSend);

        this.startActivity(intent);
    }
}
