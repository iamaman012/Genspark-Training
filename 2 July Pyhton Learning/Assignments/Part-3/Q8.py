#https://leetcode.com/problems/jump-game/description/
class Solution(object):
    def canJump(self, nums):
        g=len(nums)-1
        for i in range(len(nums)-1,-1,-1):
            if i+nums[i]>=g:
                g=i
        return g==0