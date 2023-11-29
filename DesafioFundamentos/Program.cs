using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial, precoPorHora;

while (true)
{
    Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!\nDigite o preço inicial:");

    if (decimal.TryParse(Console.ReadLine(), out precoInicial))
    {
        break;
    }
    else
    {
        Console.WriteLine("Valor inválido. Por favor, digite um número válido e pressione Enter.");
        Console.ReadLine();
    }
}

while (true)
{
    Console.WriteLine("Agora digite o preço por hora:");

    if (decimal.TryParse(Console.ReadLine(), out precoPorHora))
    {
        break;
    }
    else
    {
        Console.WriteLine("Valor inválido. Por favor, digite um número válido e pressione Enter.");
        Console.ReadLine();
    }
}

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nPressione Enter para continuar");
    Console.ReadLine(); 
}

Console.WriteLine("O programa se encerrou");
