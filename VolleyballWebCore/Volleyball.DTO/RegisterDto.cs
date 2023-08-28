using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [MinLength(8, ErrorMessage = "Hasło musi mieć co najmniej 8 znaków.")]
        public string Password { get; set; }

        public int? PositionId { get; set; }

        public bool Gender { get; set; }

        public string? Address { get; set; }

        [Phone(ErrorMessage = "Niepoprawny format numeru telefonu.")]
        public string? PhoneNumber { get; set; }

        public int? BirthYear { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public string? Hobby { get; set; }

        public int? JerseyNumber { get; set; }

        public int? BlockRange { get; set; }

        public int? AttackRange { get; set; }

        public string? VolleyballIdol { get; set; }

        public string? AdditionalEmail { get; set; }

        public string? PersonalInfo { get; set; }

        public string? City { get; set; }

    }
}