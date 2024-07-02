#https://leetcode.com/problems/multiply-strings/description/
class Solution(object):
    def multiply(self, num1, num2):
        num1= int(num1)
        num2= int(num2)
        num3 = num1*num2
        return str(num3)
        