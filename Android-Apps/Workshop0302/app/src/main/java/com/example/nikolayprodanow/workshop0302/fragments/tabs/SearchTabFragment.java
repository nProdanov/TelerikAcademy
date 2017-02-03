package com.example.nikolayprodanow.workshop0302.fragments.tabs;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;

import com.example.nikolayprodanow.workshop0302.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class SearchTabFragment extends Fragment {

    private static SearchTabFragment instance;
    private EditText mSearchText;

    public SearchTabFragment() {
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_search_tab, container, false);

        this.mSearchText = (EditText) rootView.findViewById(R.id.et_search_box);
        return rootView;
    }

    public static SearchTabFragment getInstance() {
        if (instance == null) {
            instance = new SearchTabFragment();
        }

        return instance;
    }


}
