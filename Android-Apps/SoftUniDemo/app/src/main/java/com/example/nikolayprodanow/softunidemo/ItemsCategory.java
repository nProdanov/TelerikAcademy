package com.example.nikolayprodanow.softunidemo;

import android.content.Intent;
import android.os.Bundle;
import android.os.Parcelable;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;

import com.example.nikolayprodanow.softunidemo.models.Category;
import com.example.nikolayprodanow.softunidemo.models.CategoryItems;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by nikolayprodanow on 1/29/17.
 */

public class ItemsCategory extends AppCompatActivity implements IOnItemClicked {
    private RecyclerView mRecyclerView;
    private RecyclerView.Adapter mAdapter;
    private RecyclerView.LayoutManager mLayoutManager;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        List<CategoryItems> selectedCategory = getIntent().getParcelableArrayListExtra("category_items");
        setTitle(getIntent().getStringExtra("category_name"));

        mRecyclerView = (RecyclerView) findViewById(R.id.rv_recycler);

        // use this setting to improve performance if you know that changes
        // in content do not change the layout size of the RecyclerView
        mRecyclerView.setHasFixedSize(true);

        // use a linear layout manager
        mLayoutManager = new LinearLayoutManager(this);
        mRecyclerView.setLayoutManager(mLayoutManager);


        // specify an adapter (see also next example)
        mAdapter = new SelectedCategoryAdapter(this, selectedCategory, this);
        mRecyclerView.setAdapter(mAdapter);
    }

    @Override
    public void onItemSelectedEvent(int position) {

    }
}
