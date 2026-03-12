---------------------------------Week-4 Day-2--------------------------------------------------------

----------------Problem-1---------------------------------------------

create database Day6;

use Day6

CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50)
);

CREATE TABLE Stocks (
    product_id INT PRIMARY KEY,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    order_date DATE
);

CREATE TABLE Order_Items4 (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

CREATE TABLE Order_Items (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

INSERT INTO Products VALUES (1,'Mountain Bike');
INSERT INTO Products VALUES (2,'Road Bike');
INSERT INTO Products VALUES (3,'Electric Bike');

INSERT INTO Stocks VALUES (1,10);
INSERT INTO Stocks VALUES (2,5);
INSERT INTO Stocks VALUES (3,2);


CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM Stocks s
        JOIN inserted i
        ON s.product_id = i.product_id
        WHERE s.quantity < i.quantity
    )
    BEGIN
        RAISERROR('Insufficient stock.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM Stocks4 s
    JOIN inserted i
    ON s.product_id = i.product_id;

END;

-----Transaction for placing order-----------------


BEGIN TRANSACTION

BEGIN TRY

INSERT INTO Orders VALUES (101,GETDATE());

INSERT INTO Order_Items VALUES (1,101,1,3);

COMMIT TRANSACTION

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION
PRINT 'Transaction failed due to insufficient stock'

END CATCH


INSERT INTO Order_Items VALUES (2,101,1,3);


INSERT INTO Order_Items VALUES (3,101,1,20);




---------Problem-2----------------------------------------------------

CREATE TABLE Products1 (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50)
);

CREATE TABLE Stocks1 (
    product_id INT PRIMARY KEY,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES Products1(product_id)
);

CREATE TABLE Orders1 (
    order_id INT PRIMARY KEY,
    order_status INT, -- 1=Pending, 2=Confirmed, 3=Rejected
    order_date DATE
);

CREATE TABLE Order_Items1 (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES Orders1(order_id),
    FOREIGN KEY (product_id) REFERENCES Products1(product_id)
);

INSERT INTO Products1 VALUES (1,'Mountain Bike');
INSERT INTO Products1 VALUES (2,'Road Bike');

INSERT INTO Stocks1 VALUES (1,10);
INSERT INTO Stocks1 VALUES (2,5);

INSERT INTO Orders1 VALUES (101,2,'2024-01-01');

INSERT INTO Order_Items1 VALUES (1,101,1,3);
INSERT INTO Order_Items1 VALUES (2,101,2,2);


BEGIN TRANSACTION

BEGIN TRY

-- SAVEPOINT before restoring stock
SAVE TRANSACTION RestoreStockPoint

-- Restore stock quantities
UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM Stocks1 s
JOIN Order_Items1 oi
ON s.product_id = oi.product_id
WHERE oi.order_id = 101;

-- Update order status to Rejected
UPDATE Orders1
SET order_status = 3
WHERE order_id = 101;

-- Commit if everything succeeds
COMMIT TRANSACTION;

END TRY

BEGIN CATCH

-- Rollback only to savepoint
ROLLBACK TRANSACTION RestoreStockPoint;

PRINT 'Error occurred while restoring stock.';

-- Optional full rollback
ROLLBACK TRANSACTION;

END CATCH