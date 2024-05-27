--insert into Season values (1, 2024, NULL)
--select * from Season

--insert into Conference values (1, 'East', NULL)
--insert into Conference values (2, 'West', NULL)
--select * from Conference

--insert into Division values (1, 'Atlantic', 1)
--insert into Division values (2, 'Central', 1)
--insert into Division values (3, 'Southeast', 1)
--insert into Division values (4, 'Northwest', 2)
--insert into Division values (5, 'Pacific', 2)
--insert into Division values (6, 'Southwest', 2)
--select * from Division

--insert into Team values (1, 'Mavericks', 'Dallas', '50-32', 6)
--insert into Team values (2, 'Timberwolves', 'Minnesota', '56-26', 4)
--select * from Team

--insert into Sponsor values (1, 'Chime', 'www.chime.com', 1)
--insert into Sponsor values (2, 'Aura', 'www.aura.com', 2)
--select * from Sponsor

--insert into Coach values (1, 'Chris Finch', 54)
--insert into Coach values (2, 'Jason Kidd', 51)
select * from Coach

--insert into Squad values (1, 2024, 1)
--insert into Squad values (2, 2024, 2)
select * from Squad

--insert into Squad_Coach values (1, 2)
--insert into Squad_Coach values (2, 1)
select * from Squad_Coach

--insert into Player values 
--(1, 'Dante Exum', 28, 'PG', 196, 97),
--(2, 'Jaden Hardy', 21, 'SG', 193, 89),
--(3, 'Dereck Lively II', 20, 'C', 216, 104),
--(4, 'Dwight Powell', 32, 'C/PF', 208, 108),
--(5, 'Josh Green', 23, 'SG', 196, 90),
--(6, 'A.J. Lawson', 23, 'SG', 198, 91),
--(7, 'Tim Hardaway Jr.', 32, 'SG/SF', 196, 92),
--(8, 'Kyrie Irving', 32, 'PG/SG', 188, 88),
--(9, 'Olivier-Maxence Prosper', 21, 'PF', 203, 104),
--(10, 'Daniel Gafford', 25, 'C/PF', 208, 106),
--(11, 'P.J. Washington', 25, 'PF/C', 201, 104),
--(12, 'Maxi Kleber', 32, 'PF/C', 208, 108),
--(13, 'Derrick Jones Jr.', 27, 'SF/PF', 196, 95),
--(14, 'Luka Doncic', 25, 'PG/SG', 201, 104),
--(15, 'Markieff Morris', 34, 'PF', 206, 111),
--(16, 'Kyle Anderson', 30, 'SF/PF', 206, 104),
--(17, 'Jaden McDaniels', 23, 'SF/PF', 206, 83),
--(18, 'Anthony Edwards', 22, 'SG', 193, 102),
--(19, 'Jordan McLaughlin', 28, 'PG', 183, 83),
--(20, 'Wendell Moore Jr.', 22, 'SG', 196, 96),
--(21, 'Josh Minott', 21, 'SF', 203, 92),
--(22, 'Nickeil Alexander-Walker', 25, 'SG', 196, 92),
--(23, 'Mike Conley', 36, 'PG', 183, 79),
--(24, 'Naz Reid', 24, 'C', 206, 119),
--(25, 'Monte Morris', 28, 'PG', 188, 83),
--(26, 'T.J. Warren', 30, 'SF/PF', 203, 99),
--(27, 'Rudy Gobert', 31, 'C', 216, 117),
--(28, 'Karl-Anthony Towns', 28, 'C/PF', 213, 112),
--(29, 'Leonard Miller', 20, 'SF', 208, 95),
--(30, 'Luka Garza', 25, 'C', 208, 106)
--select * from Player


select * from Squad_Player
--insert into Game values (1, '2024-05-22', 1, 1)
--select * from Game

--insert into Statistics_Away_Team values 
--(1, 1, 1, 43, 87, 6, 25, 16, 17, 11, 37, 21, 5, 8, 13, 15, 108)
--select * from Statistics_Away_Team

--insert into Statistics_Home_Team values
--(1, 1, 2, 38, 89, 18, 49, 11, 18, 10, 30, 23, 8, 3, 10, 17, 105)
--select * from Statistics_Home_Team

--insert into Statistics_Player values
--(11, 1, '00:40:50', 4, 10, 2, 8, 3, 3, 0, 7, 0, 0, 2, 3, 4, 12, 12),
--(14, 1, '00:40:45', 12, 26, 3, 10, 6, 7, 0, 6, 8, 3, 1, 4, 2, 33, -9),
--(8, 1, '00:40:09', 12, 23, 0, 3, 6, 6, 1, 4, 4, 0, 1, 2, 3, 30, 5),
--(13, 1, '00:34:55', 4, 9, 0, 2, 0, 0, 2, 2, 2, 0, 0, 0, 1, 8, -8),
--(10, 1, '00:21:07', 5, 9, 0, 0, 0, 0, 4, 5, 0, 0, 1, 2, 2, 10, -15),
--(3, 1, '00:26:31', 4, 4, 0, 0, 1, 1, 4, 7, 3, 0, 2, 1, 1, 9, 19),
--(5, 1, '00:13:26', 1, 4, 1, 2, 0, 0, 0, 1, 0, 0, 1, 1, 1, 3, -1),
--(7, 1, '00:10:22', 0, 0, 0, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0, 0, 7),
--(2, 1, '00:08:59', 1, 2, 0, 0, 0, 0, 0, 1, 4, 1, 0, 0, 1, 2, 4),
--(1, 1, '00:02:56', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1),
--(18, 1, '00:40:43', 6, 16, 5, 12, 2, 2, 2, 9, 8, 2, 0, 3, 1, 19, -1),
--(17, 1, '00:39:18', 9, 15, 6, 9, 0, 0, 2, 2, 3, 1, 0, 3, 4, 24, -4),
--(27, 1, '00:37:36', 4, 8, 0, 0, 4, 6, 1, 6, 1, 1, 2, 0, 3, 12, 10),
--(28, 1, '00:34:23', 6, 20, 3, 9, 2, 2, 3, 4, 2, 1, 0, 1, 2, 16, -5),
--(23, 1, '00:30:48', 2, 7, 1, 6, 1, 4, 0, 3, 3, 2, 0, 1, 2, 6, 1),
--(24, 1, '00:24:02', 5, 9, 3, 6, 2, 4, 1, 4, 2, 1, 1, 2, 2, 15, -11),
--(16, 1, '00:17:07', 5, 8, 1, 3, 0, 0, 1, 1, 2, 0, 0, 0, 2, 11, 0),
--(22, 1, '00:16:03', 1, 6, 0, 4, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, -5)
--(22, 1, '00:16:03', 1, 6, 0, 4, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, -5)
--select * from Statistics_Player