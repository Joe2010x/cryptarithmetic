using System.ComponentModel.DataAnnotations;

namespace SendMoney;

public class Word
{
    public int Length {get; set;}
    public char[] CharSet {get; set;}
    public string TheWord {get; set;}
    public int[] ValidNum {get; set;}
    
    public Word (string word) 
    {
        TheWord = word;
        Length = word.Length;
        CharSet = word.ToCharArray().Distinct().ToArray();
        ValidNum = GetValidNum();
    }

    public Dictionary<char,int> GetRules(int num)
    {
        var str = num.ToString();
        var result = new Dictionary<char,int>();
        for (var i = 0; i<str.Length; i++)
        {
            var charW = TheWord[i];
            if (!result.ContainsKey(charW)) 
                result.Add(charW,(int) char.GetNumericValue(str[i]));
        }
        return result;
    }

    public int[] GetValidNum ()
    {
        var result = new List<int>();
        for (var i=0; i<Math.Pow(10,Length); i++)
        {
            if (IsValid(i)) result.Add(i);
        }
        return result.ToArray();
    }

    public bool IsValid(int num) 
    {
        var str = num.ToString();
        var length = str.Length;
        if (length != Length) return false;

        return NumMatchWord(num, TheWord);
    }

    public static bool NumMatchWord (int num, string word)
    {
        var str = num.ToString();
         for (var i = 0; i<str.Length -1; i++)
        {
            for (var j = i+1 ; j<str.Length ; j++)
            {
                if (word[i] == word[j] && str[i] != str[j]) return false;
                if (word[i] != word[j] && str[i] == str[j]) return false;
            }
        }

        return true;
    }

    public static bool RulesMatch ( Dictionary<char,int> rules1, Dictionary<char,int> rules2)
    {
        var keysRules1 = new List<char>( rules1.Keys);
        var keysValues1 = new List<int>(rules1.Values);
        for (var i = 0; i<rules1.Count; i++)
        {
            var keyRule1 = keysRules1[i];
            var ValueRule1 = keysValues1[i];
            if (rules2.TryGetValue(keyRule1, out var value) && value != rules1.GetValueOrDefault(keyRule1)) return false;
            var found = rules2.FirstOrDefault(s => s.Value == ValueRule1);
            if (!found.Equals(default(KeyValuePair<char,int>)) && found.Key != keyRule1) return false;
        }
        return true;
    }

}