using Quine_McCluskey.Domain.Results.Entities;
using Quine_McCluskey.Domain.Results.StatusTable;
using Quine_McCluskey.Domain.Terms;
using Quine_McCluskey.Domain.Terms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Domain;

public class DomainHandler
{
    private IEnumerable<MinTerm> _inputFunction { get; }
    public IEnumerable<Result> Results { get; }
    public DomainHandler(IEnumerable<MinTerm> InputFunction)
    {
        if (InputFunction == null) return;
        this._inputFunction = InputFunction;
        this.Results = Simplify();
    }
    private IEnumerable<Result> Simplify()
    {
        Result mainResult = TermHandler.Calculate(_inputFunction);
        var d = mainResult.Terms.Select(t=>t.Binary).ToList();
        IEnumerable<Result> results = StatusTable.PutResultToStatusTable(_inputFunction, mainResult);
        return results;
    }
}
