

--=======================  Week-3 Day-3 ================================================================



---------------------------- PROBLEM-1 -----------------------------------

 create table Customers (
     Customer_id int PRIMARY KEY,
     FirstName varchar(20) NOT NULL,
	 LastName varchar(20)
 );

 create table Orders (
      Order_id int primary key,
	  Customer_id int,
	  Order_date datetime NOT NULL,
	  Order_status varchar(10),
	 FOREIGN KEY (Customer_id) REFERENCES Customers(Customer_id)
 );

 insert into Customers values(1, 'vemula','yugandhar');
 insert into Customers values(2, 'vemula', 'manoj');
 insert into Customers values(3, 'Ashok', 'Kumar');
 insert into Customers values(4, 'chiru', 'balaji');
 insert into Customers values(5, 'chiru', 'balaji');

insert into Orders values(101, 1, '2026-03-01 10:15:00', 'Pending'),(102, 2, '2026-03-02 12:30:00', 'Completed'),(103, 3, '2026-03-03 09:45:00', 'Pending'),(104, 1, '2026-03-04 14:20:00', 'Ordered');


select c.FirstName, c.LastName, o.Order_id, o.Order_Date, Order_Status
  from Customers c inner join Orders o ON c.Customer_id = o.Customer_id 
  where o.Order_status IN ('Pending', 'Completed')
  order by Order_Date DESC;





-------------------------- PROBLEM-2 -----------------------------------

CREATE TABLE Brands (
     Brand_id INT PRIMARY KEY,
     Brand_Name VARCHAR(30) NOT NULL
);

  CREATE TABLE Categories (
     Category_id INT PRIMARY KEY,
     Category_Name VARCHAR(30) NOT NULL
);

  CREATE TABLE Products (
     Product_id INT PRIMARY KEY,
     Product_Name VARCHAR(20) NOT NULL,
     Brand_id INT,
     Category_id INT,
     Model_Year INT,
     List_Price INT,
	  FOREIGN KEY (Brand_id) REFERENCES Brands(Brand_id),
	  FOREIGN KEY (Category_id) REFERENCES Categories(Category_id)
);


INSERT INTO Brands VALUES (1,'Nike'),(2,'Adidas'),(3,'Puma'),(4,'Reebok'),(5,'Under Armour');


INSERT INTO Categories VALUES
(1,'Shoes'),
(2,'Clothing'),
(3,'Accessories'),
(4,'Sports Gear');

INSERT INTO Products VALUES
(101,'Running Shoes',1,1,2023,800),
(102,'Football Shoes',2,1,2022,950),
(103,'Sports T-Shirt',3,2,2023,600),
(104,'Training Shorts',4,2,2021,550),
(105,'Cap',5,3,2024,300);


select p.Product_Name, b.Brand_Name, c.Category_name, p.Model_Year, p.List_Price
FROM Products p INNER JOIN Brands b ON p.Brand_id = b.Brand_id
INNER JOIN Categories c ON p.Category_id = c.Category_id
where p.List_price >= 600
ORDER BY p.List_price;





------------------------- PROBLEM-3 -----------------------------------

CREATE TABLE Stores1 (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);

CREATE TABLE Products2 (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    list_price DECIMAL(10,2)
);

CREATE TABLE Orders1 (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES Stores1(store_id)
);

CREATE TABLE Order_Items1 (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(4,2),

    FOREIGN KEY (order_id) REFERENCES Orders1(order_id),
    FOREIGN KEY (product_id) REFERENCES Products2(product_id)
);

INSERT INTO Stores1 VALUES (1,'Store A');
INSERT INTO Stores1 VALUES (2,'Store B');
INSERT INTO Stores1 VALUES (3,'Store C');

INSERT INTO Products2 VALUES (1,'Laptop',50000);
INSERT INTO Products2 VALUES (2,'Mobile',20000);
INSERT INTO Products2 VALUES (3,'Tablet',15000);

INSERT INTO Orders1 VALUES (101,1,4);
INSERT INTO Orders1 VALUES (102,1,3);
INSERT INTO Orders1 VALUES (103,2,4);
INSERT INTO Orders1 VALUES (104,3,4);

INSERT INTO Order_Items1 VALUES (1,101,1,1,0.10);
INSERT INTO Order_Items1 VALUES (2,101,2,2,0.05);
INSERT INTO Order_Items1 VALUES (3,103,2,1,0.00);
INSERT INTO Order_Items1 VALUES (4,104,3,3,0.15);


SELECT 
s.store_name,
SUM(oi.quantity * p.list_price * (1 - oi.discount)) AS total_sales
FROM Stores s

INNER JOIN Orders1 o
ON s.store_id = o.store_id

INNER JOIN Order_Items1 oi
ON o.order_id = oi.order_id

INNER JOIN Products2 p
ON oi.product_id = p.product_id

WHERE o.order_status = 4

GROUP BY s.store_name

ORDER BY total_sales DESC;

 ------------------------- PROBLEM-4 -----------------------------------

CREATE TABLE Products1 (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50)
);

INSERT INTO Products1 VALUES (1,'Laptop');
INSERT INTO Products1 VALUES (2,'Mobile');
INSERT INTO Products1 VALUES (3,'Tablet');

CREATE TABLE Stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);

INSERT INTO Stores VALUES (1,'Store A');
INSERT INTO Stores VALUES (2,'Store B');

CREATE TABLE Stocks (
    store_id INT,
    product_id INT,
    quantity INT,
	FOREIGN KEY (store_id) REFERENCES Stores(store_id),
	FOREIGN KEY (product_id) REFERENCES Products1(product_id)
);

INSERT INTO Stocks VALUES (1,1,50);
INSERT INTO Stocks VALUES (1,2,30);
INSERT INTO Stocks VALUES (1,3,20);

INSERT INTO Stocks VALUES (2,1,40);
INSERT INTO Stocks VALUES (2,2,25);
INSERT INTO Stocks VALUES (2,3,15);

CREATE TABLE Order_Items (
    order_id INT,
    product_id INT,
    quantity INT,
	FOREIGN KEY (product_id) REFERENCES Products1(product_id)
);

INSERT INTO Order_Items VALUES (101,1,5);
INSERT INTO Order_Items VALUES (102,1,3);
INSERT INTO Order_Items VALUES (103,2,10);
INSERT INTO Order_Items VALUES (104,2,5);

SELECT 
p.product_name,
s.store_name,
st.quantity AS Available_Stock,
SUM(oi.quantity) AS Total_Sold
FROM Stocks st

INNER JOIN Products1 p
ON st.product_id = p.product_id

INNER JOIN Stores s
ON st.store_id = s.store_id

LEFT JOIN Order_Items oi
ON st.product_id = oi.product_id

GROUP BY p.product_name, s.store_name, st.quantity

ORDER BY p.product_name;