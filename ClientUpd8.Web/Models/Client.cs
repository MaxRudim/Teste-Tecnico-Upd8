using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientUpd8.Models
{
  public class Client
  {

    [Key]
    public Guid ClientId { get; set; }

    [StringLength(25, MinimumLength = 2, ErrorMessage = "Invalid name length")]
    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid adress length")]
    public string Address { get; set; }

    [Required]
    public string State { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Birthdate { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public string Cpf { get; set; }

  }
}