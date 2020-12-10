using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram.ResponseHandling
{
    public interface IRespondable
    {
        string status { get; set; }
    }
}
