using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Dolphin.Freight.Web.Helpers
{
    /// <summary>
    /// 用於定義MaxFileSize Annotation的檢查
    /// </summary>
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var file = value as IFormFile;

            if (file.Length > 0)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult("Maximum file size: " + _maxFileSize);
                }
            }

            return ValidationResult.Success;
        }
    }
}
