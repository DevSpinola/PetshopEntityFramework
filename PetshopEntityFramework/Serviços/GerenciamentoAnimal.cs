using PetshopEntityFramework.Modelos;
namespace PetshopEntityFramework.Serviços;

internal class GerenciamentoAnimal : GerenciamentoPetShop
{
    public void CadastrarAnimal()
    {
        //Método para cadastrar o pet -> animal
        Console.WriteLine("---> Cadastro de Animais <---");
        Console.Write("Digite o nome: ");
        string Nome = Console.ReadLine()!;

        Console.Write("Digite a espécie: ");
        string Especie = Console.ReadLine()!;

        Console.Write("Digite a raça: ");
        string Raca = Console.ReadLine()!;

        Console.Write("Digite a data de nascimento (Formato: dd/mm/aaaa): ");
        DateTime Datanasc = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Digite o peso: ");
        float Peso = float.Parse(Console.ReadLine()!);
        Animal animal = new()
        {
            Nome = Nome,
            Especie = Especie,
            Raca = Raca,
            Datanasc = Datanasc,
            Peso = Peso,
            DataInclusao = DateTime.Now
        };       
        context.Add(animal);
        context.SaveChanges();
        Console.WriteLine("Animal Cadastrado com Sucesso!");

        Console.WriteLine("Digite alguma tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();// Limpa o Console        
       
    }
    public void AlterarAnimal()
    {
        //Método para alterar dados no animal
        Console.WriteLine("---> Alteração de Cadastro do Animal <---");
        Console.WriteLine("Informe o nome do animal para alterar dados: ");
        string animal = Console.ReadLine()!.ToUpper();
        if (ListaAnimais.Any(a => a.Nome.ToUpper() == animal))
        {
            Animal animalEmAlteracao = ListaAnimais.First((a => a.Nome.ToUpper() == animal));
            Console.Write("Nome: ");
            animalEmAlteracao.Nome = Console.ReadLine()!;

            Console.Write("Digite a espécie: ");
            animalEmAlteracao.Especie = Console.ReadLine()!;

            Console.Write("Digite a raça: ");
            animalEmAlteracao.Raca = Console.ReadLine()!;
            while (true)
            {
                try
                {
                    Console.Write("Digite a data de nascimento (Formato: dd/mm/aaaa): ");
                    animalEmAlteracao.Datanasc = DateTime.Parse(Console.ReadLine()!);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato de Data Inválido, Tente Novamente");
                }
            }


            Console.Write("Digite o peso: ");
            animalEmAlteracao.Peso = float.Parse(Console.ReadLine()!);

            animalEmAlteracao.DataAlteracao = DateTime.Now;// hora do computador vai ser a dataAlteracao
            context.SaveChanges();
            Console.WriteLine("Animal Alterado com sucesso");
            Console.WriteLine("Digite alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }
        else
        {
            Console.WriteLine($"Nenhum animal com o Nome {animal} cadastrado.");
            Console.WriteLine("Pressione alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }

    }
    public void ConsultarAnimal()
    {
        //método para consulta os dados
        Console.WriteLine("---> Consultar dados do animal <---");

        Console.WriteLine("Informe o Nome do animal para consultar dados: ");
        string animal = Console.ReadLine()!.ToUpper();
        if (ListaAnimais.Any(a => a.Nome.ToUpper() == animal))
        {
            Animal AnimalASerListado = ListaAnimais.First((a => a.Nome.ToUpper() == animal));
            Console.WriteLine("Dados encontrados:");
            Console.WriteLine("Nome: " + AnimalASerListado.Nome);
            Console.WriteLine("Data de Nascimento: " + AnimalASerListado.Datanasc);
            Console.WriteLine($"Espécie: {AnimalASerListado.Especie}");
            Console.WriteLine("Raça: " + AnimalASerListado.Raca);
            Console.WriteLine("Peso: " + AnimalASerListado.Peso);
            Console.WriteLine($"Data de Registro: {AnimalASerListado.DataInclusao}");
            if (AnimalASerListado.DataAlteracao != null) // Caso tenha dataAlteracao será apontada no console
            {
                Console.WriteLine($"Ultima alteracão em: {AnimalASerListado.DataAlteracao}");
            }
            Console.WriteLine("Pressione alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }
        else
        {
            Console.WriteLine($"Nenhum animal com o Nome {animal} cadastrado.");
            Console.WriteLine("Pressione alguma tecla para voltar ao Menu");
            Console.ReadKey();
            Console.Clear();// Limpa o Console
        }

    }
    public void ExcluirAnimal()
    {
        Console.WriteLine("Informe o Nome do animal para excluir dados: ");
        string animal = Console.ReadLine()!.ToUpper();
        if (ListaAnimais.Any(a => a.Nome.ToUpper() == animal))
        {
            Console.WriteLine("Digite o Nome do animal novamente para confirmar a exclusão:");
            if (animal == Console.ReadLine()!.ToUpper())
            {
                ListaAnimais.Remove(ListaAnimais.First((a => a.Nome.ToUpper() == animal)));
                context.SaveChanges();
            }

        }
        else
        {
            Console.WriteLine($"Nenhum animal com o Nome {animal} cadastrado.");
        }
        Console.WriteLine("Digite alguma tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();// Limpa o Console
    }
    public void ConsultarAnimaisCadastrados()
    {
        ListaAnimais.ForEach(animal =>
        {
            Console.WriteLine($"Nome: {animal.Nome}, Espécie: {animal.Especie}");
        });
        Console.WriteLine("Digite alguma tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();// Limpa o Console
    }
}
