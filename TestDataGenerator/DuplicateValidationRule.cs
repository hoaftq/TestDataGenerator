using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestDataGenerator.Models;

namespace TestDataGenerator
{
    class DuplicateValidationRule : ValidationRule
    {
        public List<ConnectionModel> Items { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
