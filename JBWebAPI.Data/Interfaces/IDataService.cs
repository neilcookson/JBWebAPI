using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBWebAPI.Data.Interfaces
{
    public interface IDataService
    {
        T LoadData<T> (IConfigurationSettings configurationSettings);
    }
}
