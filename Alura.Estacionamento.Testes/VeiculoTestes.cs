using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
	public class VeiculoTestes
	{
		[Fact(DisplayName = "Teste n° 01")]
		[Trait("Funcionalidade", "Acelerar")]
		public void TestaVeiculoAcelerar()
		{
			var veiculo = new Veiculo();

			veiculo.Acelerar(10);

			Assert.Equal(100, veiculo.VelocidadeAtual);
		}

		[Fact(DisplayName = "Teste n° 02")]
		[Trait("Funcionalidade", "Frear")]
		public void TestaVeiculoFrear()
		{
			var veiculo = new Veiculo();

			veiculo.Frear(10);

			Assert.Equal(-150, veiculo.VelocidadeAtual);
		}

		[Fact(DisplayName = "Teste n° 03")]
		[Trait("Funcionalidade", "Tipo Veiculo")]
		public void TestaTipoVeiculo()
		{
			var automovel = TipoVeiculo.Automovel;
			var motocicleta = TipoVeiculo.Motocicleta;

			Assert.Equal(TipoVeiculo.Automovel, automovel);
			Assert.Equal(TipoVeiculo.Motocicleta, motocicleta);
		}

		[Fact(DisplayName = "Teste n° 04", Skip = "Teste ainda não implementado. Ignorar")]
		public void ValidaNomeProprietario()
		{

		}
	}
}
