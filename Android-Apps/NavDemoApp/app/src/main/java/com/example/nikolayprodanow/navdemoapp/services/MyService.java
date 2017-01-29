package com.example.nikolayprodanow.navdemoapp.services;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.support.annotation.Nullable;
import android.widget.Toast;

/**
 * Created by nikolayprodanow on 1/28/17.
 */

public class MyService extends Service {

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        super.onStartCommand(intent, flags, startId);

        Toast
                .makeText(this, "Service started", Toast.LENGTH_LONG)
                .show();
        return START_STICKY;
    }

    @Override
    public void onDestroy() {
        super.onDestroy();

        Toast
                .makeText(this, "Service stopped", Toast.LENGTH_SHORT)
                .show();
    }
}
