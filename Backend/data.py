from nba_api.stats.endpoints import leaguestandings, commonteamroster, scoreboardv2, boxscoretraditionalv2
from datetime import datetime, timedelta
import csv

Game_Stats = None
Statistics_Away_Team = None
Statistics_Home_Team = None
Statistics_Player = None
Team_data = None
Player_data = None 
Coach_data = None
Squad_data = None
Squad_Player_data = None
Squad_Coach_data = None

firstday = '2023-10-24'
lastday = '2024-04-14'

divisions = ['Atlantic', 'Central', 'Southeast', 'Northwest', 'Pacific', 'Southwest']

gw_header = ['id', 'gameDate', 'gameWinner', 'season_id']
sat_header = ['id', 'game_id', 'team_id', 'fgm', 'fga', 'threeptm', 'threepta', 'ftm', 'fta', 'offReb', 'defReb', 'assists', 'steals', 'blocks', 'tov', 'fouls', 'points']
sht_header = ['id', 'game_id', 'team_id', 'fgm', 'fga', 'threeptm', 'threepta', 'ftm', 'fta', 'offReb', 'defReb', 'assists', 'steals', 'blocks', 'tov', 'fouls', 'points']
sp_header = ['player_id', 'game_id', 'mins', 'fgm', 'fga', 'threeptm', 'threepta', 'ftm', 'fta', 'offReb', 'defReb', 'assists', 'steals', 'blocks', 'tov', 'fouls', 'points', 'plus_minus']

def get_season_dates():
    start_date = datetime.strptime(firstday, '%Y-%m-%d')
    end_date = datetime.strptime(lastday, '%Y-%m-%d')

    date_list = []

    current_date = start_date
    while current_date <= end_date:
        date_list.append(current_date.strftime('%Y-%m-%d'))
        current_date += timedelta(days=1)

    return date_list


def game_data():
    sat_id = 1
    sht_id = 1

    gw_file = open('gamedata.csv', 'w', newline='')
    gw_writer = csv.writer(gw_file)
    gw_writer.writerow(gw_header)
    sat_file = open('satdata.csv', 'w', newline='')
    sat_writer = csv.writer(sat_file)
    sat_writer.writerow(sat_header)
    sht_file = open('shtdata.csv', 'w', newline='')
    sht_writer = csv.writer(sht_file)
    sht_writer.writerow(sht_header)
    sp_file = open('spdata.csv', 'w', newline='')
    sp_writer = csv.writer(sp_file)
    sp_writer.writerow(sp_header)

    dates = get_season_dates()

    for game_date in dates:
        scoreboard_data = scoreboardv2.ScoreboardV2(game_date=game_date)

        gameHeader = scoreboard_data.get_dict()['resultSets'][1]['rowSet']
        games = []

        print(f'Games on {game_date}:')
        # print('-------------------')

        for game in gameHeader:
            games.append(game[2])
            
        games = list(dict.fromkeys(games))
        #print(games)
        #print('-------------------')

        for game in games:
            box = boxscoretraditionalv2.BoxScoreTraditionalV2(game_id=game).get_dict()
            # print(box.get('resultSets')[0]['headers'])
            # print('-------------------')
            
            players = box.get('resultSets')[0]['rowSet']
            for player in players:
                if player[9] == None:
                    continue
                mins = player[9].split(':')
                Statistics_Player = [player[4], int(player[0]), str(f'00:{int(mins[0].split('.')[0]):02d}:{mins[1]}'), player[10], player[11], player[13], player[14], player[16], player[17], player[19], player[20], player[22], player[23], player[24], player[25], player[26], player[27], player[28]]
                # print(Statistics_Player)
                sp_writer.writerow(Statistics_Player)
                
            awayTeam = box.get('resultSets')[1]['rowSet'][0]
            homeTeam = box.get('resultSets')[1]['rowSet'][1]
            
            # print(awayTeam)
            # print(homeTeam)
            winner = awayTeam[1] if awayTeam[23] > homeTeam[23] else homeTeam[1]
            Game_Stats = [int(awayTeam[0]), game_date, winner, 1]
            # print(Game_Stats)
            gw_writer.writerow(Game_Stats)

            # print(awayTeam)
            # print('-------------------')
            Statistics_Away_Team = [sat_id, int(awayTeam[0]), awayTeam[1], awayTeam[6], awayTeam[7], awayTeam[9], awayTeam[10], awayTeam[12], awayTeam[13], awayTeam[15], awayTeam[16], awayTeam[18], awayTeam[19], awayTeam[20], awayTeam[21], awayTeam[22], awayTeam[23]]
            Statistics_Home_Team = [sht_id, int(homeTeam[0]), homeTeam[1], homeTeam[6], homeTeam[7], homeTeam[9], homeTeam[10], homeTeam[12], homeTeam[13], homeTeam[15], homeTeam[16], homeTeam[18], homeTeam[19], homeTeam[20], homeTeam[21], homeTeam[22], homeTeam[23]]
            sat_id = sat_id + 1
            sht_id = sht_id + 1

            sat_writer.writerow(Statistics_Away_Team)
            sht_writer.writerow(Statistics_Home_Team)

            # print(Statistics_Away_Team)
            # print(Statistics_Home_Team)
            # print('\n-------------------\n')

        #     break
        # break

    sat_file.close()    
    sht_file.close()
    gw_file.close()
    sp_file.close()

