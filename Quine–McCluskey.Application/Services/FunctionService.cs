using Quine_McCluskey.Application.DTO;
using Quine_McCluskey.Application.InputFunctions;
using Quine_McCluskey.Application.Interfaces;
using Quine_McCluskey.Application.Results;
using Quine_McCluskey.Domain;
using Quine_McCluskey.Domain.Terms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Application.Services;

public class FunctionService : IFunctionService
{
    private InputFunctionDTO _function;
    public async Task<ResultDTO> Solve(InputFunctionDTO function)
    {
        _function = function;
        _function.Terms = function.State ? InputSerialization.ConvertToSOP(function.Terms) : function.Terms;
        _function.maxKarnaughIndex = _function.Terms.Max(t => t.KarnaughIndex);

        IEnumerable<MinTerm> terms = _function.Terms.Select(t => new MinTerm() { Int = t.KarnaughIndex, Binary = InputSerialization.ConvertToBinary(t.KarnaughIndex, _function.maxKarnaughIndex ?? default), IsDontCare = t.IsDontCare });
        DomainHandler domain = new DomainHandler(terms);

        var result = new ResultDTO();
        result.InputFunction = function.FunctionString;
        result.ResultsList = ResultSerialization.ConvertToResult(domain.Results);
        return result;
    }
}
