using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopEntityFramework.Modelos;

public class Veterinario
{
    public int VeterinarioId { get; set; }
    public string NomeVet { get; set; } = null!;
    public string Especialidade { get; set; } = null!;
    public int CRMV { get; set; }
    public string DiasTrabalho { get; set; } = null!;
    [Column(TypeName = "datetime")]
    public DateTime DataInclusao { get; set; } // Adicionando atributos importantes para inclusao posterior em um BD 
    [Column(TypeName = "datetime")]
    public Nullable<DateTime> DataAlteracao { get; set; }
    public ICollection<ConsultaMedica> ConsultasMedicas { get; set; } = null!;
}
