using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertStringToIntegerItem
{
    public class NumberParser: INumberParser
    {
        public int Parse(string stringValue)
        {
            string inputText = String.Empty;
            if (!string.IsNullOrEmpty(stringValue))
            { inputText = stringValue.Trim(); }
            else
            { throw new ArgumentNullException(); }
            if (inputText.Length == 0)
            { throw new FormatException(); }
            int res = 0;
            long res2 = 0;
            long ten2 = 1;
            int ten = 1;
            for (int i = inputText.Length - 1; i > 0; i--)
            {
                char foo = inputText[i];
                int bar = foo - '0';
                if (bar >= 0 && bar <= 9)
                {
                    res += bar * ten;
                    res2 += bar * ten2;
                    if (res2 > int.MaxValue)
                    { throw new OverflowException(); }
                    ten *= 10;
                    ten2 *= 10;
                }
                else
                {
                    if (inputText[i] == '-' || inputText[i] == '+')
                    {
                        if (inputText[i] == '-')
                        {
                            res *= -1;
                            if (i > 0)
                                throw new FormatException();
                        }
                    }
                    else
                        throw new FormatException();
                }
            }

            return res;
            // throw new NotImplementedException();
        }
    }
}
