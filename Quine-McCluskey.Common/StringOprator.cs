using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Common;

public class StringOprator
{
    public static List<List<string>> SplitFunc(string func)
    {
        return func.Trim().ToLower().Replace(" ", "").Replace("(", "")
            .Replace(")", "").Replace("-", "").Replace("(", "").Replace("∑", "")
            .Replace("∏", "").ToLower().Split("+d").Select(t => t.Split(',').ToList()).ToList();
    }
    public static string CompareOneWord(string middterm1, string middterm2)
    {
        if (middterm1.Length != middterm2.Length) return null;
        var differingIndices = middterm1
            .Select((c, i) => new { Character = c, Index = i })
            .Where(x => x.Character != middterm2[x.Index])
            .ToList();
        if (differingIndices.Count == 1)
            return new string(middterm1.Select((c, i) => i == differingIndices[0].Index ? 'x' : c).ToArray());

        return null;
    }
    public static string Compare(string middterm1, string middterm2)
    {
        if (middterm1.Length != middterm2.Length) return null;
        var differingIndices = middterm1
            .Select((c, i) => new { Character = c, Index = i })
            .Where(x => x.Character != middterm2[x.Index])
            .ToList();
        if (differingIndices.Count == 1)
            return new string(middterm1.Select((c, i) => i == differingIndices[0].Index ? 'x' : c).ToArray());

        return null;
    }
    public static List<List<string>> GroupBy(List<string> middterms)
    {
        return middterms.OrderBy(m => m.Count(c => c == '1' || c == 'x'))
            .GroupBy(s => s.Count(c => c == '1' || c == 'x'))
            .Select(g => g.ToList()).ToList();
    }
    public static List<List<string>> Compare(List<List<string>> middLists)
    {
        List<List<string>> dontCareList = new List<List<string>>();
        for (int i = 0; i < middLists.Count() - 1; i++)
        {
            dontCareList.Add(CompareTwoGroup(middLists[i], middLists[i + 1]));
        }
        return dontCareList;
    }
    public static List<string> CompareTwoGroup(List<string> firstList, List<string> secondList)
    {
        var dontCareList = firstList.SelectMany(first => secondList, (first, second) => CompareOneWord(first, second))
            .Where(dontCare => dontCare != null).ToList();

        return dontCareList;
    }
}
