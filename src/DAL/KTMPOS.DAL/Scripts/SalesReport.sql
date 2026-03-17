SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sumit Bhattarai
-- Create date: 01/30/2026
-- Description:	Get sales report by date range
-- =============================================
CREATE PROCEDURE usp_get_sales_report
	@startDate DATETIME2(7),
	@endDate DATETIME2(7)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 1 AS SN, ISNULL(SUM(GrandTotal), 0) AS TotalGrossAmount, ISNULL(SUM(DiscountAmount), 0) AS TotalDiscountAmount,
	ISNULL(SUM(NetTotal), 0) AS TotalNetAmount, ISNULL(COUNT(Id), 0) AS TotalRecords
	FROM Sales
	WHERE CreatedDate >= @startDate AND CreatedDate < @endDate;

END
GO
