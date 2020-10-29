using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ConoceTe.Citas.API.Infrastructure.Common
{
    public static class GenericFunctions
    {
        public static bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }

        public static DateTime ToDateTime(this string s, string format)
        {
            try
            {
                var r = DateTime.ParseExact(s: s, format: format, provider: CultureInfo.InvariantCulture);
                return r;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (CultureNotFoundException)
            {
                throw; // Given Culture is not supported culture
            }

        }
    }
}
