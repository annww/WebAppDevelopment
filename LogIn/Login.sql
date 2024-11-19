USE [loginTest]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_Account_Login]
    @username varchar(20),
    @password varchar(20)
AS
BEGIN
    DECLARE @count INT;
    DECLARE @res BIT;
    SELECT @count = COUNT(*) FROM Account WHERE username = @username AND password = @password;
    IF @count > 0
        SET @res = 1;
    ELSE
        SET @res = 0;
    SELECT @res;
END;