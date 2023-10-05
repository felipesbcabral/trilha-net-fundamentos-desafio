namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private readonly Dictionary<string, string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Insira a placa do seu carro:");
            string placa = Console.ReadLine();

            Console.WriteLine("Insira a marca do carro:");
            string marcaDoCarro = Console.ReadLine();

            if (!string.IsNullOrEmpty(placa) && !string.IsNullOrEmpty(marcaDoCarro))
            {
                if (!veiculos.ContainsKey(placa))
                {
                    // Adiciona o veiculo a lista
                    veiculos.Add(placa, marcaDoCarro);

                    Console.WriteLine($"Veiculo cadastrado, marca: {marcaDoCarro} e placa: {placa.ToUpper()}");
                }
                else
                {
                    Console.WriteLine("Um veículo com essa placa já está estacionado.");
                }
            }
            else
            {
                Console.WriteLine("Veiculo inválido.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                // Realizar um laço de repetição, exibindo os veículos estacionados
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{veiculo.Key}, {veiculo.Value}");
                }
            }
            else
            {
                Console.WriteLine("Não há veiculos estacionados");
            }
        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.ContainsKey(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string horasEstacionado = Console.ReadLine();

                if (int.TryParse(horasEstacionado, out int horas))
                {
                    // Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    // Remover a placa digitada da lista de veículos
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, não consegui entender a quantidade de horas que você digitou. Por favor, tente novamente.");
                }

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }
    }
}
