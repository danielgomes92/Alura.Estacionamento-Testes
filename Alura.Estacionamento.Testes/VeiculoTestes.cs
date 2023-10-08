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
			veiculo.Acelerar(10);

			Assert.Equal(100, veiculo.VelocidadeAtual);
		}

		[Fact]
		public void TestaVeiculoFrearComParametro10()
		{
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

		[Fact(Skip = "Teste ainda n�o implementado. Ignorar")]
		public void ValidaNomeProprietarioDoVeiculo()
		{

		}

		[Fact]
		public void FichaDeInformacaoDoVeiculo()
		{
			veiculo.Proprietario = "Daniel Gomes";
			veiculo.Tipo = TipoVeiculo.Automovel;
			veiculo.Placa = "BUG-8080";
			veiculo.Cor = "Preto";
			veiculo.Modelo = "Focus";

			string dados = veiculo.ToString();

			Assert.Contains("Ficha do ve�culo:", dados);
		}

		[Fact]
		public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
		{
			string nomeProprietario = "Ab";

			Assert.Throws<System.FormatException>(
				() => new Veiculo(nomeProprietario));
		}

		[Fact]
		public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
		{
			string placa = "ABCD1234";

			var mensagem = Assert.Throws<FormatException>(
				() => new Veiculo().Placa = placa);

			Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
		}

		public void Dispose()
		{
			SaidaConsoleTeste.WriteLine("Dispose invocado");
		}
	}
}
