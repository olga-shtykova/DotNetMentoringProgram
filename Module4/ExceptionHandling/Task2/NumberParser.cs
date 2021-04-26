using System;
using System.Text.RegularExpressions;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            int number = 0;            
            char sign = '+';

            try
            {
                if (string.IsNullOrEmpty(stringValue))
                {
                    throw new ArgumentNullException(stringValue);
                }

                if (Regex.Match(stringValue, @"^(?:\-|\+|\s)?\d+\s*$").Success)
                {
                    foreach (var c in stringValue)
                    {
                        if (c == '-')
                        {
                            sign = '-';
                        }

                        if (c == '+')
                        {
                            sign = '+';
                        }

                        if (c != '+' && c != '-')
                        {
                            checked
                            {
                                number *= 10;
                                number += c - '0';
                            }
                        }

                    }

                    if (sign == '-')
                    {
                        unchecked
                        {
                            number = number * -1;
                        }
                        
                    }
                    else
                    {
                        number = number * 1;
                    }                    

                    return number;
                }
                else
                    throw new FormatException("Invalid string format");
            }
            catch (OverflowException)
            {
                throw new OverflowException();
            }
        }
    }
}