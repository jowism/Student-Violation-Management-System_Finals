using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppValidator
{
    public class ViolationPoints
    {
         public static int GetPoints(string vioType)
         {

            if(vioType == "Minor Violation")
            {
                return  1;
            }
            else if(vioType == "Major Violation")
            {
                return  2;
            }
            else if(vioType == "Grave Violation")
            {
                return 3;
            }
            else
            {
                return 0;
            }
         }
    }
}
