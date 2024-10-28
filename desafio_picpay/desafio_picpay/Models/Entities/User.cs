using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace desafio_picpay.Models.Entities
{
    public class User : Entity
    {
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must be a maximum of 100 characters.")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(100, ErrorMessage = "Surname must be a maximum of 100 characters.")]
        public string Surname { get; set; }

        [JsonPropertyName("cpf")]
        [Required(ErrorMessage = "CPF is required.")]
        [RegularExpression(@"\d{11}", ErrorMessage = "CPF must have 11 digits.")]
        public string CPF { get; set; }

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(24, MinimumLength = 9, ErrorMessage = "Password must be between 9 and 24 characters.")]
        public string Password { get; private set; }

        public User(string name, string surname, string cpf, string email, string password)
        {
            Name = name;
            Surname = surname;
            CPF = cpf;
            Email = email;
            Password = password;
        }

        public List<string> Validate()
        {
            var errors = new List<string>();

            var validationContext = new ValidationContext(this);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(this, validationContext, validationResults, true);

            if (!isValid)
            {
                foreach (var validationResult in validationResults)
                {
                    if (!string.IsNullOrEmpty(validationResult.ErrorMessage))
                    {
                        errors.Add(validationResult.ErrorMessage);
                    }
                }
            }

            return errors;
        }
    }
}
