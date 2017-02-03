package com.example.nikolayprodanow.workshop0302.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

import com.example.nikolayprodanow.workshop0302.R;
import com.example.nikolayprodanow.workshop0302.fragments.BookDetailsFragment;
import com.example.nikolayprodanow.workshop0302.fragments.tabs.BooksListTabFragment;
import com.example.nikolayprodanow.workshop0302.models.Book;

public class BookDetailsActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_books_details);

        Intent intent = getIntent();

        Book book = intent.getParcelableExtra(BooksListTabFragment.BOOK_KEY);

        BookDetailsFragment fragment = new BookDetailsFragment();

        Bundle bundle = new Bundle();
        bundle.putParcelable(BooksListTabFragment.BOOK_KEY, book);

        fragment.setArguments(bundle);

        this.getSupportFragmentManager()
                .beginTransaction()
                .add(R.id.fragment_container, fragment)
                .commit();
    }
}
