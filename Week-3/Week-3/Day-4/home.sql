-----------------------Week-3 Day-4------------------------------------

create database Day3
use day3

--------------Problem-1-------------------------------------------

CREATE TABLE Categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

INSERT INTO Categories VALUES (1,'Mountain Bikes');
INSERT INTO Categories VALUES (2,'Road Bikes');
INSERT INTO Categories VALUES (3,'Electric Bikes');


CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

INSERT INTO Products VALUES (1,'Bike A',1,2020,100);
INSERT INTO Products VALUES (2,'Bike B',1,2022,200);

INSERT INTO Products VALUES (3,'Bike C',2,2020,300);
INSERT INTO Products VALUES (4,'Bike D',2,2022,400);

INSERT INTO Products VALUES (5,'Bike E',3,2020,500);
INSERT INTO Products VALUES (6,'Bike F',3,2022,600);

SELECT * FROM Categories;

SELECT * FROM Products;

	SELECT 
	CONCAT(product_name,' (',model_year,')') AS Product_Details,list_price,
	list_price - (
		SELECT AVG(p2.list_price)
		FROM Products p2
		WHERE p2.category_id = p1.category_id
	) AS Price_Difference
	FROM Products p1
	WHERE list_price >
	(
	SELECT AVG(p2.list_price)
	FROM Products p2
	WHERE p2.category_id = p1.category_id
	);

-------Problem-2-----------------------------------------------------

CREATE TABLE Customers1 (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(30),
    last_name VARCHAR(30)
);

CREATE TABLE Orders1 (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_value INT,
    FOREIGN KEY (customer_id) REFERENCES Customers1(customer_id)
);

INSERT INTO Customers1 VALUES (1,'Ravi','Kumar');
INSERT INTO Customers1 VALUES (2,'Anil','Sharma');
INSERT INTO Customers1 VALUES (3,'Priya','Reddy');
INSERT INTO Customers1 VALUES (4,'Sneha','Patel');
INSERT INTO Customers1 VALUES (5,'Rahul','Verma');

INSERT INTO Orders1 VALUES (101,1,3000);
INSERT INTO Orders1 VALUES (102,1,4000);
INSERT INTO Orders1 VALUES (103,2,12000);
INSERT INTO Orders1 VALUES (104,3,2000);
INSERT INTO Orders1 VALUES (105,3,1000);

SELECT 
CONCAT(c.first_name,' ',c.last_name) AS Full_Name,
total_value,
CASE
    WHEN total_value > 10000 THEN 'Premium'
    WHEN total_value BETWEEN 5000 AND 10000 THEN 'Regular'
    ELSE 'Basic'
END AS Customer_Type
FROM
(
    SELECT c.customer_id, c.first_name, c.last_name,
           SUM(o.order_value) AS total_value
    FROM Customers1 c
    JOIN Orders1 o
    ON c.customer_id = o.customer_id
    GROUP BY c.customer_id, c.first_name, c.last_name
) AS CustomerTotals

UNION

SELECT 
CONCAT(first_name,' ',last_name) AS Full_Name,
0 AS total_value,
'No Orders' AS Customer_Type
FROM Customers1
WHERE customer_id NOT IN
(
    SELECT customer_id FROM Orders1
);



--------------------Problem-3-----------------------------------------

CREATE TABLE Stores2 (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);

CREATE TABLE Products2 (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    list_price DECIMAL(10,2)
);

CREATE TABLE Orders2 (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES Stores2(store_id)
);

CREATE TABLE Order_Items2 (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES Orders2(order_id),
    FOREIGN KEY (product_id) REFERENCES Products2(product_id)
);


