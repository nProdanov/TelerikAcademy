package com.example.nikolayprodanow.tanavdemo.activities;

import android.content.Intent;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

import com.example.nikolayprodanow.tanavdemo.R;
import com.example.nikolayprodanow.tanavdemo.fragments.BookDetailsFragment;
import com.example.nikolayprodanow.tanavdemo.models.Book;

public class BooksDetailsActivity extends AppCompatActivity {


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_books_details);

        Intent intent = this.getIntent();

        Book book = intent.getParcelableExtra("book");

        BookDetailsFragment fragment = BookDetailsFragment.createFragment(book);

        this.getSupportFragmentManager()
                .beginTransaction()
                .add(R.id.container_fragment, fragment)
                .commit();
    }
}
