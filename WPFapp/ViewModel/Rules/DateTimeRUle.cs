using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFapp.ViewModel.Rules
{
    public class DateTimeRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool res;
            DateTime tmp;
            res = DateTime.TryParse((string)value, out tmp);
            if (res == false)
            {
                return new ValidationResult(false, "Value must be Date in format DD/MM/YYYY hh/mm/ss.");
            }
            return ValidationResult.ValidResult;
        }
    }
}