using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quine_McCluskey.Domain.Terms.Entities;

public class MinTerm
{
    private int? _int;
    private List<int> _intList = new List<int>();
    private string? _binary;
    private bool _isUsed;
    private bool _isDontCare;
    public int? Int
    {
        get
        {
            return _int;
        }
        set
        {
            _int = value;
        }
    }
    public List<int> IntList
    {
        get
        {
            if ((_intList.Count == 0 || _intList == null) && _int != null)
                return new List<int>() { _int ?? default(int) };
            else
                return _intList;
        }
        set
        {
            _intList = value;
        }
    }
    public string? Binary

    {
        get

        {
            return _binary;
        }
        set

        {
            _binary = value;
        }

    }
    public bool IsUsed
    {
        get
        {
            return _isUsed;
        }
        set
        {
            _isUsed = value;
        }
    }
    public bool IsDontCare
    {
        get
        {
            return _isDontCare;
        }
        set
        {
            _isDontCare = value;
        }
    }
}
