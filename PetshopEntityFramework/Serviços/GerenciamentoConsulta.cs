using PetshopEntityFramework.Modelos;
namespace PetshopEntityFramework.Serviços;

internal class GerenciamentoConsulta : GerenciamentoPetShop
{
    public void AgendarConsulta()
    {
        Console.WriteLine("---->Agendamento Consulta<----");
        Console.WriteLine("Informe o nome do animal que irá a consulta");
        string animal = Console.ReadLine()!.ToUpper();
        if (ListaAnimais.Any(a => a.Nome.ToUpper() == animal))
        {
            Animal animalASerConsultado = ListaAnimais.First((a => a.Nome.ToUpper() == animal));
            Console.WriteLine("Informe a data desejada para agendar (dd/mm/aaaa): ");
            DateTime dataConsulta = DateTime.Parse(Console.ReadLine()!);
            Console.WriteLine("Informe o motivo da consulta: ");
            string motivoConsulta = Console.ReadLine()!;
            ConsultaMedica novaConsulta = new ConsultaMedica
            {
                DataConsulta = dataConsulta,
                MotivoConsulta = motivoConsulta,
                Animal = animalASerConsultado,
                Veterinario = ListaVet.First(),
                Concluida = false
            };
            context.Add(novaConsulta);
            context.SaveChanges();
            Console.WriteLine("Consulta Agendada com Sucesso!");
        }
        else
        {
            Console.WriteLine($"Não há nenhum animal com nome {animal} cadastrado");
        }


        Console.WriteLine("Digite alguma tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();
    }

    //Metodo para registrar o decorrer da consulta
    public void RegistrarConsulta()
    {
        Console.WriteLine("---->Registro de Consulta do Pet<----");
        Console.WriteLine("Informe o nome do pet: ");
        string animal = Console.ReadLine()!.ToUpper();
        if (ListaConsultas.Any(a => a.Animal.Nome == animal))
        {
            ConsultaMedica consultaEmAlteracao = ListaConsultas.First(a => a.Animal.Nome == animal);
            consultaEmAlteracao.DataConsulta = DateTime.Now;
            Console.WriteLine("Data da Consulta: " + consultaEmAlteracao.DataConsulta);
            Console.WriteLine("Informe o tratamento indicado ou outro(s) procedimento(s):");
            consultaEmAlteracao.Tratamento = Console.ReadLine();
            consultaEmAlteracao.Concluida = true;
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Esse animal não existe ou não possui nenhuma consulta agendada");
        }
        Console.WriteLine("Digite alguma tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();
    }

    public void ExibirConsulta()
    {
        Console.WriteLine("Informe o nome do pet: ");
        string animal = Console.ReadLine()!.ToUpper();
        if (ListaConsultas.Any(a => a.Animal.Nome == animal))
        {
            ConsultaMedica consultaEmExibicao = ListaConsultas.First(a => a.Animal.Nome == animal);
            Console.WriteLine($"Data da consulta: {consultaEmExibicao.DataConsulta}");
            Console.WriteLine($"Motivo da consulta: {consultaEmExibicao.MotivoConsulta}");
            Console.WriteLine($"Tratamento ou outros procedimentos: {consultaEmExibicao.Tratamento}");
            Console.WriteLine($"Veterinário responsável: {consultaEmExibicao.Veterinario.NomeVet}");
            Console.WriteLine(consultaEmExibicao.Concluida ? "Consulta concluída" : "Consulta ainda não concluída");
        }
        else
        {
            Console.WriteLine("Esse animal não existe ou não possui nenhuma consulta agendada");
        }
        Console.WriteLine("Digite alguma tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();
    }
}
