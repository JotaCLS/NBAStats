
CREATE VIEW SquadPlayersView
AS
SELECT P.id AS PlayerId, P.playerName, P.playerAge, P.playerPosition, P.playerHeight, P.playerWeight,
       S.team_id AS TeamId, S.squadYear
FROM Player P
INNER JOIN Squad_Player SP ON P.id = SP.playerId
INNER JOIN Squad S ON SP.squadId = S.id;

CREATE VIEW TeamStatisticsView
AS 
SELECT SH.game_id AS GameId, SH.team_id AS TeamId, 'Home' AS Location, SH.points AS Points 
FROM Statistics_Home_Team SH  
UNION ALL  
SELECT SA.game_id AS GameId, SA.team_id AS TeamId, 'Away' AS Location, SA.points AS Points 
FROM Statistics_Away_Team SA;  