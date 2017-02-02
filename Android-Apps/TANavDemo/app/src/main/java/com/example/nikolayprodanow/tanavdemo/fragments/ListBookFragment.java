package com.example.nikolayprodanow.tanavdemo.fragments;


import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.nikolayprodanow.tanavdemo.R;
import com.example.nikolayprodanow.tanavdemo.activities.BooksDetailsActivity;
import com.example.nikolayprodanow.tanavdemo.adapters.BooksListAdapter;
import com.example.nikolayprodanow.tanavdemo.adapters.IOnItemClicked;
import com.example.nikolayprodanow.tanavdemo.data.Data;
import com.example.nikolayprodanow.tanavdemo.models.Book;

import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 */
public class ListBookFragment extends Fragment implements IOnItemClicked {

    private RecyclerView mRecyclerView;
    private RecyclerView.Adapter mAdapter;
    private RecyclerView.LayoutManager mLayoutManager;
    private List<Book> mBooks;

    public ListBookFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_list_book, container, false);

        Data data = new Data();
        mRecyclerView = (RecyclerView) rootView.findViewById(R.id.rv_books_list);

        mRecyclerView.setHasFixedSize(true);

        mLayoutManager = new LinearLayoutManager(rootView.getContext());
        mRecyclerView.setLayoutManager(mLayoutManager);

        mBooks = data.getBooks();
        mAdapter = new BooksListAdapter(mBooks, this);
        mRecyclerView.setAdapter(mAdapter);
        return rootView;
    }

    @Override
    public void onItemClickedHandler(int position) {
        Intent intent = new Intent(this.getActivity(), BooksDetailsActivity.class);
        intent.putExtra("book", mBooks.get(position));
        this.startActivity(intent);
    }

}
