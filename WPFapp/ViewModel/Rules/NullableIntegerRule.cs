using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFapp.ViewModel.Rules
{
    public class NullableIntegerRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                bool res;
                int tmp;
                res = int.TryParse((string)value, out tmp);
                if (res == false)
                {
                    return new ValidationResult(false, "Value must be integer or empty.");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
