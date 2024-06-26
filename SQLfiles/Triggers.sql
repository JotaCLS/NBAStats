

CREATE TRIGGER [dbo].[trg_increment_player]
ON [dbo].[Player]
AFTER INSERT
AS
BEGIN
    UPDATE bd_statistics
    SET num_players = num_players + 1
    WHERE id = 1;
END;


CREATE TRIGGER [dbo].[trg_decrement_player]
ON [dbo].[Player]
AFTER DELETE
AS
BEGIN
    UPDATE bd_statistics
    SET num_players = num_players - 1
    WHERE id = 1;
END;



CREATE TRIGGER [dbo].[trg_decrement_game]
ON [dbo].[Game]
AFTER DELETE
AS
BEGIN
    UPDATE bd_statistics
    SET num_games = num_games - 1
    WHERE id = 1;
END;


CREATE TRIGGER [dbo].[trg_increment_game]
ON [dbo].[Game]
AFTER INSERT
AS
BEGIN
    UPDATE bd_statistics
    SET num_games = num_games + 1
    WHERE id = 1;
END;

CREATE TRIGGER [dbo].[trg_decrement_coach]
ON [dbo].[Coach]
AFTER DELETE
AS
BEGIN
    UPDATE bd_statistics
    SET num_coaches = num_coaches - 1
    WHERE id = 1;
END;

CREATE TRIGGER [dbo].[trg_increment_coach]
ON [dbo].[Coach]
AFTER INSERT
AS
BEGIN
    UPDATE bd_statistics
    SET num_coaches = num_coaches + 1
    WHERE id = 1;
END;

CREATE TRIGGER [dbo].[trg_decrement_team]
ON [dbo].[Team]
AFTER DELETE
AS
BEGIN
    UPDATE bd_statistics
    SET num_teams = num_teams - 1
    WHERE id = 1;
END;

CREATE TRIGGER [dbo].[trg_increment_team]
ON [dbo].[Team]
AFTER INSERT
AS
BEGIN
    UPDATE bd_statistics
    SET num_teams = num_teams + 1
    WHERE id = 1;
END;
