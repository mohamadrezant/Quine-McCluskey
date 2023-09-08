using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quine_McCluskey.Common;
namespace Quine_McCluskey.Application.DTO;

public class InputFunctionDTO
{
    public string FunctionString { get; set; }
    public IEnumerable<TermDTO> Terms { get; set; }
    /// <summary>
    /// if Function is sop state = 0
    /// if Function is pos state = 1
    /// </summary>
    public bool State { get; set; }
    internal int? maxKarnaughIndex { get; set; }
}
