using Quine_McCluskey.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Application.Interfaces;

public interface IFunctionService
{
    Task<ResultDTO> Solve(InputFunctionDTO function);
}
