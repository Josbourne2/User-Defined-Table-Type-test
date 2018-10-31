CREATE PROCEDURE [dbo].[InsertUDT]
	@param [dbo].[userdefinedtabletype] readonly
	
AS
	INSERT INTO UDTTestTable (ID, Name)
	SELECT ID, Name
	FROM @param
RETURN 0
