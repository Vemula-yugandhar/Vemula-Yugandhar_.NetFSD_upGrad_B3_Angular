------------------------------------------Week4 Day-1----------------------------------------------------------

create database Day5;
use Day5;

------------------------------------------PROBLEM 1----------------------------------------------------------

CREATE TABLE Stores (
    Store_Id INT PRIMARY KEY,
    Store_Name VARCHAR(50) NOT NULL,
    City VARCHAR(50)
);


CREATE TABLE Products (
    Product_Id INT PRIMARY KEY,
    Product_Name VARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);


CREATE TABLE Orders (
    Order_Id INT PRIMARY KEY,
    Store_Id INT NOT NULL,
    Order_Date DATE NOT NULL,
    Total_Amount DECIMAL(10,2),

    FOREIGN KEY (Store_Id) REFERENCES Stores(Store_Id)
);

CREATE TABLE OrderItems (
    OrderItem_Id INT PRIMARY KEY,
    Order_Id INT NOT NULL,
    Product_Id INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,

    FOREIGN KEY (Order_Id) REFERENCES Orders(Order_Id),
    FOREIGN KEY (Product_Id) REFERENCES Products(Product_Id)
);


INSERT INTO Stores VALUES
(1,'Bangalore Store','Bangalore'),
(2,'Hyderabad Store','Hyderabad');

INSERT INTO Products VALUES
(101,'Laptop',50000),
(102,'Mobile',20000),
(103,'Headphones',3000),
(104,'Keyboard',1500),
(105,'Mouse',800);

INSERT INTO Orders VALUES
(1,1,'2025-03-01',NULL),
(2,1,'2025-03-02',NULL),
(3,2,'2025-03-03',NULL);


INSERT INTO OrderItems VALUES
(1,1,101,1,50000),
(2,1,103,2,3000),
(3,2,102,1,20000),
(4,2,104,3,1500),
(5,3,105,5,800);

-------------------------Total Sales per Store---------------

CREATE PROCEDURE sp_TotalSalesPerStore
    @StoreId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        s.Store_Name,
        SUM(ISNULL(oi.Quantity * oi.UnitPrice,0)) AS TotalSales
    FROM Stores s
    JOIN Orders o ON s.Store_Id = o.Store_Id
    JOIN OrderItems oi ON o.Order_Id = oi.Order_Id
    WHERE s.Store_Id = @StoreId
    GROUP BY s.Store_Name;
END;

EXEC sp_TotalSalesPerStore @StoreId = 1;



----Orders by Date Range


CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Order_Id,
        Store_Id,
        Order_Date,
        ISNULL(Total_Amount,0) AS TotalAmount
    FROM Orders
    WHERE Order_Date BETWEEN @StartDate AND @EndDate
    ORDER BY Order_Date;
END;


EXEC sp_GetOrdersByDateRange '2025-03-01','2025-03-31';


--------------Calculate Discount Price


CREATE FUNCTION fn_CalculateDiscountPrice
(
    @Price DECIMAL(10,2),
    @DiscountPercent DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN

    DECLARE @FinalPrice DECIMAL(10,2);

    SET @Price = ISNULL(@Price,0);
    SET @DiscountPercent = ISNULL(@DiscountPercent,0);

    SET @FinalPrice = @Price - (@Price * @DiscountPercent / 100);

    RETURN @FinalPrice;

END;



SELECT 
Product_Name,
Price,
dbo.fn_CalculateDiscountPrice(Price,10) AS DiscountedPrice
FROM Products;

----------------Top 5 Selling Products

CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.Product_Id,
        p.Product_Name,
        SUM(oi.Quantity) AS TotalSold
    FROM Products p
    JOIN OrderItems oi ON p.Product_Id = oi.Product_Id
    GROUP BY p.Product_Id, p.Product_Name
    ORDER BY TotalSold DESC
);


SELECT * FROM dbo.fn_Top5SellingProducts();



-------------------------------------Problem-2--------------------------------------------

CREATE TABLE Items (
    ItemId INT PRIMARY KEY,
    ItemName VARCHAR(100) NOT NULL
);

CREATE TABLE Inventory (
    ItemId INT PRIMARY KEY,
    StockQuantity INT NOT NULL,
    FOREIGN KEY (ItemId) REFERENCES Items(ItemId)
);

CREATE TABLE CustomerOrders (
    OrderId INT PRIMARY KEY,
    OrderDate DATE NOT NULL
);

CREATE TABLE OrderDetails (
    OrderDetailId INT PRIMARY KEY,
    OrderId INT NOT NULL,
    ItemId INT NOT NULL,
    OrderedQty INT NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES CustomerOrders(OrderId),
    FOREIGN KEY (ItemId) REFERENCES Items(ItemId)
);

INSERT INTO Items VALUES
(1,'Laptop'),
(2,'Mobile'),
(3,'Keyboard');

INSERT INTO Inventory VALUES
(1,10),
(2,20),
(3,15);

INSERT INTO CustomerOrders VALUES
(1001,'2025-03-10');

