using Quine_McCluskey.Domain.Results.Entities;
using Quine_McCluskey.Domain.Terms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Domain.Results.StatusTable;

public class StatusTable
{
    public static IEnumerable<Result> PutResultToStatusTable(IEnumerable<MinTerm> InputFunction, Result result)
    {
        List<MinTerm> inputTerms = InputFunction.Where(x => x.IsDontCare == false).ToList();
        List<MinTerm> mainResultTerms = inputTerms.Select(inputTerm =>
        {
            var matches = result.Terms.Where(term => term.IntList.Contains(inputTerm.IntList.First())).ToList();
            return matches.Count == 1 ? matches[0] : null;
        }).Where(match => match != null).ToList();

        List<int> remainedTermsNum = inputTerms.SelectMany(inputTerm => inputTerm.IntList).Except(mainResultTerms.SelectMany(t => t.IntList)).ToList();
        List<MinTerm> subResultTerms = result.Terms.Except(mainResultTerms).ToList();

        result.Terms.Reverse();
        List<MinTerm> synonymsTerms = subResultTerms.Where(term => remainedTermsNum.Any(remainedTermNum => term.IntList.Contains(remainedTermNum))).Distinct().ToList();
        List<Result> subResults = subResultTerms.Select(term => new Result() { Terms = mainResultTerms.Union(new[] { term }).Reverse().ToList() }).ToList();
        return synonymsTerms.Count() != 0 ? subResults : new List<Result>() { result };
    }
}
