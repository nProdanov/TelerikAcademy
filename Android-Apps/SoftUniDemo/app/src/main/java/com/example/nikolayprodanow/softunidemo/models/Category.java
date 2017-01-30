package com.example.nikolayprodanow.softunidemo.models;

import android.os.Parcel;
import android.os.Parcelable;
import android.os.StrictMode;

import com.orm.SugarRecord;

import java.util.List;

/**
 * Created by nikolayprodanow on 1/29/17.
 */

public class Category extends SugarRecord implements Parcelable {
    private String mCategoryName;
    private String mSubCategoryName;
    private String mItemColor;
    private int mImageElementInMemory;

    public Category() {
    }

    public Category(String mCategoryName, String mSubCategoryName, String mItemColor, int mImageElementInMemory) {
        this.setmCategoryName(mCategoryName);
        this.setmSubCategoryName(mSubCategoryName);
        this.setmItemColor(mItemColor);
        this.setmImageElementInMemory(mImageElementInMemory);
    }

    public List<CategoryItems> getAllItemsCategory(){
        return  CategoryItems.find(CategoryItems.class, "category=?", String.valueOf(getId()));
    }

    public String getmCategoryName() {
        return mCategoryName;
    }

    public void setmCategoryName(String mCategoryName) {
        this.mCategoryName = mCategoryName;
    }

    public String getmSubCategoryName() {
        return mSubCategoryName;
    }

    public void setmSubCategoryName(String mSubCategoryName) {
        this.mSubCategoryName = mSubCategoryName;
    }

    public String getmItemColor() {
        return mItemColor;
    }

    public void setmItemColor(String mItemColor) {
        this.mItemColor = mItemColor;
    }

    public int getmImageElementInMemory() {
        return mImageElementInMemory;
    }

    public void setmImageElementInMemory(int mImageElementInMemory) {
        this.mImageElementInMemory = mImageElementInMemory;
    }

    protected Category(Parcel in) {
        mCategoryName = in.readString();
        mSubCategoryName = in.readString();
        mItemColor = in.readString();
        mImageElementInMemory = in.readInt();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(mCategoryName);
        dest.writeString(mSubCategoryName);
        dest.writeString(mItemColor);
        dest.writeInt(mImageElementInMemory);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<Category> CREATOR = new Parcelable.Creator<Category>() {
        @Override
        public Category createFromParcel(Parcel in) {
            return new Category(in);
        }

        @Override
        public Category[] newArray(int size) {
            return new Category[size];
        }
    };
}
