using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopEntityFramework.Modelos;

public class ConsultaMedica
{
    public int ConsultaMedicaId { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime DataConsulta { get; set; }
    public string MotivoConsulta { get; set; } = null!;
    public string? Tratamento { get; set; }
    public Veterinario Veterinario { get; set; } = null!;
    public Animal Animal { get; set; } = null!;
    public bool Concluida { get; set; }

}