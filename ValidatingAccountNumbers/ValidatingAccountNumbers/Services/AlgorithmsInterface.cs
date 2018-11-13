using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidatingAccountNumbers.Services
{
    public interface IAlgorithmsInterface
    {
        Task<bool> Mod();
    }
}
