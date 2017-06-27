using System;
using System.Collections.Generic;
using BS.MinhasLeituras.Domain.Entities;
using BS.MinhasLeituras.Domain.Interfaces.Services;
using BS.MinhasLeituras.Domain.Interfaces.Repository;

namespace BS.MinhasLeituras.Domain.Services
{
    public class LeituraService : ILeituraService
    {
        private readonly ILeituraRepository _leituraRepository;

        public LeituraService(ILeituraRepository leituraRepository)
        {
            _leituraRepository = leituraRepository;
        }

        public Leitura Adicionar(Leitura leitura)
        {
            CalcularDataFimLeitura(leitura);

            leitura.Status = "L";
            return _leituraRepository.Adicionar(leitura);
        }

        public Leitura Atualizar(Leitura leitura)
        {
            CalcularDataFimLeitura(leitura);
            leitura.Status = "L";
            return _leituraRepository.Atualizar(leitura);
        }

        public Leitura ObterPorId(Guid id)
        {
            return _leituraRepository.ObterPorId(id);
        }

        public IEnumerable<Leitura> ObterStatus(string Status)
        {
            return _leituraRepository.ObterStatus(Status);
        }

        public IEnumerable<Leitura> ObterTodos()
        {
            return _leituraRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _leituraRepository.Remover(id);
        }

        public void CalcularDataFimLeitura(Leitura leitura)
        {
            var _dataFimLeitura = leitura.DataInicioLeitura.AddDays(leitura.QuantidadePaginas / leitura.QuantidadePaginasMeta);
            leitura.DataFimLeitura = _dataFimLeitura;
        }

        public void Dispose()
        {
            _leituraRepository.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
