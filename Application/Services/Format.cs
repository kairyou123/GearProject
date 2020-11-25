using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Application.Services
{
    public static class Format
    {
        public static string Money(decimal num)
        {
            string str = num.ToString();
            string pattern = @"(\d)(?=(\d{3})+(?!\d))";
            return Regex.Replace(str,pattern,"$1,") + " VNĐ";
        }
    }
}
