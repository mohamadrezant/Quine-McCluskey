using Quine_McCluskey.Application.DTO;
using Quine_McCluskey.Domain.Results.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Application.InputFunctions;

internal static class InputSerialization
{
    public static IEnumerable<TermDTO> ConvertToSOP(IEnumerable<TermDTO> Terms)
    {
        List<TermDTO> list = new List<TermDTO>();
        IEnumerable<TermDTO> minTerms = Terms.Where(t => !t.IsDontCare);
        IEnumerable<TermDTO> dontCareTerms = Terms.Where(t => t.IsDontCare);
        IEnumerable<int> result = Enumerable.Range(0, (int)Math.Pow(2, ConvertToBinary(Terms.Max(t => t.KarnaughIndex)).Length));

        list.AddRange(result.Except(minTerms.Select(t => t.KarnaughIndex)).OrderByDescending(num => num).Select(i => new TermDTO { KarnaughIndex = i, IsDontCare = false }));
        try
        {
            list.AddRange(result.Except(dontCareTerms.Select(t => t.KarnaughIndex)).OrderByDescending(num => num).Select(i => new TermDTO { KarnaughIndex = i, IsDontCare = true }));
        }
        catch { }
        return list;
    }

    public static string ConvertToBinary(int number)
    {
        return Convert.ToString(number, 2);
    }
    public static string ConvertToBinary(int number, int maxIndex)
    {
        return Convert.ToString(number, 2).PadLeft(ConvertToBinary(maxIndex).Length, '0');
    }
}
