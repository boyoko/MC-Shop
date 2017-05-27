SELECT * FROM
                                (SELECT  ROW_NUMBER() OVER (PARTITION BY s.shopID ORDER BY b.PickTime DESC) AS Id
                                ,s.shopID,s.shopName,b.PickTime,b.PickManId,b.PickMan
                                ,(SELECT SUM(p.Price * d.PickAmount) 
                                FROM dbo.ProductLibrary AS p
                                INNER JOIN dbo.GoodsPickingDetail AS d
                                ON p.ProductId=d.ProductID
                                WHERE d.PickBatchID = b.ID)
                                AS TotalAmount
                                FROM dbo.Shop AS s
                                LEFT OUTER JOIN dbo.GoodsPickingBatch AS b 
                                ON b.ShopID = s.shopID
                                WHERE s.courseTypeIds='2561'
                                ) AS tmp 
                                WHERE tmp.Id=1




SELECT s.shopID,s.shopName,b.PickTime ,b.PickManId,b.PickMan,
(SELECT SUM(p.Price * d.PickAmount) 
FROM dbo.ProductLibrary AS p
INNER JOIN dbo.GoodsPickingDetail AS d
ON p.ProductId=d.ProductID
WHERE d.PickBatchID = b.ID) AS TotalAmount
FROM dbo.Shop AS s
LEFT JOIN dbo.GoodsPickingBatch AS b 
ON b.ShopID = s.shopID
WHERE s.courseTypeIds='2561'

