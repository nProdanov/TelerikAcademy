package com.example.nikolayprodanow.workshop0302.models;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * Created by nikolayprodanow on 2/3/17.
 */

public class Book implements Parcelable {

    private String title;
    private String author;
    private String isbn;

    public Book(String title, String author, String isbn){
        this.setTitle(title);
        this.setAuthor(author);
        this.setIsbn(isbn);
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getIsbn() {
        return isbn;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    protected Book(Parcel in) {
        title = in.readString();
        author = in.readString();
        isbn = in.readString();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(title);
        dest.writeString(author);
        dest.writeString(isbn);
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