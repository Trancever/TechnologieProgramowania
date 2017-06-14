using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFapp.ViewModel.Rules
{
    public class ClassRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string val = (string) value;
            if (val == "H" || val == "M" || val == "L" || val == null)
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Value must be: H, M, L or empty");
            }
        }
    }
}
