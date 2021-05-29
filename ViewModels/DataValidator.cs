using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace PAIN_WPF.ViewModels
{
    class DataValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is BindingExpression)
                value = getValueFromBindingExpression(value);
            if (value is string)
            {
                if ((string)value == "")
                    return new ValidationResult(false, "This field cannot be empty!");
                else
                    return ValidationResult.ValidResult;
            }
            else if (value is DateTime)
            {
                if ((DateTime)value > DateTime.Now)
                    return new ValidationResult(false, "Release date cannot be newer than the current date!");
                else
                    return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Invalid data format!");
        }

        private object getValueFromBindingExpression(object bindingExpression)
        {
            BindingExpression binding = (BindingExpression)bindingExpression;
            string resolvedPropertyName = binding.GetType()
                .GetProperty("ResolvedSourcePropertyName", BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance)
                .GetValue(binding, null).ToString();
            object resolvedSource = binding.GetType()
                .GetProperty("ResolvedSource", BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance).GetValue(binding, null);
            return resolvedSource.GetType().GetProperty(resolvedPropertyName).GetValue(resolvedSource, null);
        }
    }
}
