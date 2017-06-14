using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFapp.ViewModel.Rules
{
    public class BoolRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool res, tmp;
            res = bool.TryParse((string)value, out tmp);            
            if (res == false)
            {
                return new ValidationResult(false, "Value must be True or False. Can't be empty.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
