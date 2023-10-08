using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
	public class VeiculoTestes : IDisposable
	{
		private Veiculo veiculo;
		public ITestOutputHelper SaidaConsoleTeste;

		public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
		{
			SaidaConsoleTeste = _saidaConsoleTeste;
			SaidaConsoleTeste.WriteLine("Construtor invocado.");
			veiculo = new Veiculo();
		}

		[Fact]
		public void TestaVeiculoAcelerarComParamentro10()
		{
			//var veiculo = new Veiculo();

			veiculo.Acelerar(10);

			Assert.Equal(100, veiculo.VelocidadeAtual);
		}

		[Fact]
		public void TestaVeiculoFrearComParametro10()
		{
			//var veiculo = new Veiculo();

			veiculo.Frear(10);

			Assert.Equal(-150, veiculo.VelocidadeAtual);
		}

		[Fact]
		public void TestaTipoVeiculo()
		{
			var automovel = TipoVeiculo.Automovel;
			var motocicleta = TipoVeiculo.Motocicleta;

			Assert.Equal(TipoVeiculo.Automovel, automovel);
			Assert.Equal(TipoVeiculo.Motocicleta, motocicleta);
		}

		[Fact(Skip = "Teste ainda não implementado. Ignorar")]
		public void ValidaNomeProprietarioDoVeiculo()
		{

		}

		[Fact]
		public void FichaDeInformacaoDoVeiculo()
		{
			//var veiculo = new Veiculo();
			veiculo.Proprietario = "Daniel Gomes";
			veiculo.Tipo = TipoVeiculo.Automovel;
			veiculo.Placa = "BUG-8080";
			veiculo.Cor = "Preto";
			veiculo.Modelo = "Focus";

			string dados = veiculo.ToString();

			Assert.Contains("Ficha do veículo:", dados);
		}

		public void Dispose()
		{
			SaidaConsoleTeste.WriteLine("Dispose invocado");
		}
	}
}
