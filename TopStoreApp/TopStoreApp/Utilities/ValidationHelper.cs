using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace TopStoreApp.Utilities
{
    public class ValidationHelper
    {
        public static bool IsValid(object validationModel, Page page)
        {
            HideValidationFields(validationModel, page);
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(validationModel);
            bool isValid = Validator.TryValidateObject(validationModel, context, errors, true);
            
            if (!isValid)
            {
                ShowValidationFields(errors, validationModel, page);
            }

            return errors.Count() == 0;
        }
        private static void HideValidationFields(object validationModel, Page page, 
                                                 string validationLabelSuffix = "Error")
        {
            if (validationModel == null)
                return;

            var properties = GetValidatablePropertyNames(validationModel);
            foreach (var propertyName in properties)
            {
                var errorControlName = $"{propertyName}{validationLabelSuffix}";
                var control = page.FindByName<Label>(errorControlName);
                if (control != null)
                {
                    control.Text = string.Empty;
                    control.IsVisible = false;
                }
            }
        }
        private static void ShowValidationFields(List<ValidationResult> errors, object validationModel, Page page,
                                                 string validationLabelSuffix = "Error")
        {
            if (validationModel == null)
                return;

            foreach (var error in errors)
            {
                var memberName = $"{error.MemberNames.FirstOrDefault()}";
                var errorControlName = $"{memberName}{validationLabelSuffix}";
                var control = page.FindByName<Label>(errorControlName);
                if (control != null)
                {
                    control.Text = $"{error.ErrorMessage}{Environment.NewLine}";
                    control.IsVisible = true;
                }
            }
        }
        private static IEnumerable<string> GetValidatablePropertyNames(object validationModel)
        {
            var validatableProperties = new List<string>();
            var properties = GetValidatableProperties(validationModel);

            foreach (var propertyInfo in properties)
            {
                var errorControlName = $"{propertyInfo.Name}";
                validatableProperties.Add(errorControlName);
            }

            return validatableProperties;
        }
        private static List<PropertyInfo> GetValidatableProperties(object validationModel)
        {
            var properties = validationModel.GetType().GetProperties().Where(prop => prop.CanRead
                && prop.GetCustomAttributes(typeof(ValidationAttribute), true).Any()
                && prop.GetIndexParameters().Length == 0).ToList();

            return properties;
        }
    }
}
