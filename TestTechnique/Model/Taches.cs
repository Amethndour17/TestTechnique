using System.ComponentModel.DataAnnotations;

namespace TestTechnique.Model;

public class Taches
{
    public int Id { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
    [Required]
    [StringLength(200)]
    public string? Tittre { get; set; }
    [Required]
    [StringLength(11)]
    public string? Description { get; set; }

}
