package com.example.nikolayprodanow.workshop0302.fragments;


import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.util.ArrayMap;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.astuetz.PagerSlidingTabStrip;
import com.example.nikolayprodanow.workshop0302.R;
import com.example.nikolayprodanow.workshop0302.fragments.tabs.AboutTabFragment;
import com.example.nikolayprodanow.workshop0302.fragments.tabs.BooksListTabFragment;
import com.example.nikolayprodanow.workshop0302.fragments.tabs.GenresFragment;
import com.example.nikolayprodanow.workshop0302.fragments.tabs.SearchTabFragment;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/**
 * A simple {@link Fragment} subclass.
 */
public class TabsNavFragment extends Fragment {

    public TabsNavFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_tabs_nav, container, false);

        return rootView;
    }

    @Override
    public void onStart() {
        super.onStart();

        ViewPager pager = (ViewPager) getActivity().findViewById(R.id.vp_pager);
        pager.setAdapter(new TabsNavigationAdapter(getFragmentManager()));

        PagerSlidingTabStrip tabs = (PagerSlidingTabStrip) getActivity().findViewById(R.id.tabs);
        tabs.setIndicatorColorResource(R.color.colorRed);
        tabs.setDividerColorResource(R.color.colorBlue);
        tabs.setViewPager(pager);
    }

    public class TabsNavigationAdapter extends FragmentStatePagerAdapter {

        private static final String BOOKS_TAB_NAME = "Books";
        private static final String SEARCH_TAB_NAME = "Search";
        private static final String ABOUT_TAB_NAME = "About";
        private static final String GENRES_TAB_NAME = "Genres";

        private List<Fragment> tabs;
        private List<String> tabsNames;

        public TabsNavigationAdapter(FragmentManager fm) {
            super(fm);
            this.tabs = new ArrayList<>();
            this.tabs.add(BooksListTabFragment.getInstance());
            this.tabs.add(GenresFragment.getInstance());
            this.tabs.add(SearchTabFragment.getInstance());
            this.tabs.add(AboutTabFragment.getInstance());

            this.tabsNames = new ArrayList<>();
            this.tabsNames.add(BOOKS_TAB_NAME);
            this.tabsNames.add(GENRES_TAB_NAME);
            this.tabsNames.add(SEARCH_TAB_NAME);
            this.tabsNames.add(ABOUT_TAB_NAME);
        }

        @Override
        public Fragment getItem(int position) {
            return this.tabs.get(position);
        }

        @Override
        public int getCount() {
            return this.tabs.size();
        }

        @Override
        public CharSequence getPageTitle(int position) {
            return  this.tabsNames.get(position);
        }
    }

}
