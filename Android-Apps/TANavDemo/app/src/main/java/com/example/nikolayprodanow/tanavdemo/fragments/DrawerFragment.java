package com.example.nikolayprodanow.tanavdemo.fragments;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.nikolayprodanow.tanavdemo.R;
import com.mikepenz.materialdrawer.Drawer;
import com.mikepenz.materialdrawer.DrawerBuilder;
import com.mikepenz.materialdrawer.model.PrimaryDrawerItem;
import com.mikepenz.materialdrawer.model.SecondaryDrawerItem;

/**
 * A simple {@link Fragment} subclass.
 */
public class DrawerFragment extends Fragment {


    public DrawerFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        View rootView = inflater.inflate(R.layout.fragment_drawer, container, false);

        return rootView;


    }

    @Override
    public void onStart() {
        super.onStart();

        this.setupDrawer();
    }

    protected void setupDrawer() {
        PrimaryDrawerItem item1 = new
                PrimaryDrawerItem()
                .withIdentifier(1)
                .withName(R.string.drawer_item_books);
        SecondaryDrawerItem item2 = new
                SecondaryDrawerItem()
                .withIdentifier(2)
                .withName(R.string.drawer_item_settings)
                .withIcon(R.drawable.material_drawer_circle_mask);


        Toolbar toolbar = (Toolbar) getActivity().findViewById(R.id.tb_drawer);

        Drawer drawer = new DrawerBuilder()
                .withActivity(getActivity())
                .withToolbar(toolbar)
                .addDrawerItems(
                        item1,
                        item2
                )
                .build();
    }


}
