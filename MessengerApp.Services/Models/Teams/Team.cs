using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessengerApp.Services.Models.Teams;

public class Team
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int TeamId { get; set; }

    public required string Name { get; set; }

    public required string Avatar { get; set; }
}
