

namespace TestTechnique.Model;

public class Taches
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
    [Required]
    [StringLength(200)]
    public string? Tittre { get; set; }
    [Required]
    [StringLength(11)]
    public string? Description { get; set; }
    [Required]
    public int idUser { get; set; }
    public Administrateur? Admin { get; set; }

}
