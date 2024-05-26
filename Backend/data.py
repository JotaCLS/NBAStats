from nba_api.stats.endpoints import leaguestandings, commonteamroster, scoreboardv2, boxscoretraditionalv2
from nba_api.stats.static import teams
from datetime import datetime, timedelta

Game_Stats = None
Statistics_Away_Team = None
Statistics_Home_Team = None
Statistics_Player = None
Team_data = None
Player_data = None 
Coach_data = None

firstday = '2023-10-24'
lastday = '2024-04-14'

divisions = ['Atlantic', 'Central', 'Southeast', 'Northwest', 'Pacific', 'Southwest']

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

    gw_file = open('gamedata.txt', 'w')
    sat_file = open('satdata.txt', 'w')
    sht_file = open('shtdata.txt', 'w')
    sp_file = open('spdata.txt', 'w')

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
                Statistics_Player = str(f'{player[4]}, {player[0]}, {str(f'00:{int(mins[0].split('.')[0]):02d}:{mins[1]}')}, {player[10]}, {player[11]}, {player[13]}, {player[14]}, {player[16]}, {player[17]}, {player[19]}, {player[20]}, {player[22]}, {player[23]}, {player[24]}, {player[25]}, {player[26]}, {player[27]}, {player[28]}')
                # print(Statistics_Player)
                sp_file.write(Statistics_Player)
                sp_file.write('\n')
                
            awayTeam = box.get('resultSets')[1]['rowSet'][0]
            homeTeam = box.get('resultSets')[1]['rowSet'][1]
            
            # print(awayTeam)
            # print(homeTeam)
            winner = awayTeam[1] if awayTeam[23] > homeTeam[23] else homeTeam[1]
            Game_Stats = str(f'{awayTeam[0]}, {game_date}, {winner}, 1')

            gw_file.write(Game_Stats)
            gw_file.write('\n')

            # print(awayTeam)
            # print('-------------------')
            Statistics_Away_Team = str(f'{sat_id}, {awayTeam[0]}, {awayTeam[1]}, {awayTeam[6]}, {awayTeam[7]}, {awayTeam[9]}, {awayTeam[10]}, {awayTeam[12]}, {awayTeam[13]}, {awayTeam[15]}, {awayTeam[16]}, {awayTeam[18]}, {awayTeam[19]}, {awayTeam[20]}, {awayTeam[21]}, {awayTeam[22]}, {awayTeam[23]}')
            Statistics_Home_Team = str(f'{sht_id}, {homeTeam[0]}, {homeTeam[1]}, {homeTeam[6]}, {homeTeam[7]}, {homeTeam[9]}, {homeTeam[10]}, {homeTeam[12]}, {homeTeam[13]}, {homeTeam[15]}, {homeTeam[16]}, {homeTeam[18]}, {homeTeam[19]}, {homeTeam[20]}, {homeTeam[21]}, {homeTeam[22]}, {homeTeam[23]}')
            sat_id = sat_id + 1
            sht_id = sht_id + 1

            sat_file.write(Statistics_Away_Team)
            sat_file.write('\n')
            sht_file.write(Statistics_Home_Team)
            sht_file.write('\n')

            # print(Statistics_Away_Team)
            # print(Statistics_Home_Team)
            # print('\n-------------------\n')

        #     break
        # break

    sat_file.close()
    sht_file.close()
    gw_file.close()
    sp_file.close()

def team_data():
    team_file = open('teamdata.txt', 'w')
    standings = leaguestandings.LeagueStandings().get_dict()
    nba_teams = standings['resultSets'][0]['rowSet']
    # print(nba_teams)

    for team in nba_teams:
        # print(team)
        team_id = team[2]
        team_name = team[4]
        team_city = team[3]
        print(f'{team_id}, {team_name}, {team_city}, {team[16]}, {divisions.index(team[9]) + 1}')
        
        roster = commonteamroster.CommonTeamRoster(team_id=team_id).get_dict()
        # print(roster['resultSets'][0]['headers'])
        for player in roster['resultSets'][0]['rowSet']:
            print(f'{player[14]}, {player[3]}, {int(str(player[11]).split('.')[0])}, {player[7]}, {player[8]}, {player[9]}')
        #     break
        # break

def main():
    # game_data()
    team_data()

if __name__ == '__main__':
    main()