using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherApp.Model;
using WitcherApp.Repository.Interfaces;

namespace WitcherApp.Logic.Classes
{
    public class HumanLogic : IHumanLogic
    {
        IRepository<Human> repo;

        public HumanLogic(IRepository<Human> repo)
        {
            this.repo = repo;
        }

        public void Create(Human item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Human Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Human> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Human item)
        {
            this.repo.Update(item);
        }
    }
}
