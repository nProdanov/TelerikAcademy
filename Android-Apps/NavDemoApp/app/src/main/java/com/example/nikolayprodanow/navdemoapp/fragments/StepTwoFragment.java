package com.example.nikolayprodanow.navdemoapp.fragments;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.example.nikolayprodanow.navdemoapp.R;
import com.example.nikolayprodanow.navdemoapp.services.MyService;

/**
 * Created by nikolayprodanow on 1/28/17.
 */

public class StepTwoFragment extends Fragment {

    Button mStartService, mStopService;
    Intent mServiceIntent;
    Activity mActivity;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_step_2, container, false);

        mStartService = (Button) rootView.findViewById(R.id.btn_start_service);
        mStopService = (Button) rootView.findViewById(R.id.btn_stop_service);
        mServiceIntent = new Intent(getActivity(), MyService.class);
        mActivity = getActivity();

        mStartService.setOnClickListener(view -> mActivity.startService(mServiceIntent));
        mStopService.setOnClickListener(view -> mActivity.stopService(mServiceIntent));

        return rootView;
    }
}
