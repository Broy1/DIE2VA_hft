using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherApp.Model;
using WitcherApp.Repository.Database;
using WitcherApp.Repository.GenericRepository;
using WitcherApp.Repository.Interfaces;

namespace WitcherApp.Repository.ModelRepositories
{
    public class WitcherRepository : Repository<Witcher>, IRepository<Witcher>
    {
        public WitcherRepository(WitcherDbContext ctx) : base(ctx)
        {
        }

        public override Witcher Read(int id)
        {
            return ctx.Witchers.FirstOrDefault(t => t.WitcherId == id);
        }

        public override void Update(Witcher item)
        {
            var old = Read(item.WitcherId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
