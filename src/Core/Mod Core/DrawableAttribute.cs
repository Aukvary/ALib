using System;
using System.Collections.Generic;

namespace ALib;

[AttributeUsage(AttributeTargets.Class)]
internal class DrawableAttribute : Attribute
{
    private List<string> _methods;

    public IEnumerable<string> Methods => _methods;

    public DrawableAttribute(params string[] methodNames)
    {
        _methods = new List<string>();
        foreach (var method in methodNames)
        {
            _methods.Add(method);
        }
    }
}