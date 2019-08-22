using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblem
{
    class ProblemSolve
    {
        static List<string> keys1 = new List<string>();
        public static IList<string> GetKeyFromJsonString(string jsonStr)
        {
            JObject jsonObj = JObject.Parse(jsonStr);
            //List<string> keys1 = new List<string>();
            //foreach (var child in jsonObj.Children())
            //{
            //    if (child.HasValues)
            //    {
            //        var str = child.;
            //        keys1.Add(str);
            //        //var ChildKeys1 = GetKeys(child);
            //        //var ChildKeys = jsonObj.Properties().Select(p => p.Name).ToList();
            //    }
            //}

            var keys = jsonObj.Properties().Select(p => p.Name).ToList();
            keys1.AddRange(keys);
            foreach (var key in keys)
            {
                var obj = jsonObj[key];
                if (obj.HasValues)
                {
                    GetKeyFromJsonString(jsonObj[key].ToString());
                }
            }

            return keys1;
        }

        public static IList<string> GetKeys(JToken jsonObj)
        {
            var ChildKeys = (jsonObj.ToObject<JObject>()).Properties().Select(p => p.Name).ToList();
            return ChildKeys;
        }

        public static string AllCharOccurenceCount(string[] lstStr)
        {
            var counts = new Dictionary<char, int>();
            foreach (string str in lstStr)
            {
                foreach (char ch in str)
                {
                    int count;
                    counts.TryGetValue(ch, out count);
                    count++;
                    counts[ch] = count;
                }
            }

            var entries = counts.Select(d =>
                string.Format("{0}: {1}", d.Key.ToString() == "" ? "\'\'" : d.Key.ToString(), d.Value));
            return "{" + string.Join(",", entries) + "}";
            //return entries;
        }

        public static string[] RemoveDuplicatesHS(string[] s)
        {
            HashSet<string> set = new HashSet<string>(s);
            string[] result = new string[set.Count];
            set.CopyTo(result);
            return result;
        }

        public static string[] RemoveDuplicates(string[] strIn)
        {
            int numDups = 0, prevIndex = 0;
            if (null != strIn)
            {
                int len = strIn.Length;
                for (int i = 0; i < len; i++)
                {
                    bool foundDup = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (strIn[j] == strIn[i])
                        {
                            foundDup = true;
                            numDups++;
                            break;
                        }
                    }

                    if (foundDup == false)
                    {
                        strIn[prevIndex] = strIn[i];
                        prevIndex++;
                    }
                }

                //// Just Duplicate records replce by null. If we can't use another array.
                //for (int k = 1; k <= numDups; k++)
                //{
                //    strIn[len - k] = null;
                //}
                //return strIn;

                //If we can use two array then this is the best choice 
                //without using collection or linq or any api
                string[] strUnique = new string[len - numDups];
                Array.Copy(strIn, strUnique, len - numDups);
                //for (int k = 0; k < len - numDups; k++)
                //{
                //    strUnique[k] = strIn[k];
                //}
                return strUnique;
            }
            return null;

        }

        public static string ReverseWordUsingSplitRev(string str)
        {
            string[] arrWord = str.Split(' ');
            int i = 0;
            foreach (string word in arrWord)
            {
                arrWord[i] = Reverse(word);
                i++;
            }

            return string.Join(" ", arrWord);
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static String ReverseWords(String str)
        {

            // Pointer to the first character  
            // of the first word  
            int start = 0;
            for (int i = 0; i < str.Length; i++)
            {

                // If the current word has ended  
                if (str[i] == ' ' ||
                        i == str.Length - 1)
                {

                    // Pointer to the last character  
                    // of the current word  
                    int end;
                    if (i == str.Length - 1)
                        end = i;
                    else
                        end = i - 1;

                    // Reverse the current word  
                    while (start < end)
                    {
                        str = swap(str, start, end);
                        start++;
                        end--;
                    }

                    // Pointer to the first character  
                    // of the next word  
                    start = i + 1;
                }
            }

            return str;
        }

        static String swap(String str, int i, int j)
        {
            char[] ch = str.ToCharArray();
            char temp = ch[i];
            ch[i] = ch[j];
            ch[j] = temp;
            return String.Join("", ch);
        }

    }
}
