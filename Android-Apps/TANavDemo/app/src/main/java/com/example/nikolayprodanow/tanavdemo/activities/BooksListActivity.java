package com.example.nikolayprodanow.tanavdemo.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.View;

import com.example.nikolayprodanow.tanavdemo.R;
import com.example.nikolayprodanow.tanavdemo.adapters.BooksListAdapter;
import com.example.nikolayprodanow.tanavdemo.adapters.IOnItemClicked;
import com.example.nikolayprodanow.tanavdemo.data.Data;
import com.example.nikolayprodanow.tanavdemo.models.Book;
import com.mikepenz.materialdrawer.Drawer;
import com.mikepenz.materialdrawer.DrawerBuilder;
import com.mikepenz.materialdrawer.model.DividerDrawerItem;
import com.mikepenz.materialdrawer.model.PrimaryDrawerItem;
import com.mikepenz.materialdrawer.model.SecondaryDrawerItem;

import java.util.List;

public class BooksListActivity extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_books_list);

    }



}
