using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models
{
    public class User

    {
        [Key]
        // Otomatik artan (auto-increment) olarak yapılandırılır
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password can be min 6 characters.")]
        [MaxLength(16, ErrorMessage = "Password can be max 16 characters.")]
        [StringLength(100)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName?.ToUpper()}";
        public bool Locked { get; set; } = false;
        public DateTime RegisterAt { get; set; }

        public User()
        {
            RegisterAt = DateTime.Now;
        }
        [Required]
        [StringLength(50)]

        public string Role { get; set; } = "user";
        
    }

   

    

    
}