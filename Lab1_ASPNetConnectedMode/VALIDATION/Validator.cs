using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Lab1_ASPNetConnectedMode.VALIDATION
{
    public class Validator
    {   
        public static bool IsValidId(string id)
            {
            if(!(Regex.IsMatch(id, @"^\d{4}$")))
            {
                return false;
            }
            return true;
        }
        public static bool IsValidId(string id, int size) {
            if(!(Regex.IsMatch(id, @"^\d{" + size + "}$")))
            {
                return false;
            }
            return true;
        }
        public static bool IsValidName(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!(Char.IsLetter(input[i])) && !(Char.IsWhiteSpace(input[i])))
                {
                    return false;
                }
            }
            return true;
        }
    }
}