team_header = ['id', 'teamName', 'cityName', 'wins_losses', 'division_id']
player_header = ['id', 'playerName', 'playerAge', 'playerPosition', 'playerHeight', 'playerWeight']
squad_header = ['id', 'squadYear', 'team_id']
coach_header = ['id', 'coachName', 'coachAge']
squad_player_header = ['squad_id', 'player_id']
squad_coach_header = ['squad_id', 'coach_id']

def team_data():
    squad_id = 1
    
    team_file = open('teamdata.csv', 'w', newline='')
    team_writer = csv.writer(team_file)
    team_writer.writerow(team_header)
    player_file = open('playerdata.csv', 'w', newline='')
    player_writer = csv.writer(player_file)
    player_writer.writerow(player_header)
    squad_file = open('squaddata.csv', 'w', newline='')
    squad_writer = csv.writer(squad_file)
    squad_writer.writerow(squad_header)
    coach_file = open('coachdata.csv', 'w', newline='')
    coach_writer = csv.writer(coach_file)
    coach_writer.writerow(coach_header)
    squad_player_file = open('squadplayerdata.csv', 'w', newline='')
    squad_player_writer = csv.writer(squad_player_file)
    squad_player_writer.writerow(squad_player_header)
    squad_coach_file = open('squadcoachdata.csv', 'w', newline='')
    squad_coach_writer = csv.writer(squad_coach_file)
    squad_coach_writer.writerow(squad_coach_header)
    standings = leaguestandings.LeagueStandings().get_dict()
    nba_teams = standings['resultSets'][0]['rowSet']
    # print(nba_teams)


    for team in nba_teams:
        # print(team)
        team_id = team[2]
        team_name = team[4]
        team_city = team[3]
        Team_data = [team_id, team_name, team_city, team[16], divisions.index(team[9]) + 1]
        # print(Team_data)
        team_writer.writerow(Team_data)

        Squad_data = [squad_id, 2024, team_id]
        # print(Squad_data)
        squad_writer.writerow(Squad_data)
        
        roster = commonteamroster.CommonTeamRoster(team_id=team_id).get_dict()
        # print(roster['resultSets'][0])
        for player in roster['resultSets'][0]['rowSet']:
            Player_data = [player[14], player[3], int(str(player[11]).split('.')[0]), player[7], int(feet_inches_to_cm(player[8])), int(pounds_to_kg(int(player[9])))]
            # print(Player_data)
            player_writer.writerow(Player_data)

            Squad_Player_data = [squad_id, player[14]]
            # print(Squad_Player_data)
            squad_player_writer.writerow(Squad_Player_data)
            # break

        coach = roster['resultSets'][1]['rowSet'][0]
        Coach_data = [coach[2], coach[5], int(-1)]
        # print(Coach_data)
        coach_writer.writerow(Coach_data)

        Squad_Coach_data = [squad_id, coach[2]]
        # print(Squad_Coach_data)
        squad_coach_writer.writerow(Squad_Coach_data)

        squad_id = squad_id + 1
        # break

    team_file.close()
    player_file.close()
    squad_file.close()
    coach_file.close()
    squad_player_file.close()
    squad_coach_file.close()

def pounds_to_kg(pounds):
    return pounds * 0.453592

def feet_inches_to_cm(feet_inches_str):
    feet, inches = map(int, feet_inches_str.split('-'))
    total_inches = (feet * 12) + inches
    total_cm = total_inches * 2.54
    return total_cm

def main():
    game_data()
    team_data()
    print('Done')

if __name__ == '__main__':
    main()