using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherApp.Model;

namespace WitcherApp.Logic.Interfaces
{
    public interface IMonsterLogic
    {
        void Create(Monster item);
        void Delete(int id);
        Monster Read(int id);
        IQueryable<Monster> ReadAll();
        void Update(Monster item);
    }
}