CREATE TABLE Stocks2 (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY(store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES Stores2(store_id),
    FOREIGN KEY (product_id) REFERENCES Products2(product_id)
);

INSERT INTO Stores2 VALUES (1,'Bangalore Store');
INSERT INTO Stores2 VALUES (2,'Hyderabad Store');

INSERT INTO Products2 VALUES (101,'Mountain Bike',500);
INSERT INTO Products2 VALUES (102,'Road Bike',800);
INSERT INTO Products2 VALUES (103,'Electric Bike',1200);

INSERT INTO Orders2 VALUES (1,1,'2024-01-01');
INSERT INTO Orders2 VALUES (2,2,'2024-01-02');


INSERT INTO Order_Items2 VALUES (1,1,101,5,50);
INSERT INTO Order_Items2 VALUES (2,1,102,3,30);
INSERT INTO Order_Items2 VALUES (3,2,101,4,40);
INSERT INTO Order_Items2 VALUES (4,2,103,2,20);


INSERT INTO Stocks2 VALUES (1,101,0);
INSERT INTO Stocks2 VALUES (1,102,10);
INSERT INTO Stocks2 VALUES (2,101,0);
INSERT INTO Stocks2 VALUES (2,103,5);

SELECT store_id, product_id
FROM
(
    SELECT DISTINCT o.store_id, oi.product_id
    FROM Orders2 o
    JOIN Order_Items2 oi
    ON o.order_id = oi.order_id
) AS SoldProducts

EXCEPT

SELECT store_id, product_id
FROM Stocks2
WHERE quantity > 0;

SELECT 
s.store_name,
p.product_name,
SUM(oi.quantity) AS Total_Quantity_Sold,

SUM((oi.quantity * p.list_price) - oi.discount) AS Total_Revenue

FROM
(
    SELECT store_id, product_id
    FROM
    (
        SELECT DISTINCT o.store_id, oi.product_id
        FROM Orders2 o
        JOIN Order_Items2 oi
        ON o.order_id = oi.order_id
    ) A

    EXCEPT

    SELECT store_id, product_id
    FROM Stocks2
    WHERE quantity > 0

) AS SoldOutProducts

JOIN Orders2 o
ON SoldOutProducts.store_id = o.store_id

JOIN Order_Items2 oi
ON o.order_id = oi.order_id
AND oi.product_id = SoldOutProducts.product_id

JOIN Stores2 s
ON s.store_id = o.store_id

JOIN Products2 p
ON p.product_id = oi.product_id

GROUP BY s.store_name, p.product_name;

SELECT store_id, product_id
FROM
(
    SELECT DISTINCT o.store_id, oi.product_id
    FROM Orders2 o
    JOIN Order_Items2 oi
    ON o.order_id = oi.order_id
)

INTERSECT

SELECT store_id, product_id
FROM Stocks2
WHERE quantity > 0;


UPDATE Stocks2
SET quantity = 0
WHERE product_id = 103;

------------------------------------------Problem-4-----------------------------------------

CREATE TABLE Customers3 (
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(50)
);


CREATE TABLE Orders3 (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT, 
    -- 1 = Pending
    -- 2 = Shipped
    -- 3 = Rejected
    -- 4 = Completed

    order_date DATE,
    required_date DATE,
    shipped_date DATE,

    FOREIGN KEY (customer_id) REFERENCES Customers3(customer_id)
);


CREATE TABLE Archived_Orders (
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE
);


INSERT INTO Customers3 VALUES (1,'Ravi');
INSERT INTO Customers3 VALUES (2,'Anil');
INSERT INTO Customers3 VALUES (3,'Priya');

INSERT INTO Orders3 VALUES
(101,1,4,'2023-01-10','2023-01-20','2023-01-18'),
(102,1,4,'2023-05-12','2023-05-20','2023-05-22'),
(103,2,3,'2022-02-10','2022-02-20',NULL),
(104,2,3,'2021-01-10','2021-01-20',NULL),
(105,3,4,'2023-07-01','2023-07-10','2023-07-08');

INSERT INTO Archived_Orders
SELECT *
FROM Orders3
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());


DELETE FROM Orders3
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());


SELECT customer_id
FROM Customers3
WHERE customer_id NOT IN
(
    SELECT customer_id
    FROM Orders3
    WHERE order_status <> 4
);


SELECT 
order_id,
customer_id,
DATEDIFF(DAY,order_date,shipped_date) AS Processing_Delay
FROM Orders3
WHERE shipped_date IS NOT NULL;


SELECT 
order_id,
order_date,
required_date,
shipped_date,

CASE
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS Delivery_Status

FROM Orders3
WHERE shipped_date IS NOT NULL;