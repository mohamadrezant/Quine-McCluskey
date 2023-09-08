using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quine_McCluskey.Application.DTO;
using Quine_McCluskey.Application.Interfaces;
using Quine_McCluskey.Application.Services;

namespace Quine_McCluskey.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TerminalController : ControllerBase
{
    private readonly IFunctionService FunctionService;
    public TerminalController(IFunctionService functionService)
    {
        this.FunctionService = functionService;
    }
    [HttpPost]
    public async Task<ResultDTO> Post(InputFunctionDTO model)
    {
        var result = await FunctionService.Solve(model);
        return result;
    }
}
