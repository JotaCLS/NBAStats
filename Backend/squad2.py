import csv

thisSeason = []

with open('playerdata.csv', 'r') as file:
    reader = csv.reader(file)
    for row in reader:
        thisSeason.append(row) 

with open('playerremake.csv', 'r') as file:
    reader = csv.reader(file)
    for row in reader:
        thisSeason.append(row)

thisSeason.pop(0)
thisSeasonIDS = []

for player in thisSeason:
    thisSeasonIDS.append(int(player[0]))

lastSeason = []

with open('playerdata2.csv', 'r') as file:
    reader = csv.reader(file)
    for row in reader:
        lastSeason.append(row)

lastSeason.pop(0)
file = open('playerdata2023.csv', 'w', newline='')
writer = csv.writer(file)
        
for player in lastSeason:
    print(player)
    if int(player[0]) not in thisSeasonIDS:
        writer.writerow(player)
        print(f'Added {player[0]}')

file.close()

thisSeasonCoach = []

with open('coachdata.csv', 'r') as file:
    reader = csv.reader(file)
    for row in reader:
        thisSeasonCoach.append(row) 

thisSeasonCoach.pop(0)
thisSeasonCoachIDS = []

for coach in thisSeasonCoach:
    thisSeasonCoachIDS.append(int(coach[0]))
    
lastSeasonCoach = []

with open('coachdata2.csv', 'r') as file:
    reader = csv.reader(file)
    for row in reader:
        lastSeasonCoach.append(row)

lastSeasonCoach.pop(0)
file = open('coachdata2023.csv', 'w', newline='')
writer = csv.writer(file)
        
for coach in lastSeasonCoach:
    print(coach)
    if int(coach[0]) not in thisSeasonCoachIDS:
        writer.writerow(coach)
        print(f'Added {coach[0]}')

file.close()

print('Done')

