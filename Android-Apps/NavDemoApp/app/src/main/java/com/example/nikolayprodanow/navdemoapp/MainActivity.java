package com.example.nikolayprodanow.navdemoapp;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.example.nikolayprodanow.navdemoapp.fragments.StepOneFragment;
import com.example.nikolayprodanow.navdemoapp.fragments.StepThreeFragmet;
import com.example.nikolayprodanow.navdemoapp.fragments.StepTwoFragment;

public class MainActivity extends AppCompatActivity {

    Fragment mFragStepOne;
    Fragment mFragStepTwo;
    Fragment mFragStepThree;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ViewPager viewPager = (ViewPager) findViewById(R.id.vp_pager);

        MyPagerAdapter myPagerAdapter = new MyPagerAdapter(getSupportFragmentManager());
        viewPager.setAdapter(myPagerAdapter);
    }

    private class MyPagerAdapter extends FragmentPagerAdapter {
        public MyPagerAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int position) {
            switch (position) {
                case 0:
                    if (mFragStepOne == null){
                        mFragStepOne = new StepOneFragment();
                    }

                    return mFragStepOne;
                case 1:
                    if (mFragStepTwo == null){
                        mFragStepTwo = new StepTwoFragment();
                    }

                    return mFragStepTwo;
                case 2:
                    if (mFragStepThree == null){
                        mFragStepThree = new StepThreeFragmet();
                    }

                    return mFragStepThree;
                default:
                    return null;
            }
        }

        @Override
        public int getCount() {
            return 3;
        }
    }
}
