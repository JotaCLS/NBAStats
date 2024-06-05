
CREATE VIEW SquadPlayersView
AS
SELECT P.id AS PlayerId, P.playerName, P.playerAge, P.playerPosition, P.playerHeight, P.playerWeight,
       S.team_id AS TeamId, S.squadYear
FROM Player P
INNER JOIN Squad_Player SP ON P.id = SP.playerId
INNER JOIN Squad S ON SP.squadId = S.id;