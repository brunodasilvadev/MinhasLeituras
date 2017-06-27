using BS.MinhasLeituras.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BS.MinhasLeituras.Application.Interfaces
{
    public interface ILeituraAppService : IDisposable
    {
        LeituraViewModel Adicionar(LeituraViewModel obj);

        LeituraViewModel ObterPorId(Guid id);

        IEnumerable<LeituraViewModel> ObterTodos();

        LeituraViewModel Atualizar(LeituraViewModel obj);

        void Remover(Guid id);

        IEnumerable<LeituraViewModel> ObterStatus(string Status);
    }
}
