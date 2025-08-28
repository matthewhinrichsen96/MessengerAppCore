using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessengerApp.Services.Models.Teams;

public class Team
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int TeamId { get; set; }

    required
    public string Name
    { get; set; }

    required
    public string Avatar
    { get; set; }
}
