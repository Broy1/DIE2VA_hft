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
    public class HumanRepository : Repository<Human>, IRepository<Human>
    {
        public HumanRepository(WitcherDbContext ctx) : base(ctx)
        {
        }

        public override Human Read(int id)
        {
            return ctx.Humans.FirstOrDefault(t => t.HumanId == id);
        }

        public override void Update(Human item)
        {
            var old = Read(item.HumanId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
