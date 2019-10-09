using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using SHF.Helper;

namespace SHF.Helper
{
    public class RequiredField : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.IsNotNull())
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(String.Format(ErrorMessage, validationContext.DisplayName));
            }
        }
    }

    public class DataLength : ValidationAttribute
    {
        private int _MaximumLength;
        private int _MinimumLength;

        public DataLength(int MaximumLength, int MinimumLength)
        {
            this._MaximumLength = MaximumLength;
            this._MinimumLength = MinimumLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.IsNull())
            {
                return ValidationResult.Success;
            }
            else
            {
                string content = Convert.ToString(value);

                if (content.Length < this._MinimumLength || content.Length > this._MaximumLength)
                {
                    return new ValidationResult(String.Format(ErrorMessage, validationContext.DisplayName, this._MinimumLength, this._MaximumLength));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }



    }

    public class DataType : ValidationAttribute
    {
        private string _dataType;
        public DataType(string dataType)
        {
            this._dataType = dataType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = new ValidationResult(string.Empty);
            if (value.IsNotNull())
            {
                switch (this._dataType)
                {
                    case busConstant.DataType.LAND_LINE_NUMBER:
                        if (Regex.IsMatch(value.ToString(), "^[0-9]{8}$"))
                        {
                            validationResult = ValidationResult.Success;
                        }
                        else
                        {
                            validationResult = new ValidationResult(String.Format(ErrorMessage, validationContext.DisplayName));
                        }
                        break;

                    case busConstant.DataType.MOBILE_NUMBER:
                        if (Regex.IsMatch(value.ToString(), "^[0-9]{10}$"))
                        {
                            validationResult = ValidationResult.Success;
                        }
                        else
                        {
                            validationResult = new ValidationResult(String.Format(ErrorMessage, validationContext.DisplayName));
                        }
                        break;

                    case busConstant.DataType.GST_NUMBER:
                        if (Regex.IsMatch(value.ToString(), "^[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9]{1}Z[0-9A-Z]{1}$"))
                        {
                            validationResult = ValidationResult.Success;
                        }
                        else
                        {
                            validationResult = new ValidationResult(String.Format(ErrorMessage, validationContext.DisplayName));
                        }
                        break;

                    case busConstant.DataType.PAN_NUMBER:
                        if (Regex.IsMatch(value.ToString(), "^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$"))
                        {
                            validationResult = ValidationResult.Success;
                        }
                        else
                        {
                            validationResult = new ValidationResult(String.Format(ErrorMessage, validationContext.DisplayName));
                        }
                        break;

                    case busConstant.DataType.ZIP_CODE:
                        if (Regex.IsMatch(value.ToString(), "^[0-9]{6}$"))
                        {
                            validationResult = ValidationResult.Success;
                        }
                        else
                        {
                            validationResult = new ValidationResult(String.Format(ErrorMessage, validationContext.DisplayName));
                        }
                        break;

                    default:

                        break;

                }
                return validationResult;
            }
            else
            {
                return new ValidationResult(String.Format(ErrorMessage, validationContext.DisplayName));
            }
        }
    }
}