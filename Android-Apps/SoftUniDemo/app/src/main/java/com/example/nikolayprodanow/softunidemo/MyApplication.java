package com.example.nikolayprodanow.softunidemo;

import android.app.Application;
import android.content.ContextWrapper;
import android.os.StrictMode;
import android.util.Log;

import com.example.nikolayprodanow.softunidemo.models.Category;
import com.example.nikolayprodanow.softunidemo.models.CategoryItems;
import com.orm.SugarContext;
import com.orm.SugarDb;

import java.io.File;

/**
 * Created by nikolayprodanow on 1/29/17.
 */

public class MyApplication extends Application {

    @Override
    public void onCreate() {
        super.onCreate();

        if (doesDatabaseExist(this, "ecommerce_database.db")) {
            SugarDb sugarDb = new SugarDb(getApplicationContext());

            new File(sugarDb.getDB().getPath()).delete();
        }

        SugarContext.init(getApplicationContext());

        boolean doesDbExist = doesDatabaseExist(this, "ecommerce_database.db");
        if (!doesDbExist) {
            Category.findById(Category.class, (long) 1);
            CategoryItems.findById(CategoryItems.class, (long) 1);

            initDBWithCategory();
        }
    }

    private void initDBWithCategory() {
        Category breakfastCategory = new Category("Breakfast", "Hearty, hot and full of flavor", "#EDDEA5", R.mipmap.breakfast_image);
        Category espressoCategory = new Category("Espresso", "Lattes, cappuccinos, macchiatos...", "#DCB889", R.mipmap.coffee_image);
        Category lunchCategory = new Category("Lunch", "Simple, delicious, high-quality", "#F2E3C6", R.mipmap.lunch_image);
        Category dessertCategory = new Category("Dessert", "Sweet, sweet, and that is place for girls", "#FBE696", R.mipmap.dessert_image);

        breakfastCategory.save();
        espressoCategory.save();
        lunchCategory.save();
        dessertCategory.save();

        CategoryItems espresso = new CategoryItems(
                espressoCategory,
                "http://therealdanvega.com/wp-content/uploads/2016/01/java.png",
                "Black coffee with some code",
                "5",
                "Espresso");

        CategoryItems chocoFrappe = new CategoryItems(
                espressoCategory,
                "https://mcdonalds.com.au/sites/mcdonalds.com.au/files/hero_pdt_coffee_frappe.png",
                "Cold as ice",
                "20",
                "Frappe");

        chocoFrappe.save();
        espresso.save();
    }
    
    private boolean doesDatabaseExist(ContextWrapper context, String dbName) {
        File dbFile = context.getDatabasePath(dbName);
        return dbFile.exists();
    }
}
