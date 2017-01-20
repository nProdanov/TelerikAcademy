# Database systems - overview

### 01.Database Models:
- **Hierarchical** - *tree*
- **Network** - *graph*
- **Relational** - *table*
- **Object-oriented**

### 02.The main functions of Relational Database Management System (RDBMS):
- **manage data stored in tables**
- **create/modify (alter)/ delete tables and relationships between them**
- **add/modify/delete data**
- **searching data**

### 03.Table in Database terms: 
- **table stores data**
- **table has rows and coloumns**
- **each coloumn has own type and doesn't allow to add different type data in it's cell**

### 04.Primary and Foreign keys

#### Primary key

- **primary key is coloumn of table**
- **each row of primary key coloumn is unique for the table**
- **the fastest way for searching data is by primary key**
- **sometimes the are more than one primary key *(composite primary key)* - then unique is the combination between them**
- **often primary key is int value**
- **tables communicates with primary - foreign key**
___
#### Foreign key
- **foreign key in table is a primary key of another table**

- ***Using them we make relationship between tables. Relationship of other hand is used to avoid duplications in tables.***

### 05. Different types Relationships between tables

#### one-to-many relationship
- **each record of one table corresponding with many records of another table**
- **used very often**
___
#### many-to-many relationship
- **many records of one table corresponding with many records of another table**
- **in some database servers it's made by third table which contains only primary keys of the other two tables**
- **used often**
___
#### one-to-one ralationship
- **one record of table corresponding with one record of another table**
- **used to implement inheritance between tables**
- **used rare**
___
#### self-relationship
- **the primary of the foreign key can point to one and the same table**
- **used for trees or graphs**

### 06.Normalize data in tables
- **tables are being normalized to avoid duplications**
- **normalize is implement by set primary and foreign keys and connect tables by relationships**
- **normalize is done because when there are too many duplicates it means more storage (more money)**

### 07.Integrity Constraints
- **Integrity constraints ensure data integrity in the database tables enforce data rules which cannot be violated**
- **Primary key constraint - Ensures that the primary key of a table has unique value for each table row**
- **Unique key constraint - Ensures that all values in a certain column (or a group of columns) are unique**
- **Foreign key constraint - Ensures that the value in given column is a key from another table**
- **Check constraint - Ensures that values in a certain column meet some predefined condition**

### 08.Indeces
- **Indices speed up searching of values in a certain column or group of columns**
- **Indices can be built-in the table (clustered) or stored externally (non-clustered)**
- **Indices should be used for big tables only**
- **Adding and deleting records in indexed tables is slower!**

### 09.SQL Language
- **Creating, altering, deleting tables and other objects in the database**
- **Searching, retrieving, inserting, modifying and deleting table data (rows)**

### 10.Transactions
- **transactions are a sequence of database operations which are executed as a single unit**
- **either all of operations execute or none of them is executed at all**
- ***Example:* When you try to get money from your account trough the CashMashine but AC accidentally stops in middle of operation "Transactions" secures that if you don't have money in your hand the whole operation fails and in your account there is correct ammount of money**

### 11.NoSQL Database
- **there is no relationships (non-relational)**

### 12.Classical NoSQL database model
- **there is no schema for tables - in each row of one coloumn you can add different type of data**
- **Single entity (document) is a single record**
- **Data stored as documents**

### 13.NoSQL Examples:
- **Redis** - *Ultra-fast in-memory data structures server*
- **MongoDB** - *Mature and powerful JSON-document database*
- **CouchDB** - *JSON-based document database with REST API*
- **Cassandra** - *Distributed wide-column database*


