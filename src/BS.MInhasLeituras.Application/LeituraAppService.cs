using System;
using System.Collections.Generic;
using BS.MinhasLeituras.Application.Interfaces;
using BS.MinhasLeituras.Application.ViewModels;
using BS.MinhasLeituras.Domain.Interfaces.Services;
using BS.MinhasLeituras.Infra.Data.Interfaces;
using AutoMapper;
using BS.MinhasLeituras.Domain.Entities;

namespace BS.MinhasLeituras.Application
{
    public class LeituraAppService : AppService, ILeituraAppService
    {
        private readonly ILeituraService _leituraService;

        public LeituraAppService(ILeituraService leituraService, IUnitOfwork uow)
            : base(uow)
        {
            _leituraService = leituraService;
        }
        public LeituraViewModel Adicionar(LeituraViewModel leituraViewModel)
        {
            var leitura = Mapper.Map<LeituraViewModel, Leitura>(leituraViewModel);

            BeginTransaction();
            var leituraReturn = _leituraService.Adicionar(leitura);
            leituraViewModel = Mapper.Map<Leitura, LeituraViewModel>(leituraReturn);

            Commit();

            return leituraViewModel;
        }

        public LeituraViewModel Atualizar(LeituraViewModel leituraViewModel)
        {
            //_leituraService.Atualizar(Mapper.Map<LeituraViewModel, Leitura>(leituraViewModel));
            //return leituraViewModel;
            var leitura = Mapper.Map<LeituraViewModel, Leitura>(leituraViewModel);

            BeginTransaction();
            var leituraReturn = _leituraService.Atualizar(leitura);
            leituraViewModel = Mapper.Map<Leitura, LeituraViewModel>(leituraReturn);

            Commit();

            return leituraViewModel;
        }
        
        public LeituraViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Leitura, LeituraViewModel>(_leituraService.ObterPorId(id));
        }

        public IEnumerable<LeituraViewModel> ObterStatus(string Status)
        {
            return Mapper.Map<IEnumerable<Leitura>, IEnumerable<LeituraViewModel>>(_leituraService.ObterStatus(Status));
        }

        public IEnumerable<LeituraViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Leitura>, IEnumerable<LeituraViewModel>>(_leituraService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _leituraService.Remover(id);
        }

        public void Dispose()
        {
            _leituraService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
