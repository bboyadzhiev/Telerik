using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _03.StringInStringService
{
    [ServiceContract]
    public interface IStringInString
    {
        [OperationContract]
        int GetOccuranceCount(string searched, string container);
    }
}
