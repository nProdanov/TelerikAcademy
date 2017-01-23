package com.example.nikolayprodanow.myapplication;

import android.app.Activity;
import android.os.Bundle;
import android.os.StrictMode;
import android.widget.TextView;

/**
 * Created by nikolayprodanow on 1/22/17.
 */

public class SecondActivity extends Activity {

    TextView recieved;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.second_activity_layout);

        recieved = (TextView) findViewById(R.id.textView);

        String name = this.getIntent().getStringExtra("NAME");
        String id = this.getIntent().getStringExtra("ID");

        recieved.setText(String.format("Name: %s, ID: %s", name, id));
    }
}
