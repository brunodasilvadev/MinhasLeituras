using BS.MinhasLeituras.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BS.MinhasLeituras.Domain.Interfaces.Repository
{
    public interface ILeituraRepository : IRepository<Leitura>
    {
        IEnumerable<Leitura> ObterStatus(string Status);
    }
}