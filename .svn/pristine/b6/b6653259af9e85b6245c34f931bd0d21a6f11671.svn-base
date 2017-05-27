
DECLARE @shopId INT;
DECLARE @startTime DATETIME;
SET @shopId=10619;
SET @startTime = '2017-02-20 18:23:56.020'

SELECT SUM(sub.PurchasePrice * sub.Quantity) AS TotalAmount　FROM dbo.OrderItemDetails AS sub
INNER JOIN dbo.OrderForm AS main
ON main.orderCode = sub.OrderCode
WHERE main.status=4
--AND main.shopID = @shopId
AND dt BETWEEN @startTime AND GETDATE()