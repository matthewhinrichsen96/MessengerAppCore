using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessengerApp.Services.Models.Users;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int UserId { get; set; }

    public required string UserName { get; set; } = null!;

    public required string FirstName { get; set; } = null!;

    public required string LastName { get; set; } = null!;

    public required string Avatar { get; set; } = null!;
}
