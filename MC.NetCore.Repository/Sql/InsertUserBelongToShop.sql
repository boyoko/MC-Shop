
DECLARE @userid UNIQUEIDENTIFIER;
DECLARE @shopid int;
DECLARE @shopname nvarchar(200);
DECLARE @hasInserted BIT;

set @userid = (select userid from shopuserinfo where username='mhr');
set @shopname = '诚信小铺--海尔三层';
set @shopid = (select shopID from shop where shopName=@shopname);
SET @hasInserted = (
					SELECT COUNT(*) FROM dbo.UserBelongToShop as u where shopid in
					(SELECT ShopId FROM dbo.UserBelongToShop where ShopId=@shopid)
					);

if(@hasInserted>0)
return;

if(@shopid>0)
	BEGIN
		print @shopid;
		INSERT INTO [dbo].[UserBelongToShop]
				   ([Id]
				   ,[UserId]
				   ,[ShopId])
			 VALUES
				   (NEWID()
				   ,@userid
				   ,@shopid);
		print 'OK';
	END
ELSE
	BEGIN
		PRINT '没有数据 ！';
	END

