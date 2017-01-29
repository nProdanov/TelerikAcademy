package com.example.nikolayprodanow.navdemoapp.fragments;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.provider.MediaStore;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;

import com.example.nikolayprodanow.navdemoapp.R;

/**
 * Created by nikolayprodanow on 1/28/17.
 */

public class StepOneFragment extends Fragment {

    Button mTakePhoto;
    ImageView mPhoto;

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Bundle extras = data.getExtras();
         Bitmap imageBitmap = (Bitmap) extras.get("data");
        if (requestCode == 1){
            mPhoto.setImageBitmap(imageBitmap);
        }
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_step_1, container, false);

        mPhoto = (ImageView) rootView.findViewById(R.id.iv_photo);
        mTakePhoto = (Button) rootView.findViewById(R.id.btn_take_photo);
        mTakePhoto.setOnClickListener(view -> {
            Intent takePhotoIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

            startActivityForResult(takePhotoIntent, 1);
        });

        return rootView;
    }
}
