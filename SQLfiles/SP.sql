
CREATE PROCEDURE [dbo].[AddCoachToTeam]
    @CoachName NVARCHAR(100),
    @CoachAge NVARCHAR(100),
    @TeamName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CoachId INT;
    DECLARE @SquadId INT;

    -- Obter o último ID na tabela Coach e incrementar em 1
    SET @CoachId = (SELECT ISNULL(MAX(id), 0) + 1 FROM Coach);

    -- Obter o Squad associado ao time
    SELECT @SquadId = s.id
    FROM Squad s
    INNER JOIN Team t ON s.team_id = t.id
    WHERE t.teamName = @TeamName;

    IF @SquadId IS NULL
    BEGIN
        RAISERROR('Team not found', 16, 1);
        RETURN;
    END

    -- Verificar se o time já possui um treinador
    IF EXISTS (SELECT 1 FROM Squad_Coach WHERE squadId = @SquadId)
    BEGIN
        RAISERROR('Team already has a coach', 16, 1);
        RETURN;
    END

    -- Inserir o novo treinador na tabela Coach
    INSERT INTO Coach (id, coachName, coachAge) VALUES (@CoachId, @CoachName, @CoachAge);

    -- Inserir a associação na tabela Squad_Coach
    INSERT INTO Squad_Coach (squadId, coachId) VALUES (@SquadId, @CoachId);
END;


