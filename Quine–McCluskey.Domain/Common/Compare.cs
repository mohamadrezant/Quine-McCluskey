using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quine_McCluskey.Common;
using Quine_McCluskey.Domain.Results.Entities;
using Quine_McCluskey.Domain.Terms.Entities;

namespace Quine_McCluskey.Domain.Common;

public class Compare
{
    public static IEnumerable<MinTerm> CompareResultList(IEnumerable<Result> middLists)
    {
        List<MinTerm> dontCareList = new List<MinTerm>();
        for (int i = 0; i < middLists.Count() - 1; i++)
        {
            var midd = CompareTwoResult(middLists.ToArray()[i], middLists.ToArray()[i + 1]);
            dontCareList = midd != null ? dontCareList.Concat(midd).ToList() : dontCareList;
        }
        return dontCareList;
    }
    public static List<MinTerm> CompareTwoResult(Result firstList, Result secondList)
    {
        var dontCareList = firstList.Terms.SelectMany(first => secondList.Terms, (first, second) =>
        {
            var binary = StringOprator.CompareOneWord(first.Binary, second.Binary);
            if (binary != null)
            {
                first.IsUsed = true;
                second.IsUsed = true;
            }
            return new MinTerm() { Binary = binary, IntList = first.IntList.Union(second.IntList).ToList() };
        }).Where(dontCare => dontCare.Binary != null).ToList()?.ToList() ?? new List<MinTerm>();
        var d = firstList.Terms.Concat(secondList.Terms).Where(item => item.IsUsed == false).ToList();
        dontCareList = dontCareList != null ? dontCareList.Concat(d).ToList() : new List<MinTerm>();
        return dontCareList;
    }
}
