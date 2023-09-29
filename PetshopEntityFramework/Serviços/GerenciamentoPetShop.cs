using PetshopEntityFramework.Data;
using PetshopEntityFramework.Modelos;
namespace PetshopEntityFramework.Serviços;
internal class GerenciamentoPetShop

{
    protected PetshopContexto context = new();
    protected List<Animal> ListaAnimais => context.Animais.ToList();
    protected List<Veterinario> ListaVet => context.Veterinarios.ToList();
    protected List<ConsultaMedica> ListaConsultas => context.ConsultasMedicas.ToList();       

}