CREATE PROCEDURE [dbo].[AddGame]
    @Date DATE,
    @HomeTeamName NVARCHAR(100),
    @AwayTeamName NVARCHAR(100),
    @HomeTeamPoints INT,
    @AwayTeamPoints INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @GameId INT;
    DECLARE @HomeTeamId INT;
    DECLARE @AwayTeamId INT;
    DECLARE @GameWinner NVARCHAR(100);
    DECLARE @StatisticsHomeTeamId INT;
    DECLARE @StatisticsAwayTeamId INT;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Determine the game winner
        IF @HomeTeamPoints > @AwayTeamPoints
            SET @GameWinner = @HomeTeamName;
        ELSE IF @AwayTeamPoints > @HomeTeamPoints
            SET @GameWinner = @AwayTeamName;
        ELSE
            SET @GameWinner = NULL;

        -- Get the team IDs from the team names
        SELECT @HomeTeamId = id
        FROM team
        WHERE teamName = @HomeTeamName;

        IF @HomeTeamId IS NULL
        BEGIN
            RAISERROR('Home team not found', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        SELECT @AwayTeamId = id
        FROM team
        WHERE teamName = @AwayTeamName;

        IF @AwayTeamId IS NULL
        BEGIN
            RAISERROR('Away team not found', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Get the next GameId
        SELECT @GameId = ISNULL(MAX(id), 0) + 1 FROM game;

        -- Insert the new game
        INSERT INTO game (id, gameDate, gameWinner, season_id)
        VALUES (@GameId, @Date, @GameWinner, 1);

        SELECT @StatisticsHomeTeamId = ISNULL(MAX(id), 0) + 1 FROM Statistics_home_team;

        -- Insert into statistics_home_team
        INSERT INTO statistics_home_team (id, game_id, team_id, points, fgm, fga, threeptm, threepta, ftm, fta, offReb, defReb, assists, steals, blocks, tov, fouls)
        VALUES (@StatisticsHomeTeamId, @GameId, @HomeTeamId, @HomeTeamPoints,0,0,0,0,0,0,0,0,0,0,0,0,0);

        SELECT @StatisticsAwayTeamId = ISNULL(MAX(id), 0) + 1 FROM Statistics_away_team;

        -- Insert into statistics_away_team
        INSERT INTO statistics_away_team (id, game_id, team_id, points, fgm, fga, threeptm, threepta, ftm, fta, offReb, defReb, assists, steals, blocks, tov, fouls)
        VALUES (@StatisticsAwayTeamId, @GameId, @AwayTeamId, @AwayTeamPoints,0,0,0,0,0,0,0,0,0,0,0,0,0);

        COMMIT TRANSACTION;

        -- Return the GameId
        SELECT @GameId AS GameId;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

CREATE PROCEDURE [dbo].[AddPlayer]
    @PlayerName NVARCHAR(50),
    @PlayerAge INT,
    @PlayerPosition NVARCHAR(20),
    @PlayerHeight FLOAT,
    @PlayerWeight FLOAT,
    @TeamName NVARCHAR(50)
AS
BEGIN
    DECLARE @TeamId INT;
    DECLARE @NewPlayerId INT;

    -- Obter o TeamId baseado no TeamName
    SELECT @TeamId = id FROM Team WHERE teamName = @TeamName;

    IF @TeamId IS NULL
    BEGIN
        RAISERROR ('Team not found', 16, 1);
        RETURN;
    END

    -- Calcular o próximo ID para o novo jogador
    SELECT @NewPlayerId = ISNULL(MAX(id), 0) + 1 FROM Player;

    -- Inserir o novo jogador na tabela Player
    INSERT INTO Player (id, playerName, playerAge, playerPosition, playerHeight, playerWeight)
    VALUES (@NewPlayerId, @PlayerName, @PlayerAge, @PlayerPosition, @PlayerHeight, @PlayerWeight);

    -- Inserir a relação na tabela squad_player
    INSERT INTO squad_player (squadId, playerId)
    SELECT id, @NewPlayerId
    FROM Squad
    WHERE team_id = @TeamId;
END

CREATE PROCEDURE [dbo].[CalculateTotalPointsPerPlayer]
AS
BEGIN
    DECLARE @playerId INT,
            @prevPlayerId INT = NULL, -- Variável para armazenar o playerId anterior
            @gameId INT,
            @fgm INT,
            @fga INT,
            @threeptm INT,
            @threepta INT,
            @ftm INT,
            @fta INT,
            @offreb INT,
            @defreb INT,
            @assists INT,
            @blocks INT,
            @tov INT,
            @fouls INT,
            @points INT,
            @plus_minus INT,
            @totalPoints INT = 0; -- Variável para acumular os pontos totais
    
    -- Declare o cursor com a consulta
    DECLARE cursor_name CURSOR FOR
    SELECT playerId, gameId, fgm, fga, threeptm, threepta, ftm, fta, offreb, defreb, assists, blocks, tov, fouls, points, plus_minus
    FROM Statistics_player
    ORDER BY playerId; -- Garanta que os registros estejam ordenados por playerId

    OPEN cursor_name;

    FETCH NEXT FROM cursor_name INTO @playerId, @gameId, @fgm, @fga, @threeptm, @threepta, @ftm, @fta, @offreb, @defreb, @assists, @blocks, @tov, @fouls, @points, @plus_minus;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Calcule os pontos totais para o jogador atual
        SET @points = (@fgm * 2) + (@threeptm * 3) + (@ftm);
        
        -- Acumule os pontos totais
        SET @totalPoints = @totalPoints + @points;

        -- Verifique se estamos mudando de jogador
        IF @prevPlayerId IS NOT NULL AND @prevPlayerId!= @playerId
        BEGIN
            -- Imprima os pontos totais para o jogador anterior
            PRINT 'Player ID: ' + CAST(@prevPlayerId AS VARCHAR) + ', Total Points: ' + CAST(@totalPoints AS VARCHAR);
            
            -- Reinitialize os pontos totais para o novo jogador
            SET @totalPoints = 0;
        END
        
        -- Prepare para a próxima iteração
        SET @prevPlayerId = @playerId;
        FETCH NEXT FROM cursor_name INTO @playerId, @gameId, @fgm, @fga, @threeptm, @threepta, @ftm, @fta, @offreb, @defreb, @assists, @blocks, @tov, @fouls, @points, @plus_minus;
    END

    -- Imprima os pontos totais para o último jogador
    PRINT 'Player ID: ' + CAST(@playerId AS VARCHAR) + ', Total Points: ' + CAST(@totalPoints AS VARCHAR);

    CLOSE cursor_name;
    DEALLOCATE cursor_name;
END

CREATE PROCEDURE [dbo].[DeleteCoachById]
    @CoachId INT,
    @TeamName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM Coach WHERE id = @CoachId)
        BEGIN
            RAISERROR('Coach not found', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        DECLARE @SquadId INT;
        SELECT @SquadId = s.id
        FROM Squad s
        JOIN Team t ON s.team_id = t.id
        WHERE t.teamName = @TeamName;

        IF @SquadId IS NOT NULL
        BEGIN
            DELETE FROM Squad_Coach WHERE squadId = @SquadId AND coachId = @CoachId;
        END

        DELETE FROM Coach WHERE id = @CoachId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

CREATE PROCEDURE [dbo].[DeleteGame]
    @GameId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Delete from statistics_home_team
        DELETE FROM statistics_home_team
        WHERE game_id = @GameId;

        -- Delete from statistics_away_team
        DELETE FROM statistics_away_team
        WHERE game_id = @GameId;

        -- Delete from game
        DELETE FROM game
        WHERE id = @GameId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

CREATE PROCEDURE [dbo].[DeletePlayerById]
    @PlayerId INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Player WHERE id = @PlayerId)
    BEGIN
        DELETE FROM squad_player WHERE playerId = @PlayerId;
        DELETE FROM Player WHERE id = @PlayerId;
    END
    ELSE
    BEGIN
        RAISERROR ('Player not found', 16, 1);
    END
END

CREATE PROCEDURE [dbo].[EditAwayTeamStatistics]
    @GameId INT,
    @AwayTeamName NVARCHAR(100),
    @FGM INT,
    @FGA INT,
    @ThreePTM INT,
    @ThreePTA INT,
    @FTM INT,
    @FTA INT,
    @OffReb INT,
    @DefReb INT,
    @Assists INT,
    @Steals INT,
    @Blocks INT,
    @TOV INT,
    @Fouls INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AwayTeamId INT;

    -- Get the team ID from the team name
    SELECT @AwayTeamId = id
    FROM team
    WHERE teamName = @AwayTeamName;

    -- Update away team statistics
    UPDATE statistics_away_team
    SET 
        fgm = @FGM,
        fga = @FGA,
        threeptm = @ThreePTM,
        threepta = @ThreePTA,
        ftm = @FTM,
        fta = @FTA,
        offReb = @OffReb,
        defReb = @DefReb,
        assists = @Assists,
        steals = @Steals,
        blocks = @Blocks,
        tov = @TOV,
        fouls = @Fouls
    WHERE game_id = @GameId AND team_id = @AwayTeamId;
END;

CREATE PROCEDURE [dbo].[EditGame]
    @GameId INT,
    @Date DATE,
    @HomeTeamName NVARCHAR(100),
    @AwayTeamName NVARCHAR(100),
    @HomeTeamPoints INT,
    @AwayTeamPoints INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @HomeTeamId INT;
    DECLARE @AwayTeamId INT;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Get the team IDs from the team names
        SELECT @HomeTeamId = id
        FROM team
        WHERE teamName = @HomeTeamName;

        IF @HomeTeamId IS NULL
        BEGIN
            RAISERROR('Home team not found', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        SELECT @AwayTeamId = id
        FROM team
        WHERE teamName = @AwayTeamName;

        IF @AwayTeamId IS NULL
        BEGIN
            RAISERROR('Away team not found', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Update the game
        UPDATE game
        SET gameDate = @Date
        WHERE Id = @GameId;

        -- Update statistics for home team
        UPDATE statistics_home_team
        SET points = @HomeTeamPoints
        WHERE game_id = @GameId AND team_id = @HomeTeamId;

        -- Update statistics for away team
        UPDATE statistics_away_team
        SET points = @AwayTeamPoints
        WHERE game_id = @GameId AND team_id = @AwayTeamId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

CREATE PROCEDURE [dbo].[EditHomeTeamStatistics]
    @GameId INT,
    @HomeTeamName NVARCHAR(100),
    @FGM INT,
    @FGA INT,
    @ThreePTM INT,
    @ThreePTA INT,
    @FTM INT,
    @FTA INT,
    @OffReb INT,
    @DefReb INT,
    @Assists INT,
    @Steals INT,
    @Blocks INT,
    @TOV INT,
    @Fouls INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @HomeTeamId INT;

    -- Get the team ID from the team name
    SELECT @HomeTeamId = id
    FROM team
    WHERE teamName = @HomeTeamName;

    -- Update home team statistics
    UPDATE statistics_home_team
    SET 
        fgm = @FGM,
        fga = @FGA,
        threeptm = @ThreePTM,
        threepta = @ThreePTA,
        ftm = @FTM,
        fta = @FTA,
        offReb = @OffReb,
        defReb = @DefReb,
        assists = @Assists,
        steals = @Steals,
        blocks = @Blocks,
        tov = @TOV,
        fouls = @Fouls
    WHERE game_id = @GameId AND team_id = @HomeTeamId;
END;

CREATE PROCEDURE [dbo].[EditPlayer]
    @PlayerId INT,
    @PlayerName NVARCHAR(50),
    @PlayerAge INT,
    @PlayerPosition NVARCHAR(20),
    @PlayerHeight FLOAT,
    @PlayerWeight FLOAT
AS
BEGIN
    UPDATE Player
    SET playerName = @PlayerName,
        playerAge = @PlayerAge,
        playerPosition = @PlayerPosition,
        playerHeight = @PlayerHeight,
        playerWeight = @PlayerWeight
    WHERE id = @PlayerId;
END

CREATE PROCEDURE [dbo].[EditPlayerStatistics]
    @GameId INT,
    @PlayerId INT,
    @FGM INT,
    @FGA INT,
    @ThreePTM INT,
    @ThreePTA INT,
    @FTM INT,
    @FTA INT,
    @OffReb INT,
    @DefReb INT,
    @Assists INT,
    @Steals INT,
    @Blocks INT,
    @TOV INT,
    @Fouls INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE statistics_player
    SET 
        fgm = @FGM,
        fga = @FGA,
        threeptm = @ThreePTM,
        threepta = @ThreePTA,
        ftm = @FTM,
        fta = @FTA,
        offReb = @OffReb,
        defReb = @DefReb,
        assists = @Assists,
        steals = @Steals,
        blocks = @Blocks,
        tov = @TOV,
        fouls = @Fouls
    WHERE 
        gameid = @GameId
        AND playerid = @PlayerId;
END;

CREATE PROCEDURE [dbo].[GetGamesByTeam]
    @TeamId INT
AS
BEGIN
    SELECT G.id AS GameId, G.gameDate, G.season_Id, 
           TH.teamName AS HomeTeamName, SH.points AS HomeTeamPoints, 
           TA.teamName AS AwayTeamName, SA.points AS AwayTeamPoints
    FROM Game G
    LEFT JOIN Statistics_Home_Team SH ON G.id = SH.game_id
    LEFT JOIN Statistics_Away_Team SA ON G.id = SA.game_id
    LEFT JOIN Team TH ON SH.team_id = TH.id
    LEFT JOIN Team TA ON SA.team_id = TA.id
    WHERE SH.team_id = @TeamId OR SA.team_id = @TeamId;
END

GO
ALTER PROCEDURE [dbo].[GetGamesByTeamName]
    @TeamName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Declare a temporary table to hold the results
    DECLARE @TeamId INT;

    -- Get the team ID from the team name
    SELECT @TeamId = id
    FROM team
    WHERE teamName = @TeamName;

    -- Check if team exists
    IF @TeamId IS NULL
    BEGIN
        RAISERROR('Team not found', 16, 1);
        RETURN;
    END

    -- Select the games involving the team as home or away team
    SELECT
        g.id AS GameId,
        g.gameDate AS GameDate,
        g.season_id AS season_id,
        ht.teamName AS HomeTeamName,
        sht.points AS HomeTeamPoints,
        at.teamName AS AwayTeamName,
        sat.points AS AwayTeamPoints
		
    FROM
        game g
    INNER JOIN statistics_home_team sht ON g.id = sht.game_id
    INNER JOIN team ht ON sht.team_id = ht.id
    INNER JOIN statistics_away_team sat ON g.id = sat.game_id
    INNER JOIN team at ON sat.team_id = at.id
    WHERE
        sht.team_id = @TeamId OR sat.team_id = @TeamId
    ORDER BY
        g.gameDate;

    SET NOCOUNT OFF;
END

CREATE PROCEDURE [dbo].[GetGameStatistics]
    @GameId INT,
    @HomeTeamName NVARCHAR(100),
    @AwayTeamName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @HomeTeamId INT;
    DECLARE @AwayTeamId INT;

    -- Get the team IDs from the team names
    SELECT @HomeTeamId = id
    FROM team
    WHERE teamName = @HomeTeamName;

    SELECT @AwayTeamId = id
    FROM team
    WHERE teamName = @AwayTeamName;

    -- Get home team statistics
    SELECT 
        s.fgm AS home_fgm,
        s.fga AS home_fga,
        s.threeptm AS home_threeptm,
        s.threepta AS home_threepta,
        s.ftm AS home_ftm,
        s.fga AS home_fta,
        s.offReb AS home_offReb,
        s.defReb AS home_defReb,
        s.assists AS home_assists,
        s.steals AS home_steals,
        s.blocks AS home_blocks,
        s.tov AS home_tov,
        s.fouls AS home_fouls
    FROM statistics_home_team s
    WHERE s.game_id = @GameId AND s.team_id = @HomeTeamId;

    -- Get away team statistics
    SELECT 
        s.fgm AS away_fgm,
        s.fga AS away_fga,
        s.threeptm AS away_threeptm,
        s.threepta AS away_threepta,
        s.ftm AS away_ftm,
        s.fga AS away_fta,
        s.offReb AS away_offReb,
        s.defReb AS away_defReb,
        s.assists AS away_assists,
        s.steals AS away_steals,
        s.blocks AS away_blocks,
        s.tov AS away_tov,
        s.fouls AS away_fouls
    FROM statistics_away_team s
    WHERE s.game_id = @GameId AND s.team_id = @AwayTeamId;
END;

CREATE PROCEDURE [dbo].[GetPlayersByGameId]
    @GameId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id,
        p.PlayerName AS PlayerName,
        p.PlayerPosition AS PlayerPosition,
        p.PlayerWeight AS PlayerWeight,
        p.PlayerHeight AS PlayerHeight,
        p.PlayerAge AS PlayerAge
    FROM 
        statistics_player sp
    INNER JOIN 
        player p ON sp.playerId = p.Id
    WHERE 
        sp.gameid = @GameId;
END;

CREATE PROCEDURE [dbo].[GetPlayerStatistics]
    @PlayerId INT
AS
BEGIN
    SELECT 
        AVG(CAST(DATEDIFF(SECOND, '00:00:00', mins) AS FLOAT)) as avg_seconds, 
        AVG(CAST(fgm AS FLOAT)) as fgm, 
        AVG(CAST(fga AS FLOAT)) as fga, 
        AVG(CAST(threeptm AS FLOAT)) as threeptm, 
        AVG(CAST(threepta AS FLOAT)) as threepta, 
        AVG(CAST(ftm AS FLOAT)) as ftm, 
        AVG(CAST(fta AS FLOAT)) as fta, 
        AVG(CAST(offreb AS FLOAT)) as offreb, 
        AVG(CAST(defreb AS FLOAT)) as defreb, 
        AVG(CAST(assists AS FLOAT)) as assists, 
        AVG(CAST(steals AS FLOAT)) as steals, 
        AVG(CAST(blocks AS FLOAT)) as blocks, 
        AVG(CAST(tov AS FLOAT)) as tov, 
        AVG(CAST(fouls AS FLOAT)) as fouls, 
        AVG(CAST(points AS FLOAT)) as points, 
        AVG(CAST(plus_minus AS FLOAT)) as plus_minus
    FROM 
        statistics_player
    WHERE 
        playerid = @PlayerId
END

CREATE PROCEDURE [dbo].[GetPlayerStatisticsAdmin]
    @GameId INT,
    @PlayerId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        sp.fgm,
        sp.fga,
        sp.threeptm,
        sp.threepta,
        sp.ftm,
        sp.fta,
        sp.offReb,
        sp.defReb,
        sp.assists,
        sp.steals,
        sp.blocks,
        sp.tov,
        sp.fouls
    FROM 
        statistics_player sp
    WHERE 
        sp.gameid = @GameId
        AND sp.playerid = @PlayerId;
END;

CREATE PROCEDURE [dbo].[GetSquadByTeam]
    @TeamId INT,
    @Year INT
AS
BEGIN
    SELECT PlayerId, playerName, playerAge, playerPosition, playerHeight, playerWeight
    FROM SquadPlayersView
    WHERE TeamId = @TeamId AND squadYear = @Year;
END

CREATE PROCEDURE [dbo].[GetSquadByTeamIdAndYear]
    @TeamId INT,
    @Year INT
AS
BEGIN
    SELECT P.id AS PlayerId, P.playerName AS PlayerName, P.playerAge AS PlayerAge, 
           P.playerPosition AS PlayerPosition, P.playerHeight AS PlayerHeight, P.playerWeight AS PlayerWeight
    FROM Player P
    JOIN Squad_Player SP ON P.id = SP.playerId
    JOIN Squad S ON SP.squadId = S.id
    WHERE S.team_id = @TeamId AND S.squadYear = @Year;
END;

CREATE PROCEDURE [dbo].[GetTeamByName]
    @TeamName NVARCHAR(100)
AS
BEGIN
    SELECT 
        T.id, 
        T.teamName, 
        T.cityName, 
        T.wins_losses, 
        T.division_id, 
        D.divisionName, 
        C.conferenceName,
        CoachDetails.coachName,
        CoachDetails.coachAge,
        CoachDetails.Id
    FROM 
        Team T
    JOIN 
        Division D ON T.division_id = D.id
    JOIN 
        Conference C ON D.conference_id = C.id
    OUTER APPLY
        (SELECT 
            C.coachName,
            C.coachAge AS coachAge,
            C.id AS Id
         FROM 
            Squad S
         JOIN 
            Squad_Coach SC ON S.id = SC.squadId
         JOIN 
            Coach C ON SC.coachId = C.id
         WHERE 
            S.team_id = T.id 
            AND S.squadYear = YEAR(GETDATE())
        ) AS CoachDetails
    WHERE 
        T.teamName = @TeamName;
END;

CREATE PROCEDURE [dbo].[GetTeamDetails]
    @teamId INT
AS
BEGIN
    SELECT 
        t.id AS TeamId,
        c.coachName AS CoachName,
        d.divisionName AS DivisionName,
        cf.conferenceName AS ConferenceName
    FROM 
        Team t
    LEFT JOIN 
        Squad s ON t.id = s.team_id
    LEFT JOIN 
        Squad_Coach sc ON s.id = sc.squadId
    LEFT JOIN 
        Coach c ON sc.coachId = c.id
    LEFT JOIN 
        Division d ON t.division_id = d.id
    LEFT JOIN 
        Conference cf ON d.conference_id = cf.id
    WHERE 
        t.id = @teamId;
END;

CREATE PROCEDURE [dbo].[GetTeamsByConference]
    @ConferenceName NVARCHAR(50)
AS
BEGIN
    SELECT T.*
    FROM Team T
    JOIN Division D ON T.division_id = D.id
    JOIN Conference C ON D.conference_id = C.id
    WHERE C.conferenceName = @ConferenceName;
END

CREATE PROCEDURE [dbo].[GetTeamsByDivision]
    @DivisionName NVARCHAR(50)
AS
BEGIN
    SELECT T.*
    FROM Team T
    JOIN Division D ON T.division_id = D.id
    WHERE D.divisionName = @DivisionName;
END

CREATE PROCEDURE [dbo].[SearchTeamByName]
    @TeamName NVARCHAR(100)
AS
BEGIN
    SELECT id, teamName, cityName, wins_losses, division_id
    FROM Team
    WHERE teamName LIKE '%' + @TeamName + '%';
END;

CREATE PROCEDURE [dbo].[UpdateCoach]
    @CoachId INT,
    @CoachName NVARCHAR(100),
    @CoachAge INT  
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar se o treinador existe
    IF NOT EXISTS (SELECT 1 FROM Coach WHERE id = @CoachId)
    BEGIN
        RAISERROR('Coach not found', 16, 1);
        RETURN;
    END


    UPDATE Coach SET 
        coachName = @CoachName,
        coachAge = @CoachAge  
    WHERE id = @CoachId;
END;
