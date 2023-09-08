using Quine_McCluskey.Domain.Terms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Domain.Results.Entities;

public class Result
{
    public IEnumerable<MinTerm> Terms { get; set; }
}
