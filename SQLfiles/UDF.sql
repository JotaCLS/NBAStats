
GO
ALTER FUNCTION [dbo].[GetTeams]()
RETURNS TABLE
AS
RETURN
(
    SELECT id, teamName, cityName, wins_losses, division_id FROM Team
);

GO
ALTER FUNCTION [dbo].[GetSponsorName] (@TeamId INT)
RETURNS NVARCHAR(100)
AS
BEGIN
    DECLARE @SponsorName NVARCHAR(100);

    SELECT @SponsorName = sponsorName
    FROM Sponsor
    WHERE team_id = @TeamId;

    RETURN @SponsorName;
END;

CREATE FUNCTION [dbo].[employeeDeptHighAverage](@departId  INT)
RETURNS @table TABLE (
	pname  VARCHAR(15), 
	pnumber INT, 
	plocation VARCHAR(15), 
	dnum INT, 
	budget FLOAT, 
	totalbudget FLOAT )
AS
BEGIN
	DECLARE C CURSOR
        FOR
            SELECT Pname, Pnumber, Plocation, Dnum, SUM((Salary*1.0*Hours)/40) AS Budget 
            FROM project JOIN works_on
            ON Pnumber=Pno
            JOIN employee
            ON Essn=Ssn
            WHERE Dnum=@departId
            GROUP BY Pnumber, Pname, Plocation, Dnum;
 
	DECLARE @pname AS VARCHAR(15), @pnumber AS INT, @plocation as VARCHAR(15), @dnum AS INT, @budget AS FLOAT, @totalbudget AS FLOAT;
	SET @totalbudget = 0;
    OPEN C;
	FETCH C INTO @pname, @pnumber, @plocation, @dnum, @budget;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @totalbudget += @budget;
		INSERT INTO @table VALUES (@pname, @pnumber, @plocation, @dnum, @budget, @totalbudget);
		FETCH C INTO @pname, @pnumber, @plocation, @dnum, @budget;
	END
	CLOSE C;
	DEALLOCATE C;
	RETURN;
END
