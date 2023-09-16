﻿

namespace TestTechnique.Model;

public class Eleve
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime dateCreation { get; set; }
    [Required]
    [StringLength(200)]
    public string NomEtPrenom { get; set; }
    [Required]
    [StringLength(11)]
    public string dateNaissance { get; set; }
    [Required]
    [StringLength(100)]
    public string lieuNaissance { get; set; }
    [Required]
    [StringLength(100)]
    public string niveau  { get; set; }
    public Taches Tache { get; set; }


}
