using BS.MinhasLeituras.Domain.Entities;
using BS.MinhasLeituras.Domain.Interfaces.Repository;
using BS.MinhasLeituras.Infra.Data.Context;
using Dapper;
using System.Collections.Generic;

namespace BS.MinhasLeituras.Infra.Data.Repository
{
    public class LeituraRepository : Repository<Leitura>, ILeituraRepository
    {
        public LeituraRepository(MinhasLeiturasContext context)
        : base(context)
        {

        }

        public IEnumerable<Leitura> ObterStatus(string Status)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM LEITURAS L" +
                " WHERE L.STATUS = @sStatus";

            return cn.Query<Leitura>(sql);
        }

        public override IEnumerable<Leitura> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM LEITURAS";

            return cn.Query<Leitura>(sql);
        }
    }
}
