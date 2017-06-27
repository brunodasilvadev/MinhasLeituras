using BS.MinhasLeituras.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BS.MinhasLeituras.Domain.Interfaces.Services
{
    public interface ILeituraService : IDisposable
    {
        Leitura Adicionar(Leitura leitura);

        Leitura ObterPorId(Guid id);

        IEnumerable<Leitura> ObterTodos();

        Leitura Atualizar(Leitura leitura);

        void Remover(Guid id);

        IEnumerable<Leitura> ObterStatus(string Status);

        void CalcularDataFimLeitura(Leitura leitura);
    }
}
