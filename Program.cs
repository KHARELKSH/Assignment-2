using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace answers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q1");
            int[] nums = { 0, 1, 2, 3, 12 };
            int target = Int32.Parse(Console.ReadLine());
            int SearchInsert(int[] nums, int target)
            {
                try
                {
                    int first = 0;
                    int last = nums.Length - 1;

                    while (first <= last)
                    {
                        int mid = (last - first) / 2 + first; // finding the middle number

                        if (nums[mid] == target)            // if the target is the middle number
                        {
                            return mid;
                        }
                        else if (nums[mid] < target)       // 
                        {
                            first = mid + 1;
                        }
                        else
                        {
                            last = mid - 1;
                        }
                    }

                    return first;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            int final = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", final);
            Console.WriteLine("");


            {
                Console.WriteLine("Q2:");
                string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
                string[] banned = { "hit" };
                string MostCommonWord(string paragraph, string[] banned)
                {
                    try
                    {
                        List<string> b = new List<string>();
                        Dictionary<string, int> dict = new Dictionary<string, int>();
                        foreach (string s in banned)
                            b.Add(s);
                        string input = paragraph.ToLower(); //LowerCase
                        input = input.Replace("!", "") // replacing the symbols with empty space
                            .Replace(";", "")
                            .Replace("'", "")
                            .Replace("?", "")
                            .Replace(",", "")
                            .Replace(".", "");
                        int count = 0;
                        string common = string.Empty;
                        string[] words = input.Split(' ');
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(words[i]) || b.Contains(words[i])) continue;  
                            if (dict.ContainsKey(words[i]))
                            {
                                dict[words[i]]++;
                            }
                            else
                            {
                                dict.Add(words[i], 1);
                            }

                            if (dict[words[i]] > count)
                            {
                                count = dict[words[i]];
                                common = words[i];
                            }
                        }

                        return common;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                string commonWord = MostCommonWord(paragraph, banned);
                Console.WriteLine("Most frequent word is :{0}", commonWord);
                Console.WriteLine("");
            }




            {
                Console.WriteLine("Q3");
                int[] arr = { 2, 2, 2, 3, 3 };
                Dictionary<int, int> freq = new Dictionary<int, int> { }; //creating a dictionary to store each number and their count.
                List<int> new_list = new List<int> { };
                int ans;
                int FindLucky(int[] arr)
                {
                    try
                    {
                        foreach (int i in arr)  // stores the numbers and their count in dictionary freq.
                        {
                            if (freq.ContainsKey(i))
                            {
                                freq[i] += 1;
                            }
                            else
                            {
                                freq[i] = 1;
                            }
                        }
                        ans = -1;           // -1 if there is no Lucky Number
                        foreach (var (key, value) in freq)
                        {

                            if (key == value)   //if the number and its count is equal
                            {
                                new_list.Add(key);
                                ans = new_list.Max(); // returns the maximum of the numbers which has the same count.
                            }
                        }
                        return ans;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                int lucky_number = FindLucky(arr);
                Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
                Console.WriteLine("");
            }


            {
                Console.WriteLine("Q4:");
                string secret = "1807";
                string guess = "7810";
                List<int> a = new List<int> { };
                List<int> b = new List<int> { };
                List<int> c = new List<int> { };
                string GetHint(string secret, string guess)
                {
                    try
                    {
                        for (int i = 0; i < secret.Length; i++) //stores elements in list "a" for the numbers which have the same index in secret and guess.
                        {
                            if (secret[i] == guess[i])
                            {
                                a.Add(secret[i]);
                            }
                        }
                        for (int i = 0; i < secret.Length; i++) //stores the common elements in guess and secret in list "b".
                        {
                            if (secret.Contains(guess[i]))
                            {
                                b.Add(guess[i]);
                            }

                            foreach (int j in a) // removes the element from list "b" if the numbers which have the same index in secret and guess is already appended.
                            {
                                if (b.Contains(j))
                                {
                                    b.Remove(j);
                                }
                            }
                            foreach (int k in b)
                            {
                                if (!c.Contains(k)) //stores the unique elements and appends in c
                                {
                                    c.Add(k);
                                }
                            }
                        }
                        return $"{a.Count}A{c.Count}B"; // a.count counts the number of bulls and c.counts number of cows

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                string final_output = GetHint(secret, guess);
                Console.WriteLine("Hint for the guess is :{0}", final_output);
                Console.WriteLine("");

            }

            {
                Console.WriteLine("Q5");
                string S = "ababcbacadefegdehijhklij";

                {

                    int[] lastIndex = new int[26]; // to record the last index of each character.
                    for (int i = 0; i < S.Length; i++)
                    {
                        lastIndex[S[i] - 'a'] = i;
                    }
                    int j = 0;
                    int start = 0;
                    List<int> list = new List<int>();

                    for (int i = 0; i < S.Length; i++) // to record the end index of the substring
                    {
                        j = Math.Max(j, lastIndex[S[i] - 'a']);
                        if (i == j)
                        {
                            list.Add(i - start + 1);
                            start = i + 1;
                        }
                    }

                    Console.WriteLine("Partition Lengths are");
                    foreach (int i in list)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("");
                }
            }

            {
                Console.WriteLine("Q6");
                int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
                string S = "abcdefghijklmnopqrstuvwxyz";
                {
                    int[] result = new int[2];
                    int num_lines = 1;
                    int width = 0;
                    foreach (char ch in S.ToCharArray())
                    {
                        int char_width = widths[ch - 'a'];
                        if (char_width + width > 100)
                        {
                            num_lines++;
                            width = 0;
                        }
                        width += char_width;
                    }
                    result[0] = num_lines;
                    result[1] = width;
                    Console.WriteLine("Lines Required to print:");
                    foreach (int i in result)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("");

            }

            {
                Console.WriteLine("Q7");
                string s = Console.ReadLine();
                static bool Valid(String s)
                {

                    Stack<char> left = new Stack<char>();
                    foreach (char c in s.ToCharArray())
                    {
                        if (c == '(' || c == '{' || c == '[')
                        {
                            left.Push(c); // To get the leftmost or the character at index 0 and inserts in the Stack.
                        }

                        else if (c == ')' && left.Count != 0 && (char)left.Peek() == '(') //Comparing it to the right 
                        {
                            left.Pop();
                        }
                        else if (c == '}' && left.Count != 0 && (char)left.Peek() == '{')
                        {
                            left.Pop();
                        }
                        else if (c == ']' && left.Count != 0 && (char)left.Peek() == '[')
                        {
                            left.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                bool output = Valid(s);
                Console.WriteLine(output);
                Console.WriteLine("");
            }
            

        }
    }
}
