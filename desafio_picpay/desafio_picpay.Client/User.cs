using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace desafio_picpay.Client
{
    public class User
    {
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(100, ErrorMessage = "The name must have a maximum of 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The surname is required.")]
        [StringLength(100, ErrorMessage = "The surname must have a maximum of 100 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The CPF is required.")]
        [RegularExpression(@"\d{11}", ErrorMessage = "The CPF must have 11 digits.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "The email is required.")]
        [EmailAddress(ErrorMessage = "The email format is invalid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password is required.")]
        [StringLength(24, MinimumLength = 9, ErrorMessage = "The password must be between 9 and 24 characters.")]
        public string Password { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "Please select a valid option.")]
        [CustomValidation(typeof(User), nameof(ValidateSelectedOption))]
        public string Type { get; set; }

        public static ValidationResult ValidateSelectedOption(string selectedOption, ValidationContext context)
        {
            return selectedOption == "Select..."
                ? new ValidationResult("Please select a valid option.")!
                : ValidationResult.Success!;
        }
    }
}
