﻿using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Testes
{
	public class PatioTestes
	{
		[Fact]
		public void ValidaFaturamento()
		{
			var estacionamento = new Patio();
			var veiculo = new Veiculo();

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
		public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
		{
			var estacionamento = new Patio();
			var veiculo = new Veiculo();
			veiculo.Proprietario = proprietario;
			veiculo.Placa = placa;
			veiculo.Cor = cor;
			veiculo.Modelo = modelo;

			estacionamento.RegistrarEntradaVeiculo(veiculo);
			estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

			double faturamento = estacionamento.TotalFaturado();

			Assert.Equal(2, faturamento);
		}
	}
}
