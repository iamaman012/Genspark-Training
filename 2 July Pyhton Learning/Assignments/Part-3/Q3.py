#https://leetcode.com/problems/3sum-closest/description/

class Solution(object):
    def threeSumClosest(self, nums, target):
        nums.sort()
        ans = 0
        diff = 99999999
        
        for i in range(len(nums) - 2):
            j = i + 1
            k = len(nums) - 1
            while j < k:
                sum = nums[i] + nums[j] + nums[k]
                if sum == target:
                    return sum
                if abs(sum - target) < diff:
                    diff = abs(sum - target)
                    ans = sum
                if sum < target:
                    j += 1
                elif sum > target:
                    k -= 1
        return ans
