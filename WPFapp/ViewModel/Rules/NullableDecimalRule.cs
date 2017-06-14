using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFapp.ViewModel.Rules
{
    public class NullableDecimalRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                bool res;
                decimal tmp;
                res = decimal.TryParse((string)value, out tmp);
                if (res == false)
                {
                    return new ValidationResult(false, "Value must be decimal or empty.");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
