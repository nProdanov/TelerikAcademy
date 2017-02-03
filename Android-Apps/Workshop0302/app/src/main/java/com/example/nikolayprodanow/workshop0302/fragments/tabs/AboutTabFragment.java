package com.example.nikolayprodanow.workshop0302.fragments.tabs;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.nikolayprodanow.workshop0302.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class AboutTabFragment extends Fragment {


    private static AboutTabFragment instance;

    public AboutTabFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_about_tab, container, false);
    }

    public static AboutTabFragment getInstance(){
        if(instance == null){
            instance = new AboutTabFragment();
        }

        return  instance;
    }
}
