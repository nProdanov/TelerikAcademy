package com.example.nikolayprodanow.myapplication;

import android.app.Activity;
import android.app.SearchManager;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity implements View.OnClickListener {

    Button nik, ivan, pen;
    TextView info;
    int lastPressed;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        nik = (Button) findViewById(R.id.button);
        ivan = (Button) findViewById(R.id.button2);
        pen = (Button) findViewById(R.id.button3);
        info = (TextView) findViewById(R.id.textView);

        nik.setOnClickListener(this);
        ivan.setOnClickListener(this);
        pen.setOnClickListener(this);
        info.setOnClickListener(this);

        lastPressed = -1;
    }

    @Override
    public void onClick(View v) {
        if (v instanceof Button){
            if (v.getId() == lastPressed){
                info.setText(((Button) v).getText());
            }
            else {
                info.setText(String.valueOf(v.getId()));
            }

            lastPressed = v.getId();
        }
        else if(v instanceof TextView){
            Intent intent = new Intent(MainActivity.this, SecondActivity.class);

            intent.putExtra("ID", String.valueOf(lastPressed));
            intent.putExtra("NAME", ((TextView) v).getText());

            startActivity(intent);
        }
    }
}
