using System;
using System.Collections.Generic;

namespace REG_MARK_LIB
{
    public class Class1
    {
        public static bool CheckMark(string mark)
        {
            mark = mark.ToLower();
            if(mark.Length == 8 || mark.Length == 9)
            {
                if ((mark[0] == 'a' || mark[0] == 'b' || mark[0] == 'e' || mark[0] == 'k' || mark[0] == 'm' || mark[0] == 'h' || mark[0] == 'o' || mark[0] == 'p' || mark[0] == 'c' || mark[0] == 't' || mark[0] == 'y' || mark[0] == 'x') &&
                    (mark[4] == 'a' || mark[4] == 'b' || mark[4] == 'e' || mark[4] == 'k' || mark[4] == 'm' || mark[4] == 'h' || mark[4] == 'o' || mark[4] == 'p' || mark[4] == 'c' || mark[4] == 't' || mark[4] == 'y' || mark[4] == 'x') &&
                    (mark[5] == 'a' || mark[5] == 'b' || mark[5] == 'e' || mark[5] == 'k' || mark[5] == 'm' || mark[5] == 'h' || mark[5] == 'o' || mark[5] == 'p' || mark[5] == 'c' || mark[5] == 't' || mark[5] == 'y' || mark[5] == 'x'))
                {
                    if ((mark[1] >= '0' && mark[1] <= '9')&& (mark[2] >= '0' && mark[2] <= '9')&& (mark[3] >= '0' && mark[3] <= '9'))
                    {
                        if(mark.Length == 8)
                        {
                            if ((mark[6] >= '0' && mark[6] <= '9') && (mark[7] >= '1' && mark[7] <= '9')) return true;
                            else return false;
                        }
                        else if(mark.Length == 9)
                        {
                            if ((mark[6] >= '0' && mark[6] <= '9') && (mark[7] >= '0' && mark[7] <= '9') && (mark[8] >= '1' && mark[8] <= '9')) return true;
                            else return false;
                        }
                    }
                }
            }
            return false;
        }
        public static string GetNextMarkAfter(string mark)
        {
            mark = mark.ToLower();
            string NextMark = mark;
            if(CheckMark(mark))
            {
                if(mark[1] != '9' && mark[2] != '9' && mark[3] != '9')
                {
                    int number = int.Parse(mark[1].ToString() + mark[2].ToString() + mark[3].ToString());
                    number++;
                    if(number < 10)
                    {
                        NextMark = NextMark.Remove(1, 1);
                        NextMark = NextMark.Insert(1, "0");
                        NextMark = NextMark.Remove(2, 1);
                        NextMark = NextMark.Insert(2, "0");
                        NextMark = NextMark.Remove(3, 1);
                        NextMark = NextMark.Insert(3, number.ToString());
                    }
                    else if(number > 9 && number < 100)
                    {
                        NextMark = NextMark.Remove(1, 1);
                        NextMark = NextMark.Insert(1, "0");
                        NextMark = NextMark.Remove(2, 1);
                        NextMark = NextMark.Insert(2, number.ToString()[0].ToString());
                        NextMark = NextMark.Remove(3, 1);
                        NextMark = NextMark.Insert(3, number.ToString()[1].ToString());
                    }
                    else if(number > 99 && number < 1000)
                    {
                        NextMark = NextMark.Remove(1, 1);
                        NextMark = NextMark.Insert(1, number.ToString()[0].ToString());
                        NextMark = NextMark.Remove(2, 1);
                        NextMark = NextMark.Insert(2, number.ToString()[1].ToString());
                        NextMark = NextMark.Remove(3, 1);
                        NextMark = NextMark.Insert(3, number.ToString()[2].ToString());
                    }
                    else
                    {
                        Dictionary<string, string> nextWord = new Dictionary<string, string>();
                        nextWord["a"] = "b";
                        nextWord["b"] = "e";
                        nextWord["e"] = "k";
                        nextWord["k"] = "m";
                        nextWord["m"] = "h";
                        nextWord["h"] = "o";
                        nextWord["o"] = "p";
                        nextWord["p"] = "c";
                        nextWord["c"] = "t";
                        nextWord["t"] = "y";
                        nextWord["y"] = "x";
                        nextWord["x"] = "a";

                        
                        if (mark[5] == 'x')
                        {
                            string currentWord = mark[5].ToString();
                            NextMark = NextMark.Remove(5, 1);
                            NextMark = NextMark.Insert(5, nextWord[currentWord]);
                        }
                        else if(mark[4] == 'x')
                        {
                            string currentWord = mark[4].ToString();
                            NextMark = NextMark.Remove(4, 1);
                            NextMark = NextMark.Insert(4, nextWord[currentWord]);
                        }
                        else if (mark[0] == 'x')
                        {
                            string currentWord = mark[0].ToString();
                            NextMark = NextMark.Remove(0, 1);
                            NextMark = NextMark.Insert(0, nextWord[currentWord]);
                        }
                    }
                }
                else
                {
                    Dictionary<string, string> nextWord = new Dictionary<string, string>();
                    nextWord["a"] = "b";
                    nextWord["b"] = "e";
                    nextWord["e"] = "k";
                    nextWord["k"] = "m";
                    nextWord["m"] = "h";
                    nextWord["h"] = "o";
                    nextWord["o"] = "p";
                    nextWord["p"] = "c";
                    nextWord["c"] = "t";
                    nextWord["t"] = "y";
                    nextWord["y"] = "x";
                    nextWord["x"] = "a";

                    if (mark[5] != 'x')
                    {
                        string currentWord = mark[5].ToString();
                        NextMark = NextMark.Remove(5, 1);
                        NextMark = NextMark.Insert(5, nextWord[currentWord]);

                        NextMark = NextMark.Remove(1, 1);
                        NextMark = NextMark.Insert(1, "0");
                        NextMark = NextMark.Remove(2, 1);
                        NextMark = NextMark.Insert(2, "0");
                        NextMark = NextMark.Remove(3, 1);
                        NextMark = NextMark.Insert(3, "1");
                    }
                    else if (mark[4] != 'x')
                    {
                        string currentWord = mark[4].ToString();
                        NextMark = NextMark.Remove(4, 1);
                        NextMark = NextMark.Insert(4, nextWord[currentWord]);

                        NextMark = NextMark.Remove(1, 1);
                        NextMark = NextMark.Insert(1, "0");
                        NextMark = NextMark.Remove(2, 1);
                        NextMark = NextMark.Insert(2, "0");
                        NextMark = NextMark.Remove(3, 1);
                        NextMark = NextMark.Insert(3, "1");
                    }
                    else if (mark[0] != 'x')
                    {
                        string currentWord = mark[0].ToString();
                        NextMark = NextMark.Remove(0, 1);
                        NextMark = NextMark.Insert(0, nextWord[currentWord]);

                        NextMark = NextMark.Remove(1, 1);
                        NextMark = NextMark.Insert(1, "0");
                        NextMark = NextMark.Remove(2, 1);
                        NextMark = NextMark.Insert(2, "0");
                        NextMark = NextMark.Remove(3, 1);
                        NextMark = NextMark.Insert(3, "1");
                    }
                    else
                    {
                        return mark;
                    }
                }
            }
            else
            {
                return mark;
            }

            return NextMark;
        }
            
     }
    
}
