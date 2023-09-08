using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quine_McCluskey.Domain.Results.Entities;
using Quine_McCluskey.Domain.Terms.Entities;

namespace Quine_McCluskey.Domain.Common;

public class Commands
{
    public static IEnumerable<Result> GroupBy(IEnumerable<MinTerm> terms)
    {
        List<Result> results = new List<Result>();

        var allMinterms = terms.OrderByDescending(m => m.Binary.Count(c => c == '1' || c == 'x'))
            .GroupBy(s => s.Binary.Count(c => c == '1' || c == 'x'))
            .Select(g => g.ToList());

        foreach (var mterms in allMinterms)
            results.Add(new Result { Terms = mterms });

        return results;
    }
    public static Result DeleteDuplicate(IEnumerable<MinTerm> terms)
    {
        return new Result { Terms = terms.GroupBy(t => t.Binary).Select(m => m.First()).ToList() };
    }
    public static Result DeleteDontCares(IEnumerable<MinTerm> terms)
    {
        return new Result
        {
            Terms = terms.Except(
            terms.Where(p => p.IsDontCare && p.Binary.Count(c => c == 'x') < 2).ToList()).ToList()
        };
    }
}