CREATE TRIGGER trg_UpdateInventory
ON OrderDetails
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        -- Check if stock is sufficient
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN Inventory inv ON i.ItemId = inv.ItemId
            WHERE inv.StockQuantity < i.OrderedQty
        )
        BEGIN
            RAISERROR ('Stock not sufficient for this item.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Reduce stock quantity
        UPDATE inv
        SET inv.StockQuantity = inv.StockQuantity - i.OrderedQty
        FROM Inventory inv
        JOIN inserted i
        ON inv.ItemId = i.ItemId;

    END TRY

    BEGIN CATCH

        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR(@ErrorMessage,16,1);

        ROLLBACK TRANSACTION;

    END CATCH
END;


INSERT INTO OrderDetails VALUES
(1,1001,1,2);

INSERT INTO OrderDetails VALUES
(2,1001,1,50);



SELECT * FROM Inventory;


-------------------------------Problem-3-----------------------------------------

CREATE TABLE SalesOrders (
    OrderId INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    OrderStatus INT,      -- 1 = Pending, 2 = Processing, 3 = Shipped, 4 = Completed
    OrderDate DATE,
    ShippedDate DATE
);

INSERT INTO SalesOrders VALUES
(1,'Rahul',1,'2025-03-01',NULL),
(2,'Anita',3,'2025-03-02','2025-03-04'),
(3,'Vikram',2,'2025-03-03',NULL);

CREATE TRIGGER trg_ValidateOrderCompletion
ON SalesOrders
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        -- Validation check
        IF EXISTS (
            SELECT 1
            FROM inserted
            WHERE OrderStatus = 4
            AND ShippedDate IS NULL
        )
        BEGIN
            RAISERROR ('Cannot mark order as Completed without ShippedDate.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

    END TRY

    BEGIN CATCH

        DECLARE @ErrorMessage NVARCHAR(4000);

        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR(@ErrorMessage,16,1);

        ROLLBACK TRANSACTION;

    END CATCH
END;

UPDATE SalesOrders
SET OrderStatus = 4
WHERE OrderId = 1;


UPDATE SalesOrders
SET OrderStatus = 4,
    ShippedDate = '2025-03-05'
WHERE OrderId = 1;


SELECT * FROM SalesOrders;


---------------------------------Problem-4-------------------------------------


CREATE TABLE StoreInfo (
    StoreId INT PRIMARY KEY,
    StoreName VARCHAR(100)
);

CREATE TABLE StoreOrders (
    OrderId INT PRIMARY KEY,
    StoreId INT,
    OrderStatus INT,      -- 4 = Completed
    OrderDate DATE,
    FOREIGN KEY (StoreId) REFERENCES StoreInfo(StoreId)
);

CREATE TABLE ProductCatalog (
    ProductId INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2)
);

CREATE TABLE OrderLineItems (
    ItemId INT PRIMARY KEY,
    OrderId INT,
    ProductId INT,
    Quantity INT,
    DiscountPercent DECIMAL(5,2),

    FOREIGN KEY (OrderId) REFERENCES StoreOrders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES ProductCatalog(ProductId)
);


INSERT INTO StoreInfo VALUES
(1,'Bangalore Store'),
(2,'Hyderabad Store');

INSERT INTO ProductCatalog VALUES
(101,'Laptop',50000),
(102,'Mobile',20000),
(103,'Keyboard',1500);


INSERT INTO StoreOrders VALUES
(1,1,4,'2025-03-01'),
(2,1,4,'2025-03-02'),
(3,2,4,'2025-03-03');

INSERT INTO OrderLineItems VALUES
(1,1,101,1,10),
(2,1,103,2,5),
(3,2,102,1,0),
(4,3,103,3,0);

BEGIN TRY

BEGIN TRANSACTION;

-- Temporary table to store results
CREATE TABLE #RevenueTemp (
    OrderId INT,
    StoreId INT,
    Revenue DECIMAL(12,2)
);

DECLARE @OrderId INT
DECLARE @StoreId INT
DECLARE @Revenue DECIMAL(12,2)

-- Cursor for completed orders
DECLARE OrderCursor CURSOR FOR
SELECT OrderId, StoreId
FROM StoreOrders
WHERE OrderStatus = 4;

OPEN OrderCursor;

FETCH NEXT FROM OrderCursor INTO @OrderId, @StoreId;

WHILE @@FETCH_STATUS = 0
BEGIN

    -- Calculate revenue for the order
    SELECT 
    @Revenue = SUM((p.Price * oli.Quantity) -
                   (p.Price * oli.Quantity * oli.DiscountPercent / 100))
    FROM OrderLineItems oli
    JOIN ProductCatalog p
    ON oli.ProductId = p.ProductId
    WHERE oli.OrderId = @OrderId;

    -- Insert result into temp table
    INSERT INTO #RevenueTemp
    VALUES (@OrderId,@StoreId,ISNULL(@Revenue,0));

    FETCH NEXT FROM OrderCursor INTO @OrderId, @StoreId;

END

CLOSE OrderCursor;
DEALLOCATE OrderCursor;

-- Store wise revenue summary
SELECT 
s.StoreName,
SUM(r.Revenue) AS TotalRevenue
FROM #RevenueTemp r
JOIN StoreInfo s
ON r.StoreId = s.StoreId
GROUP BY s.StoreName;

COMMIT TRANSACTION;

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

PRINT ERROR_MESSAGE();

END CATCH

