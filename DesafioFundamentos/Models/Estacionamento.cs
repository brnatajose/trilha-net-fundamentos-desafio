using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private Dictionary<string, DateTime> veiculosEntrada = new Dictionary<string, DateTime>();
        private Regex placaRegex = new Regex(@"^[A-Z]{3}\d{4}$|^[A-Z]{3}\d[A-Z]\d{2}$");

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            if (placaRegex.IsMatch(placa))
            {
                veiculosEntrada[placa] = DateTime.Now;
                Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento em {veiculosEntrada[placa]}.");
            }
            else
            {
                Console.WriteLine("Placa inválida. A placa deve seguir o formato ABC1234 ou ABC1A23. Tente novamente.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculosEntrada.ContainsKey(placa))
            {
                DateTime entrada = veiculosEntrada[placa];

                Console.WriteLine($"Digite a quantidade de horas que o veículo permaneceu estacionado (horário de entrada: {entrada}):");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    veiculosEntrada.Remove(placa);

                    Console.WriteLine($"O veículo {placa} entrou em {entrada} e foi removido. O preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Valor inválido para horas.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculosEntrada.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculosEntrada)
                {
                    Console.WriteLine($"Placa: {veiculo.Key}, Entrada: {veiculo.Value}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
