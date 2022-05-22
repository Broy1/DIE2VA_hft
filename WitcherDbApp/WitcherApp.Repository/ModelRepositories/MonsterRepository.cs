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
    public class MonsterRepository : Repository<Monster>, IRepository<Monster>
    {
        public MonsterRepository(WitcherDbContext ctx) : base(ctx)
        {
        }

        public override Monster Read(int id)
        {
            return ctx.Monsters.FirstOrDefault(t => t.MonsterId == id);
        }

        public override void Update(Monster item)
        {
            var old = Read(item.MonsterId);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
