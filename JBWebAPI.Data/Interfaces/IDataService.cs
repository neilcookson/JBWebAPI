using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBWebAPI.Data.Interfaces
{
    public interface IDataService
    {
        Task<T> LoadDataAsync<T> (IConfigurationSettings configurationSettings);
    }
}
