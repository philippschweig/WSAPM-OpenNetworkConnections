using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.Library.Extensions
{
    public static class StringExtension
    {
        public static bool IsNotNullAndEquals(this string string1, string string2)
        {
            return !string.IsNullOrEmpty(string1) && string1.Equals(string2);
        }
    }
}
