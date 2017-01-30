package com.example.nikolayprodanow.softunidemo;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Parcelable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;

import com.example.nikolayprodanow.softunidemo.models.Category;
import com.example.nikolayprodanow.softunidemo.models.CategoryItems;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends Activity implements IOnItemClicked {

    private RecyclerView mRecyclerView;
    private RecyclerView.Adapter mAdapter;
    private RecyclerView.LayoutManager mLayoutManager;
    private List<Category> myDataset;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle(R.string.menu);

        this.mRecyclerView = (RecyclerView) findViewById(R.id.rv_recycler);

        this.mRecyclerView.setHasFixedSize(true);

        this.mLayoutManager = new LinearLayoutManager(this);
        this.mRecyclerView.setLayoutManager(this.mLayoutManager);

         myDataset = Category.listAll(Category.class);

        this.mAdapter = new MyRecyclerViewAdapter(myDataset, this);
        this.mRecyclerView.setAdapter(this.mAdapter);
    }

    @Override
    public void onItemSelectedEvent(int position) {
        Intent intent = new Intent(MainActivity.this, ItemsCategory.class);

        Category category = myDataset.get(position);

        List<CategoryItems> items = category.getAllItemsCategory();

        intent.putExtra("category_name", category.getmCategoryName());

        intent.putParcelableArrayListExtra("category_items", (ArrayList<? extends Parcelable>) items);

        startActivity(intent);
    }
}
