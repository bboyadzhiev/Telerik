using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.StringInStringService
{

    public class StringInString: IStringInString
    {
        public int GetOccuranceCount(string searched, string container)
        {
            return Regex.Matches(container, searched).Count;
        }
    }
}
