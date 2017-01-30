package com.example.nikolayprodanow.softunidemo.models;

import android.os.Parcel;
import android.os.Parcelable;

import com.orm.SugarRecord;

/**
 * Created by nikolayprodanow on 1/29/17.
 */

public class CategoryItems extends SugarRecord implements Parcelable {

    private Category category;
    private String mImageURI;
    private String mItemDescription;
    private String mItemPrice;
    private String mItemTitle;

    public CategoryItems() {
    }

    public CategoryItems(
            Category category,
            String mImageURI,
            String mItemDescription,
            String mItemPrice,
            String mItemTitle) {

        this.setCategory(category);
        this.setmImageURI(mImageURI);
        this.setmItemDescription(mItemDescription);
        this.setmItemPrice(mItemPrice);
        this.setmItemTitle(mItemTitle);
    }

    public Category getCategory() {
        return category;
    }

    public void setCategory(Category category) {
        this.category = category;
    }

    public String getmImageURI() {
        return mImageURI;
    }

    public void setmImageURI(String mImageURI) {
        this.mImageURI = mImageURI;
    }

    public String getmItemDescription() {
        return mItemDescription;
    }

    public void setmItemDescription(String mItemDescription) {
        this.mItemDescription = mItemDescription;
    }

    public String getmItemPrice() {
        return mItemPrice;
    }

    public void setmItemPrice(String mItemPrice) {
        this.mItemPrice = mItemPrice;
    }

    public String getmItemTitle() {
        return mItemTitle;
    }

    public void setmItemTitle(String mItemTitle) {
        this.mItemTitle = mItemTitle;
    }

    public String getmItemCategoryIdentifier() {
        if (this.category == null){
            return  "Unknown";
        }
        return this.category.getmCategoryName();
    }

    protected CategoryItems(Parcel in) {
        category = (Category) in.readValue(Category.class.getClassLoader());
        mImageURI = in.readString();
        mItemDescription = in.readString();
        mItemPrice = in.readString();
        mItemTitle = in.readString();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeValue(category);
        dest.writeString(mImageURI);
        dest.writeString(mItemDescription);
        dest.writeString(mItemPrice);
        dest.writeString(mItemTitle);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<CategoryItems> CREATOR = new Parcelable.Creator<CategoryItems>() {
        @Override
        public CategoryItems createFromParcel(Parcel in) {
            return new CategoryItems(in);
        }

        @Override
        public CategoryItems[] newArray(int size) {
            return new CategoryItems[size];
        }
    };
}