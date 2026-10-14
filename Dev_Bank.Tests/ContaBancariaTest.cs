using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Bank.Tests
{
    public class ContaBancariaTest
    {
        [Fact]
        public void CriarConta_ComDadosValidos_DeveIniciarComSaldoZero()
        {
            // Arrange
            var numeroConta = "12345-6";
            var agencia = "001";

            // Act
            var conta = new Dev_Bank.Domain.ContaBancaria(numeroConta, agencia);

            // Assert
            Assert.Equal(numeroConta, conta.NumeroConta);
            Assert.Equal(agencia, conta.Agencia);
            Assert.Equal(0.00m, conta.Saldo);
        }
        [Fact]
        public void Depositar_ValorValido_DeveAtualizarSaldo()
        {
            // Arrange
            var conta = new Dev_Bank.Domain.ContaBancaria("12345-6", "0001");
            var valorDeposito = 150.50m;

            // Act
            conta.Depositar(valorDeposito);

            // Assert
            Assert.Equal(150.50m, conta.Saldo);
        }

        [Fact]
        public void Depositar_ComValorInvalido_DeveLancarExcecao()
        {
            // Arrange
            var conta = new Dev_Bank.Domain.ContaBancaria("12345-6", "0001");
            var valorInvalido = -50.00m;

            Assert.Throws<ArgumentException>(() => conta.Depositar(valorInvalido));
        }
        [Fact]
        public void Sacar_ComSaldoSuficiente_DeveDiminuirSaldo()
        {
            // Arrange
            var conta = new Dev_Bank.Domain.ContaBancaria("12345-6", "0001");
            conta.Depositar(200.00m);
           

            // Act
            conta.Sacar(50.00m);

            // Assert
            Assert.Equal(150.00m, conta.Saldo);
        }
        [Fact]
        public void Sacar_ComValorInvalido_DeveLancarArgumentException()
        {
            // Arrange
            var conta = new Dev_Bank.Domain.ContaBancaria("12345-6", "0001");
           
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => conta.Sacar(50.00m));
        }
        [Fact]
        public void Sacar_ComSaldoInsuficiente_DeveLancarInvalidOperationException()
        {
            // Arrange
            var conta = new Dev_Bank.Domain.ContaBancaria("12345-6", "0001");
           

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => conta.Sacar(150.00m));
        }
    }
}