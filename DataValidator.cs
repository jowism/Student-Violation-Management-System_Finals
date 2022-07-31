using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidator
{
    public class DataValidator
    {
        public static bool ValidateStudentNumber(string data)
        {
            return data.Length == 15 && data.StartsWith("20") && data.EndsWith("BN-0");
        }

        public static bool ValidateViolationType(string data)
        {
            return data.Length != 0 && data.StartsWith("Minor") || data.StartsWith("Major") || data.StartsWith("Grave") && data.EndsWith("Violation");
        }

    }

}
    