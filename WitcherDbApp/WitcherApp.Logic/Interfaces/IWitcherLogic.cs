using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherApp.Model;

namespace WitcherApp.Logic.Interfaces
{
    public interface IWitcherLogic
    {
        void Create(Witcher item);
        void Delete(int id);
        double? GetAvarageBountyPerSchool(string school);
        Witcher Read(int id);
        IQueryable<Witcher> ReadAll();
        void Update(Witcher item);
    }
}
