
#https://www.hackerrank.com/challenges/collections-counter/problem?isFullScreen=true

from collections import Counter
X = int(input())
sizes = list(map(int, input().split()))
money = 0
N = int(input())
for _ in range(N):
    lst = list(map(int, input().split()))
    cnt = Counter(sizes)
    if lst[0] in cnt.keys():
        money += lst[1]
        sizes.remove(lst[0])
    else:
        money += 0
print(money)