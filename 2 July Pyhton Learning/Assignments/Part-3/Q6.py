#https://leetcode.com/problems/group-anagrams/description/

class Solution(object):
    def groupAnagrams(self, strs):
        dict_list={}
        for i in range(len(strs)):
            sort_char= sorted(strs[i])
            sort_str=''.join(sort_char)
            if sort_str not in dict_list:
                dict_list[sort_str]=[strs[i]]
            else:
                dict_list[sort_str].append(strs[i])

           
        ans =[]
        for values in dict_list.values():
            ans.append(values)
        return ans

        
        