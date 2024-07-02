#https://leetcode.com/problems/unique-paths/description/

class Solution(object):
    def solve(self,i,j,m,n,dp):
        if i==m-1 and j==n-1:
            return 1
        if i>=m or j>=n:
            return 0
        if dp[i][j]!=-1:
            return dp[i][j]
        down = self.solve(i+1,j,m,n,dp)
        right = self.solve(i,j+1,m,n,dp)
        dp[i][j]= down+right
        return dp[i][j]

    def uniquePaths(self, m, n):
        dp=[[-1 for _ in range(n)] for _ in range(m)]
        return self.solve(0,0,m,n,dp)
        