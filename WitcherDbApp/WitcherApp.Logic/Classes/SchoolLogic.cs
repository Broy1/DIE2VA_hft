using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherApp.Logic.Interfaces;
using WitcherApp.Model;
using WitcherApp.Repository.Interfaces;

namespace WitcherApp.Logic.Classes
{
    public class SchoolLogic : ISchoolLogic
    {
        IRepository<School> repo;

        public SchoolLogic(IRepository<School> repo)
        {
            this.repo = repo;
        }

        public void Create(School item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public School Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<School> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(School item)
        {
            this.repo.Update(item);
        }
    }
}
