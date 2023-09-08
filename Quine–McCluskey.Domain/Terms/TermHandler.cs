using Quine_McCluskey.Domain.Common;
using Quine_McCluskey.Domain.Results.Entities;
using Quine_McCluskey.Domain.Terms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Domain.Terms;

internal static class TermHandler
{
    public static Result Calculate(IEnumerable<MinTerm> terms)
    {
        if (terms.Count() < 2) return new Result() { Terms = terms };
        IEnumerable<MinTerm> previousOutput = terms;
        IEnumerable<Result> resultsGroup = Commands.GroupBy(terms).ToList();
        IEnumerable<MinTerm> uniqueTerms = Compare.CompareResultList(resultsGroup);
        Result currentOutput = Commands.DeleteDuplicate(uniqueTerms);
        
        if (!currentOutput.Terms.SequenceEqual(previousOutput) && currentOutput.Terms.Count() > 1)
            return Calculate(currentOutput.Terms);
        else if (currentOutput.Terms.Count() == 0)
            return new Result() { Terms = previousOutput };
        else
            return Commands.DeleteDontCares(currentOutput.Terms);
    }
}
