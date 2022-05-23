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
    public class MonsterLogic : IMonsterLogic
    {
        IRepository<Monster> repo;

        public MonsterLogic(IRepository<Monster> repo)
        {
            this.repo = repo;
        }

        public void Create(Monster item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Monster Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Monster> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Monster item)
        {
            this.repo.Update(item);
        }
    }
}
