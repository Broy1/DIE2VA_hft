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
    public class MovieLogic : IWitcherLogic
    {
        IRepository<Witcher> repo;

        public MovieLogic(IRepository<Witcher> repo)
        {
            this.repo = repo;
        }

        public void Create(Witcher item)
        {
            if (item.Name.Length < 2)
            {
                throw new ArgumentException("Name is too short!");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Witcher Read(int id)
        {
            var witcher = this.repo.Read(id);
            if (witcher == null)
            {
                throw new ArgumentException("Witcher does not exists!");
            }
            return witcher;

        }

        public IQueryable<Witcher> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Witcher item)
        {
            this.repo.Update(item);
        }

        public double? GetAvarageBountyPerSchool(string school)
        {
            var selectedWitchers = this.repo
               .ReadAll()
               .Where(t => t.School.ToString() == school);


            double avg = (selectedWitchers as Witcher).HuntedMonsters
                .Average(m => m.Bounty);

            return avg;
        }
    }
}
