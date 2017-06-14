using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFapp.ViewModel.Rules
{
    public class ProductLineRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == "r" || value == "R" || value == "m" || value == "M" ||
                value == "t" || value == "T" || value == "s" || value == "S" ||
                value == null)
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Value must be: r, R, m, M, t, T, s, S or empty");
            }

        }
    }
}
