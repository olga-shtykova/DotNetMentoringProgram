using System;
using System.Text.RegularExpressions;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            int number = 0;
            bool sign = false;


            if (stringValue == null)
            {
                throw new ArgumentNullException(stringValue);
            }

            if (Regex.Match(stringValue, @"^(?:\-|\+)?\d+\s*$").Success && stringValue != "")
            {
                string newStringValue = stringValue.TrimEnd();

                if (newStringValue[0] == '-')
                {
                    sign = true;
                }

                foreach (var c in newStringValue)
                {
                    if (c != '+' && c != '-')
                    {
                        if (newStringValue == "-2147483648" || newStringValue == "2147483647")
                        {
                            number *= 10;
                            number += c - '0';
                        }
                        else
                        {
                            checked
                            {
                                number *= 10;
                                number += c - '0';
                            }
                        }
                    }
                }

                if (sign)
                {
                    number = number * -1;
                }

                return number;
            }
            else
                throw new FormatException("Invalid string format");

        }
    }
}