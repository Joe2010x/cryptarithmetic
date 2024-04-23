using System;
using System.Collections.Generic;
using System.Linq;

namespace SendMoney;

class Program
{
    static void Main(string[] args)
    {
        var word1 = new Word("SEND");
        var word2 = new Word("MORE");
        var word3 = new Word("MONEY");

        for (var w1 = 0; w1<word1.ValidNum.Length ; w1++)
        {
            var num1 = word1.ValidNum[w1];

            for (int w2 = 0; w2 < word1.ValidNum.Length; w2++)
            {
                var num2 = word2.ValidNum[w2];
                var newNum = num1 + num2;

                    if (word3.ValidNum.Contains(newNum) )
                    {
                        var rule1 = word1.GetRules(num1);
                        var rule2 = word2.GetRules(num2);
                        var rule3 = word3.GetRules(newNum);
                        
                        if (Word.RulesMatch(rule1, rule2) 
                            && Word.RulesMatch(rule3, rule2) 
                            && Word.RulesMatch(rule1, rule3))
                            {
                                Console.WriteLine(word1.TheWord+" + "+word2.TheWord+" = "+word3.TheWord);
                                Console.WriteLine(num1+" + "+num2+" = "+newNum);
                            }
                    }
            }
        }

    }
}
