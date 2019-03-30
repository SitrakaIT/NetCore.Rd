CREATE PROCEDURE dbo.sp_ApartmentSearchByName
	@ApartmentName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;  
    SELECT ApartmentNumber, IdentifierApartment, ApartmentName  
    FROM Apartment
    WHERE ApartmentName Like CONCAT('%', @ApartmentName, '%')
	AND DateEdition IS NOT NULL
END