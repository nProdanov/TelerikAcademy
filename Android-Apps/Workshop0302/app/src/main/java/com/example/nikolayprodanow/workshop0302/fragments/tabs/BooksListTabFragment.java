package com.example.nikolayprodanow.workshop0302.fragments.tabs;


import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.example.nikolayprodanow.workshop0302.R;
import com.example.nikolayprodanow.workshop0302.activities.BookDetailsActivity;
import com.example.nikolayprodanow.workshop0302.adapters.BookListAdapter;
import com.example.nikolayprodanow.workshop0302.interfaces.IOnItemClickHandler;
import com.example.nikolayprodanow.workshop0302.models.Book;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

/**
 * A simple {@link Fragment} subclass.
 */
public class BooksListTabFragment extends Fragment implements IOnItemClickHandler {

    private static BooksListTabFragment instance;

    private OkHttpClient mHttpclient;

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

        ProgressDialog mDialog = new ProgressDialog(this.getContext());
        mDialog.setMessage("Wait please");
        mDialog.setCancelable(false);
        mDialog.show();

        new PerformHttpAsyncTask((String result) ->{
            mDialog.hide();
            Toast.makeText(this.getContext(), result, Toast.LENGTH_SHORT).show();
        })
        .execute("http://192.168.0.103:3001/api/books");


        return rootView;
    }

    private List<Book> generateBooks(){
        mBooks.add()
        return  books;
    }

    @Override
    public void onItemClickHandle(int position) {
        Book bookToSend = this.mBooks.get(position);
        Intent intent = new Intent(this.getActivity(), BookDetailsActivity.class);

        intent.putExtra(BOOK_KEY, bookToSend);

        this.startActivity(intent);
    }

    class PerformHttpAsyncTask extends AsyncTask<String, String, String> {

        private final OkHttpClient okHttpClient;
        private final IOnPostExecutedFinished mOnPostExecuteFinished;

        public PerformHttpAsyncTask(IOnPostExecutedFinished onPostExecuteFinished){
            this.okHttpClient = new OkHttpClient();
            this.mOnPostExecuteFinished = onPostExecuteFinished;
        }

        @Override
        protected String doInBackground(String... params) {
            String url = params[0];
            Request request = new Request.Builder()
                    .url(url)
                    .build();

            try {
                Response response = this.okHttpClient.newCall(request).execute();
                return  response.body().string();
            } catch (IOException e) {
                e.printStackTrace();
            }
            return  "";
        }


        @Override
        protected void onPostExecute(String json) {
            this.mOnPostExecuteFinished.call(json);
            //Update the UI
        }
    }

    public interface IOnPostExecutedFinished{
        void call(String json);
    }
}
