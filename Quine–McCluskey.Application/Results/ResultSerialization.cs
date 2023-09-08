using Quine_McCluskey.Application.DTO;
using Quine_McCluskey.Domain.Results.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Application.Results;

internal static class ResultSerialization
{
    public static List<string> ConvertToResult(IEnumerable<Result> results)
    {
        List<string> Sop_Results = new List<string>();
        foreach (var result in results)
        {
            Sop_Results.Add(ConvertToResult(result));
        }
        return Sop_Results;
    }
    public static string ConvertToResult(Result result)
    {

        string Sop_Result = "";
        //string Pos_Result = "";
        char[] Variables = Enumerable.Range('A', result.Terms.Max(t => t.Binary.Length)).Select(x => (char)x).ToArray();
        foreach (var term in result.Terms)
        {
            string middTerm = "";
            for (int i = 0; i < term.Binary.Length; i++)
            {
                switch (term.Binary[i])
                {
                    case '0':
                        middTerm += Variables[i].ToString() + '\'';
                        break;
                    case '1':
                        middTerm += Variables[i].ToString();
                        break;
                }
            }
            if (term.Binary.Count(c => c == 'x') == term.Binary.Length)
                return "Your Function Always Return True";
            if (Sop_Result == "")
                Sop_Result = middTerm;
            else Sop_Result += "+" + middTerm;
        }
        return Sop_Result;
    }
}
