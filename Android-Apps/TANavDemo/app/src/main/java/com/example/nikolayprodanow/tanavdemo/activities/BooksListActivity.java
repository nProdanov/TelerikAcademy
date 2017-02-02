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

        this.setupDrawer();
    }

    protected void setupDrawer() {
        PrimaryDrawerItem item1 = new
                PrimaryDrawerItem()
                .withIdentifier(1)
                .withName(R.string.drawer_item_books)
                .withIcon(R.drawable.material_drawer_badge);
        SecondaryDrawerItem item2 = new
                SecondaryDrawerItem()
                .withIdentifier(2)
                .withName(R.string.drawer_item_settings)
                .withIcon(R.drawable.material_drawer_circle_mask);


        Toolbar toolbar = (Toolbar) this.findViewById(R.id.tb_drawer);

        Drawer result = new DrawerBuilder()
                .withActivity(this)
                .withToolbar(toolbar)
                .addDrawerItems(
                        item1,
                        item2
                )
                .build();
    }


}
