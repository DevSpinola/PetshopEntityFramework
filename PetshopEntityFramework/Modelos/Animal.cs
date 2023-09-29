using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopEntityFramework.Modelos;
public class Animal
{
    //Declaração de variáveis -> atributos
    public int AnimalId { get; set; }
    public string Nome { get; set; } = null!;
    public DateTime Datanasc { get; set; }
    public string Especie { get; set; } = null!;
    public string Raca { get; set; } = null!;
    public float Peso { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime DataInclusao { get; set; } // Adicionando atributos importantes para inclusao posterior em um BD 
    [Column(TypeName = "datetime")]
    public Nullable<DateTime> DataAlteracao { get; set; }
    public ICollection<ConsultaMedica> ConsultasMedicas { get; set; } = null!;



}

