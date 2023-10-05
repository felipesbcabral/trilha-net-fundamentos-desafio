using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;
bool precoValido = false;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");

if (decimal.TryParse(Console.ReadLine(), out precoInicial))
{
    while (!precoValido)
    {
        Console.WriteLine("Agora digite o preço por hora:");
        if (decimal.TryParse(Console.ReadLine(), out precoPorHora) && precoPorHora > 0)
        {
            precoValido = true;
        }
        else
        {
            Console.WriteLine("Preço por hora inválido. Deve ser um número maior que zero. Por favor, tente novamente.");
        }
    }

    // Instancia a classe Estacionamento, já com os valores obtidos anteriormente
    Estacionamento es = new(precoInicial, precoPorHora);

    bool exibirMenu = true;

    // Realiza o loop do menu
    while (exibirMenu)
    {
        Console.Clear();
        Console.WriteLine("Digite a sua opção:");
        Console.WriteLine("1 - Cadastrar veículo");
        Console.WriteLine("2 - Listar veículos");
        Console.WriteLine("3 - Remover veículo");
        Console.WriteLine("4 - Encerrar");

        switch (Console.ReadLine())
        {
            case "1":
                es.AdicionarVeiculo();
                break;

            case "2":
                es.ListarVeiculos();
                break;

            case "3":
                es.RemoverVeiculo();
                break;

            case "4":
                exibirMenu = false;
                break;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }

        Console.WriteLine("Pressione uma tecla para continuar");
        Console.ReadLine();
    }

    Console.WriteLine("O programa se encerrou");
}
else
{
    Console.WriteLine("Preço inicial inválido. Por favor, tente novamente.");
}
