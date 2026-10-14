using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Bank.Domain
{
    public class ContaBancaria
    {
        public string NumeroConta{ get; private set; }
        public string Agencia { get; private set; }
        public decimal Saldo { get; private set; }

        public ContaBancaria(string numeroConta, string agencia)
        {
            if (string.IsNullOrWhiteSpace(numeroConta))
                throw new ArgumentException("O número da conta não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(agencia))
                throw new ArgumentException("A agência não pode ser vazia.");

            NumeroConta = numeroConta;
            Agencia = agencia;
            Saldo = 0;
        }
    }
}