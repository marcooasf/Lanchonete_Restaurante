using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lanchonete_Restaurante
{
    internal class ItemCardapio
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal PrecoBase { get; private set; }
        public bool EstaDisponivel { get; private set; }

        public ItemCardapio(int id, string nome, string categoria, decimal precoBase)
        {
            if (precoBase <= 0)
                throw new ArgumentException("O preço base não pode ser igual a zero ou negativo.");
            this.Id = id;
            this.Nome = nome;
            this.Categoria = categoria;
            this.PrecoBase = precoBase;
            this.EstaDisponivel = true;
        }

        public void PausarVendas()
        {
            this.EstaDisponivel = false;
            return;
        }

        public void ReativarVendas()
        {
            this.EstaDisponivel = true;
            return;
        }

        public void AplicarDesconto(decimal porcentagem)
        {
            if (porcentagem <= 0 || porcentagem > 30)
            {
                throw new ArgumentException("O desconto informado não é aceito.");
            }
            else
            { 
                this.PrecoBase -= (this.PrecoBase * (porcentagem / 100));
            }
        }
        
        public void AlterarPrecoBase(decimal novoPreco)
        {
            if (novoPreco <= 0)
            {
                throw new ArgumentException("O preço base não pode ser igual a zero ou negativo.");
            }
            else
            {
                this.PrecoBase = novoPreco;
            }
        }
    }
}
