using ConsoleTools;
using WitcherApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace WitcherApp.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Monster")
            {
                Console.Write("Enter Monster Name: ");
                string name = Console.ReadLine();
                rest.Post(new Monster() { Name = name }, "monster");
            }
        }
        static void List(string entity)
        {
            if (entity == "Monster")
            {
                List<Monster> monsters = rest.Get<Monster>("monster");
                foreach (var item in monsters)
                {
                    Console.WriteLine(item.MonsterId + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Monster")
            {
                Console.Write("Enter Monster's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Monster one = rest.Get<Monster>(id, "monster");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "monster");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Monster")
            {
                Console.Write("Enter Monster's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "monster");
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:53900/", "witcher");

            var monsterSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Monster"))
                .Add("Create", () => Create("Monster"))
                .Add("Delete", () => Delete("Monster"))
                .Add("Update", () => Update("Monster"))
                .Add("Exit", ConsoleMenu.Close);

            var humanSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Human"))
                .Add("Create", () => Create("Human"))
                .Add("Delete", () => Delete("Human"))
                .Add("Update", () => Update("Human"))
                .Add("Exit", ConsoleMenu.Close);

            var schoolSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("School"))
                .Add("Create", () => Create("School"))
                .Add("Delete", () => Delete("School"))
                .Add("Update", () => Update("School"))
                .Add("Exit", ConsoleMenu.Close);

            var witcherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Witcher"))
                .Add("Create", () => Create("Witcher"))
                .Add("Delete", () => Delete("Witcher"))
                .Add("Update", () => Update("Witcher"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Witchers", () => witcherSubMenu.Show())
                .Add("Monsters", () => monsterSubMenu.Show())
                .Add("Humans", () => humanSubMenu.Show())
                .Add("Schools", () => schoolSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
