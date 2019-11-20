CREATE DATABASE QuanLyQuanCafe
GO
USE QuanLyQuanCafe
GO
CREATE TABLE TableDrink
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100),
	status NVARCHAR(100) DEFAULT N'Trống'
)
GO

CREATE TABLE Account 
(
	id INT IDENTITY PRIMARY KEY,
	DisplayName NVARCHAR(100),
	UserName NVARCHAR(100),
	matKhau NVARCHAR(100),
	Type INT NOT NULL DEFAULT 0 -- 1:admin && 0:staff
	
)
GO
CREATE TABLE DrinkCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL
)
GO
CREATE TABLE Drink
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
	idCategory INT NOT NULL,
	price FLOAT NOT NULL

	FOREIGN KEY (idCategory) REFERENCES dbo.DrinkCategory(id)
)
GO
CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	totalPrice FLOAT,
	idTable INT ,
	status INT NOT NULL DEFAULT 0 --1:đã thanh toán, 0: chưa thanh toán
	FOREIGN KEY(idTable) REFERENCES dbo.TableDrink(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idDrink INT NOT NULL,
	count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idDrink) REFERENCES dbo.Drink(id)
)
GO
DECLARE @i INT =0
WHILE @i <= 10
BEGIN
	INSERT dbo.TableDrink
	(name)VALUES(N'Bàn '+ CAST(@i AS NVARCHAR(100)))
	SET @i = @i+1
END
GO
CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableDrink
GO
INSERT dbo.DrinkCategory
(name)VALUES(N'Tà tữa')
GO
INSERT dbo.DrinkCategory
(name)VALUES(N'Cà phê')
GO
INSERT dbo.DrinkCategory
(name)VALUES(N'Macchiato')
GO
INSERT dbo.DrinkCategory
(name)VALUES(N'Sinh tố')
GO
INSERT dbo.DrinkCategory
(name)VALUES(N'Chocolate')
GO
INSERT dbo.DrinkCategory
(name)VALUES(N'Đồ ăn vặt')
GO
-----Insert drink -------
INSERT dbo.Drink
(
    name,
    idCategory,
    price
)
VALUES
(   N'Hồng trà sữa', -- name - nvarchar(100)
    1,   -- idCategory - int
    30000.0  -- price - float
    )
INSERT dbo.Drink
(
    name,
    idCategory,
    price
)
VALUES
(   N'Trà vải', -- name - nvarchar(100)
    1,   -- idCategory - int
    35000.0  -- price - float
    )
INSERT dbo.Drink
(
    name,
    idCategory,
    price
)
VALUES
(   N'Trà hoa hồng', -- name - nvarchar(100)
    1,   -- idCategory - int
    50000.0  -- price - float
    )
GO
INSERT dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    NULL, -- DateCheckOut - date
    2,         -- idTable - int
    0          -- status - int
    )
GO
---Thêm bill info ---
INSERT INTO dbo.BillInfo
(
    idBill,
    idDrink,
    count
)
VALUES
(   1, -- idBill - int
    1, -- idDrink - int
    2  -- count - int
    )
INSERT INTO dbo.BillInfo
(
    idBill,
    idDrink,
    count
)
VALUES
(   1, -- idBill - int
    3, -- idDrink - int
    1  -- count - int
    )
SELECT d.name, bi.count,d.price,d.price*bi.count AS N'Tổng cộng'
FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Drink AS d
WHERE bi.idBill = b.id AND bi.idDrink = d.id AND b.idTable =2
SELECT DateCheckIn FROM dbo.Bill WHERE idTable = 2
GO
CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill
	(
	    DateCheckIn,
	    DateCheckOut,
	    idTable,
	    status
	)
	VALUES
	(   GETDATE(), -- DateCheckIn - date
	    GETDATE(), -- DateCheckOut - date
	    @idTable,         -- idTable - int
	    0          -- status - int
	    )
END
GO
CREATE PROC USP_InsertBillInfo
@idBill INT, @idDrink INT, @count INT
AS
BEGIN
	DECLARE @isExistBillInfo INT
	DECLARE @drinkCount INT =1

	SELECT @isExistBillInfo = id, @drinkCount =b.count
	FROM dbo.BillInfo AS b
	WHERE b.idBill = @idBill AND idDrink = @idDrink
	IF(@isExistBillInfo > 0 )
	BEGIN
		DECLARE @newCount INT = @drinkCount + @count
		IF(@newCount > 0)
			UPDATE dbo.BillInfo SET count = @drinkCount + @count WHERE idDrink = @idDrink
	END
	ELSE
	BEGIN
		INSERT dbo.BillInfo
		(
		    idBill,
		    idDrink,
		    count
		)
		VALUES
		(   @idBill, -- idBill - int
		    @idDrink, -- idDrink - int
		    @count  -- count - int
		    )
	END
END
GO
CREATE PROC USP_DeleteBillInfo
@idBill INT ,@drinkName NVARCHAR(100)
AS
	DELETE dbo.BillInfo WHERE (idDrink IN (SELECT id FROM dbo.Drink WHERE name LIKE @drinkName)) AND idBill = @idBill
	
GO
EXEC dbo.USP_DeleteBillInfo @idBill = 0 , @drinkName = N''
GO
SELECT * FROM dbo.Bill
GO
CREATE PROC USP_DeleteBill
@idBill INT
AS
	DELETE dbo.BillInfo WHERE idBill = @idBill
	DELETE dbo.Bill WHERE id = @idBill
GO
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill = idBill FROM Inserted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0

	UPDATE dbo.TableDrink SET status = N'Có người' WHERE id = @idTable

END
GO
CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = id FROM Inserted
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	DECLARE @count INT =0
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	IF(@count = 0)
		UPDATE dbo.TableDrink SET status = N'Trống' WHERE id = @idTable
	
END
GO
SELECT * FROM bill
GO
CREATE PROC USP_GetListBillByDate
@checkIn DATE, @checkOut DATE
AS
BEGIN
	SELECT b.id , b.totalPrice, b.DateCheckIn, b.DateCheckOut
	FROM dbo.Bill AS b
	WHERE DateCheckIN >= @checkIn AND b.DateCheckOut <= @checkOut
	AND b.status =1
END
GO
CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	DECLARE @count INT =0

	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND B.id = @idBill AND status =0

	IF(@count >0)
		UPDATE dbo.TableDrink SET status = N'Trống' WHERE id = @idTable
END
GO
CREATE PROC USP_InsertDrink
@name NVARCHAR(100) , @idCategory int , @price FLOAT
AS
BEGIN
	INSERT dbo.Drink(name,idCategory,price)VALUES( @name , @idCategory , @price )
END
GO
