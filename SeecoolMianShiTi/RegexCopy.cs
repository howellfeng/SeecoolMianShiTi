using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    //4.3 用简单的C#基本语法，实现字符串的查询匹配，支持 *（匹配1到多个），？（匹配一个字符）。    
    static class RegexCopy
    {
        public static string[] MatchRegex(string[] strs, string pattern)
        {
            Regex regex = new Regex(pattern);
            List<string> result = new List<string>();
            foreach (string str in strs)
            {
                if (regex.IsMatch(str))
                    result.Add(str);
            }
            return result.ToArray();
        }
        public static string[] Match(string[] strs, string pattern)
        {
            List<string> result = new List<string>();
            foreach (string str in strs)
            {
                if (isMatchRegex(str, pattern))
                    result.Add(str);
            }
            return result.ToArray();
        }
        //简单实现，不支持*和?
        private static bool simpleIsMatch(string str, string pattern)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == pattern[0])
                {
                    bool isMatch = true;
                    for (int j = 1; j < pattern.Length; j++)
                    {
                        if (i + j >= str.Length || str[i + j] != pattern[j])
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch)
                        return true;
                }
            }
            return false;
        }

        //简单，暂不支持*和?
        private static bool isMatch(string str, string pattern)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == pattern[0])
                {
                    bool isMatch = true;
                    int k = i + 1;
                    for (int j = 1; j < pattern.Length; j++)
                    {
                        if (k >= str.Length)
                            return false;
                        if (pattern[j] == '*')
                        {
                            while (str[k] == str[k - 1])
                                k++;
                            continue;
                        }
                        else if (pattern[j] == '?')
                        {
                        }
                        else if (str[k] != pattern[j])
                        {
                            isMatch = false;
                            break;
                        }
                        k++;
                    }

                    if (isMatch)
                        return true;
                }
            }
            return false;
        }
        //根据正则，*匹配0,1,多次，?匹配0,1次
        private static bool isMatchRegex(string str, string pattern)
        {
            int i = 0;
            int j = resetPatternIndex(pattern);
            while (i < str.Length)
            {
                if (j < pattern.Length - 1 && pattern[j + 1] == '*')
                {
                    if (pattern[j] != str[i] || pattern[j] != str[i + 1])//0或最后1个
                        j += 2;
                }
                else if (j < pattern.Length - 1 && pattern[j + 1] == '?')
                {
                    if (pattern[j] != str[i] || pattern[j] == str[i])//0或1个
                        j += 2;
                }
                else if (pattern[j] == str[i])
                    j++;
                else
                    j = 0;
                if (j == pattern.Length)
                    return true;
                i++;
                if (i == str.Length && j != 0 && j < pattern.Length)
                    i--;
            }
            return false;
        }
        private static int resetPatternIndex(string pattern)
        {
            if (pattern[0] == '*' || pattern[0] == '?')
                return 1;
            else
                return 0;
        }
    }
}
