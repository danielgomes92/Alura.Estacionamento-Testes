using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
	public class VeiculoTestes
	{
		[Fact]
		public void TestaVeiculoAcelerar()
		{
			var veiculo = new Veiculo();

			veiculo.Acelerar(10);

			Assert.Equal(100, veiculo.VelocidadeAtual);
		}

		[Fact]
		public void TestaVeiculoFrear()
		{
			var veiculo = new Veiculo();

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
		public void ValidaNomeProprietario()
		{

		}
	}
}
