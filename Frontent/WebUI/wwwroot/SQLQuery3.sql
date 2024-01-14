CREATE TRIGGER trgAfterInsertOrder
ON dbo.Orders
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OrderID INT, @TotalPrice DECIMAL(18, 2), @TransactionDate DATETIME2(7), @Description NVARCHAR(MAX)

    -- Yeni eklenen siparişleri tabloya al
    SELECT TOP 1
        @OrderID = OrderID,
        @TotalPrice = TotalPrice
    FROM inserted;

    -- TransactionDate, Description ve Amount değerlerini belirle
    SET @TransactionDate = GETDATE();
    SET @Description = 'Order ID ' + CAST(@OrderID AS NVARCHAR(MAX)) + ' added to CashTransactions';
    
    -- CashTransactions tablosuna ekle
    INSERT INTO dbo.CashTransactions (TransactionDate, Description, Amount)
    VALUES (@TransactionDate, @Description, @TotalPrice);
END;
