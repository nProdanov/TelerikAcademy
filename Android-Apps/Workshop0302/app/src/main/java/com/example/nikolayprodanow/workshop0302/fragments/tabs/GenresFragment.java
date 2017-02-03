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
public class GenresFragment extends Fragment {

    private static GenresFragment instance;

    public GenresFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_genres, container, false);


        return rootView;
    }

    public static GenresFragment getInstance() {
        if (instance == null) {
            instance = new GenresFragment();
        }

        return instance;
    }

}
