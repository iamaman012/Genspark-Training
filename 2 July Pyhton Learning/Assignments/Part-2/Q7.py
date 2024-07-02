# https://www.hackerrank.com/challenges/finding-the-percentage/problem?isFullScreen=true

if __name__ == '__main__':
    n = int(input())
    student_marks = {}
    for _ in range(n):
        name, *line = input().split()
        scores = list(map(float, line))
        student_marks[name] = scores
    query_name = input()
    
    Sum = 0
    for i in student_marks[query_name]:
        Sum = Sum + i
        
    average = Sum/3
    #show 2 places after the decimal
    print(f"{average:.2f}")