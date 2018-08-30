using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBWebAPI.API.Helpers
{
    public interface IFilterParser<T> where T : class
    {
        Func<T, bool> GetFilter(string rawFilter);
    }
}
