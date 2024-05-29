import csv

def fix_seconds(time_str):
    hh, mm, ss = time_str.split(':')
    if ss == '60':
        ss = '00'
        mm = str(int(mm) + 1)
    return f"{hh}:{mm}:{ss}"

allstar = 32300001

with open('satdata.csv', 'r') as file:
    reader = csv.reader(file)
    sat1 = list(reader)

sat = []

for game in sat1:
    sat.append('insert into Statistics_Away_Team values')
    sat.append(str(f'({game[0]},{game[1]},{game[2]},{game[3]},{game[4]},{game[5]},{game[6]},{game[7]},{game[8]},{game[9]},{game[10]},{game[11]},{game[12]},{game[13]},{game[14]},{game[15]},{game[16]})'))

file = open('satdata.txt', 'w')
for game in sat:
    file.write(game + '\n')
file.close()

with open('shtdata.csv', 'r') as file:
    reader = csv.reader(file)
    sht1 = list(reader)

sht = []

for game in sht1:
    if game[1] == allstar:
        continue
    sht.append(str(f'({game[0]},{game[1]},{game[2]},{game[3]},{game[4]},{game[5]},{game[6]},{game[7]},{game[8]},{game[9]},{game[10]},{game[11]},{game[12]},{game[13]},{game[14]},{game[15]},{game[16]}),'))

file = open('shtdata.txt', 'w')
for game in sht:
    file.write(game + '\n')
file.close()

with open('spdata.csv', 'r') as file:
    reader = csv.reader(file)
    sp1 = list(reader)

sp1.pop(0)
sp = []
count = 1
for game in sp1:
    time = fix_seconds(game[2])

    if count < 950:
        sp.append(str(f'({game[0]},{game[1]},\'{time}\',{game[3]},{game[4]},{game[5]},{game[6]},{game[7]},{game[8]},{game[9]},{game[10]},{game[11]},{game[12]},{game[13]},{game[14]},{game[15]},{game[16]},{game[17]}),'))
    else:
        sp.append(str(f'({game[0]},{game[1]},\'{(time)}\',{game[3]},{game[4]},{game[5]},{game[6]},{game[7]},{game[8]},{game[9]},{game[10]},{game[11]},{game[12]},{game[13]},{game[14]},{game[15]},{game[16]},{game[17]})'))
        sp.append('insert into Statistics_Player values')
        count = 1
    count += 1

file = open('spdata.txt', 'w')
for game in sp:
    file.write(game + '\n')
file.close()