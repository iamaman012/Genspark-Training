
#https://leetcode.com/problems/longest-substring-without-repeating-characters/description/

class Solution(object):
    def lengthOfLongestSubstring(self, s):
        
        st = set(())
        i=0
        ans =0
        for j in range(len(s)):
            while s[j] in st:
                st.discard(s[i])
                i=i+1
            st.add(s[j])
            ans = max(ans,j-i+1)
            
        return ans