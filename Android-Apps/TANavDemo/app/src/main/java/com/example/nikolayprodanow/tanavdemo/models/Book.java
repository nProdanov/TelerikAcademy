package com.example.nikolayprodanow.tanavdemo.models;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by nikolayprodanow on 2/2/17.
 */

public class Book implements Parcelable {
    private String Isbn;
    private String Title;

    public Book(String isbn, String title) {
        this.setIsbn(isbn);
        this.setTitle(title);
    }

    public String getIsbn() {
        return Isbn;
    }

    public void setIsbn(String isbn) {
        Isbn = isbn;
    }

    public String getTitle() {
        return Title;
    }

    public void setTitle(String title) {
        Title = title;
    }

    protected Book(Parcel in) {
        Isbn = in.readString();
        Title = in.readString();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(Isbn);
        dest.writeString(Title);
    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<Book> CREATOR = new Parcelable.Creator<Book>() {
        @Override
        public Book createFromParcel(Parcel in) {
            return new Book(in);
        }

        @Override
        public Book[] newArray(int size) {
            return new Book[size];
        }
    };
}