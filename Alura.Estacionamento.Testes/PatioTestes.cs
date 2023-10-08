using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
	public class PatioTestes : IDisposable
	{
		private Veiculo veiculo;
		public ITestOutputHelper SaidaConsoleTeste;

		public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
		{
			SaidaConsoleTeste = _saidaConsoleTeste;
			SaidaConsoleTeste.WriteLine("Construtor invocado.");
			veiculo = new Veiculo();
		}

		[Fact]
		public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
		{
			var estacionamento = new Patio();
			//var veiculo = new Veiculo();

			veiculo.Proprietario = "Daniel Gomes";
			veiculo.Tipo = TipoVeiculo.Automovel;
			veiculo.Cor = "Preto";
			veiculo.Modelo = "Palio";
			veiculo.Placa = "DFG-8080";

			estacionamento.RegistrarEntradaVeiculo(veiculo);
			estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

			double faturamento = estacionamento.TotalFaturado();

			Assert.Equal(2, faturamento);
		}

		[Theory]
		[InlineData("Daniel Gomes", "ABC-1234", "Preto", "Palio")]
		[InlineData("Julio Gomes", "DEF-1234", "Prata", "Gol")]
		[InlineData("Thalia Freitas", "GHI-1234", "Verde", "Fiesta")]
		public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
		{
			var estacionamento = new Patio();
			//var veiculo = new Veiculo();
			veiculo.Proprietario = proprietario;
			veiculo.Placa = placa;
			veiculo.Cor = cor;
			veiculo.Modelo = modelo;

			estacionamento.RegistrarEntradaVeiculo(veiculo);
			estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

			double faturamento = estacionamento.TotalFaturado();

			Assert.Equal(2, faturamento);
		}

		[Theory]
		[InlineData("Julio Gomes", "DEF-1234", "Prata", "Gol")]
		public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
		{
			var estacionamento = new Patio();
			//var veiculo = new Veiculo();
			veiculo.Proprietario = proprietario;
			veiculo.Placa = placa;
			veiculo.Cor = cor;
			veiculo.Modelo = modelo;

			estacionamento.RegistrarEntradaVeiculo(veiculo);

			var veiculoConsultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

			Assert.Contains("### Ticket Estacionamento Alura ###", veiculoConsultado.Ticket);
		}

		[Fact]
		public void AlterarDadosVeiculoDoProprioVeiculo()
		{
			var estacionamento = new Patio();
			//var veiculo = new Veiculo();

			veiculo.Proprietario = "Daniel Gomes";
			veiculo.Placa = "DFG-8080";
			veiculo.Cor = "Preto";
			veiculo.Modelo = "Palio";
			estacionamento.RegistrarEntradaVeiculo(veiculo);

			var alterado = new Veiculo();
			alterado.Proprietario = "Daniel Gomes";
			alterado.Placa = "DFG-8080";
			alterado.Cor = "Vermelho";
			alterado.Modelo = "Palio";

			Veiculo veiculoAlterado = estacionamento.AlterarDadosVeiculo(alterado);

			Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
		}

		public void Dispose()
		{
			SaidaConsoleTeste.WriteLine("Dispose invocado");
		}
	}
}
