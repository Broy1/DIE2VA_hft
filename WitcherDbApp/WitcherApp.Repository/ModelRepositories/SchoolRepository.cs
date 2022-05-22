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
    public class SchoolRepository : Repository<School>, IRepository<School>
    {
        public SchoolRepository(WitcherDbContext ctx) : base(ctx)
        {
        }

        public override School Read(int id)
        {
            return ctx.Schools.FirstOrDefault(t => t.SchoolId == id);
        }

        public override void Update(School item)
        {
            var old = Read(item.SchoolId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
