--------------------------------------------Week-3 Day-5 ----------------------------------------------

use Day4;

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50),
    phone VARCHAR(20)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

INSERT INTO categories VALUES (1,'Mountain Bikes');
INSERT INTO categories VALUES (2,'Road Bikes');
INSERT INTO categories VALUES (3,'Electric Bikes');
INSERT INTO categories VALUES (4,'Kids Bikes');
INSERT INTO categories VALUES (5,'Accessories');

INSERT INTO brands VALUES (1,'Trek');
INSERT INTO brands VALUES (2,'Giant');
INSERT INTO brands VALUES (3,'Specialized');
INSERT INTO brands VALUES (4,'Cannondale');
INSERT INTO brands VALUES (5,'Scott');

INSERT INTO products VALUES (1,'Trek X1',1,1,2022,800);
INSERT INTO products VALUES (2,'Giant Speed',2,2,2023,900);
INSERT INTO products VALUES (3,'Specialized E-Bike',3,3,2023,1500);
INSERT INTO products VALUES (4,'Kids Fun Bike',4,4,2021,300);
INSERT INTO products VALUES (5,'Bike Helmet',5,5,2022,50);

INSERT INTO customers VALUES (1,'Ravi','Kumar','Hyderabad','900000001');
INSERT INTO customers VALUES (2,'Anil','Sharma','Bangalore','900000002');
INSERT INTO customers VALUES (3,'Priya','Reddy','Hyderabad','900000003');
INSERT INTO customers VALUES (4,'Sneha','Patel','Mumbai','900000004');
INSERT INTO customers VALUES (5,'Rahul','Verma','Bangalore','900000005');

INSERT INTO stores VALUES (1,'Bike Store Hyderabad','Hyderabad');
INSERT INTO stores VALUES (2,'Bike Store Bangalore','Bangalore');
INSERT INTO stores VALUES (3,'Bike Store Mumbai','Mumbai');
INSERT INTO stores VALUES (4,'Bike Store Delhi','Delhi');
INSERT INTO stores VALUES (5,'Bike Store Chennai','Chennai');

SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

SELECT *
FROM customers
WHERE city = 'Hyderabad';

SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;

CREATE TABLE staffs (
    staff_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    store_id INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    staff_id INT,
    order_date DATE,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);

CREATE VIEW vw_ProductDetails
AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

SELECT * FROM vw_ProductDetails;


CREATE VIEW vw_OrderDetails
AS
SELECT 
o.order_id,
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name,
st.first_name + ' ' + st.last_name AS staff_name,
o.order_date
FROM orders o
JOIN customers c
ON o.customer_id = c.customer_id
JOIN stores s
ON o.store_id = s.store_id
JOIN staffs st
ON o.staff_id = st.staff_id;

SELECT * FROM vw_OrderDetails;

CREATE INDEX idx_products_brand
ON products(brand_id);

CREATE INDEX idx_products_category
ON products(category_id);

CREATE INDEX idx_orders_customer
ON orders(customer_id);

CREATE INDEX idx_orders_store
ON orders(store_id);

CREATE INDEX idx_orders_staff
ON orders(staff_id);

SET STATISTICS IO ON;
SET STATISTICS TIME ON;

SELECT *
FROM vw_ProductDetails
WHERE brand_name = 'Trek';