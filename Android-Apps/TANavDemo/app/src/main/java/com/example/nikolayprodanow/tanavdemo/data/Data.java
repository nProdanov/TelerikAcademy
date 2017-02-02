package com.example.nikolayprodanow.tanavdemo.data;

import android.os.StrictMode;

import com.example.nikolayprodanow.tanavdemo.models.Book;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by nikolayprodanow on 2/2/17.
 */

public class Data {
    private static List<Book> books;

    static {
        books = new ArrayList<>();

        Book king = new Book("123", "King rat");
        Book shogun = new Book("456", "Shogun");

        for (int i = 0; i < 100; i++) {
             Book currBook = new Book(String.format("ISBN: %d", i+1),String.format("Title#: %d", i));
            books.add(currBook);
        }
        books.add(king);
        books.add(shogun);
    }

    public List<Book> getBooks() {
        return new ArrayList<>(books);
    }

    public Book getBookByIsbn(String isbn) {
        for (Book book : books) {
            if (book.getIsbn().equals(isbn)) {
                return book;
            }
        }

        return null;
    }

    public Book createBook(String isbn, String title) {
        Book book = new Book(isbn, title);
        books.add(book);
        return book;
    }
}
