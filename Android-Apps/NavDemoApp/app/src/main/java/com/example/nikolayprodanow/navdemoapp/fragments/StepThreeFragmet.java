package com.example.nikolayprodanow.navdemoapp.fragments;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.nikolayprodanow.navdemoapp.R;

/**
 * Created by nikolayprodanow on 1/28/17.
 */

public class StepThreeFragmet extends Fragment {
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_step_3, container, false);

        return  rootView;
    }
}
