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
