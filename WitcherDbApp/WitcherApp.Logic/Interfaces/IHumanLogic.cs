using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherApp.Model;

namespace WitcherApp.Logic.Classes
{
    public interface IHumanLogic
    {
        void Create(Human item);
        void Delete(int id);
        Human Read(int id);
        IQueryable<Human> ReadAll();
        void Update(Human item);
    }
}
