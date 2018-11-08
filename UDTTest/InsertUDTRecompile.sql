CREATE PROCEDURE [dbo].[InsertUDT]
	@param [dbo].[userdefinedtabletype] readonly
	WITH RECOMPILE
AS
	INSERT INTO UDTTestTable (ID, Name)
	SELECT ID, Name
	FROM @param
RETURN 0
