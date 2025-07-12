using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessengerApp.Services.Models.Teams;

public class Teams
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int TeamId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Avatar { get; set; }
}