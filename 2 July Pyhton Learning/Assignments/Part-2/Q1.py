# https://www.hackerrank.com/challenges/merge-the-tools/problem?isFullScreen=true

def merge_the_tools(string, k):
    # your code goes here
    n = int(len(string)/k)
    arr=[]
    s=0
    e=k
    for i in range(n):
        arr.append(string[s:e])
        s=e
        e=e+k
  
        
    for x in arr:
        result=""
        for c in x:
            if c not in result:
                result+=c
        print(result)
            
        

if __name__ == '__main__':
    string, k = input(), int(input())
    merge_the_tools(string, k)