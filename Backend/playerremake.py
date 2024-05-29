import csv
from nba_api.stats.endpoints import commonplayerinfo
from datetime import datetime

def calculate_age(birthdate_str):
    birthdate = datetime.strptime(birthdate_str, '%Y-%m-%dT%H:%M:%S')
    today = datetime.today()
    age = today.year - birthdate.year - ((today.month, today.day) < (birthdate.month, birthdate.day))
    return age

def get_player_info(player_id):
    player_info = commonplayerinfo.CommonPlayerInfo(player_id=player_id)
    player_data = player_info.get_data_frames()[0]
    return player_data

def pounds_to_kg(pounds):
    return pounds * 0.453592

def feet_inches_to_cm(feet_inches_str):
    feet, inches = map(int, feet_inches_str.split('-'))
    total_inches = (feet * 12) + inches
    total_cm = total_inches * 2.54
    return total_cm

def get_position(position_str):
    parts = position_str.split('-')
    abbrev = [part[0] for part in parts]
    return '-'.join(abbrev)

file = open('playerdata.csv', 'r')
reader = csv.reader(file)
playerlist = list(reader)
file.close()

playerlist.pop(0)

player_ids = []
for player in playerlist:
    player_ids.append(int(player[0]))

player_ids = list(dict.fromkeys(player_ids))


file = open('spdata.csv', 'r')
reader = csv.reader(file)
splist = list(reader)
file.close()

splist.pop(0)

not_in_player_data = []

for player in splist:
    if int(player[0]) not in player_ids:
        not_in_player_data.append(int(player[0]))

not_in_player_data = list(dict.fromkeys(not_in_player_data))

file = open('playerremake.txt', 'w')

# id, playerName, playerPosition, playerAge, playerHeight, playerWeight

for player in not_in_player_data:
    player_data = get_player_info(player)
    id = player_data['PERSON_ID'][0]
    name = player_data['DISPLAY_FIRST_LAST'][0]
    position = get_position(player_data['POSITION'][0])
    age = calculate_age(player_data['BIRTHDATE'][0])
    height = feet_inches_to_cm(player_data['HEIGHT'][0])
    weight = pounds_to_kg(int(player_data['WEIGHT'][0]))
    player_data = f'({id}, \'{name}\', {age}, \'{position}\', {height:.0f}, {weight:.0f}),'
    print(player_data)
    file.write(player_data + '\n')
    