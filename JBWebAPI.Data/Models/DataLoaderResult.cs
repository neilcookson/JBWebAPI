using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBWebAPI.Data.Models
{
    public class DataLoaderResult
    {
        public Result Result { get; set; }
        public Status Status { get; set; }
    }

    public class Result
    {
        public List<DataLoaderProduct> Products { get; set; }
    }

    public class Status
    {
        public int ActionType { get; set; }
        public bool IsSuccess { get; set; }
        public string ActionString { get; set; }
    }

}
