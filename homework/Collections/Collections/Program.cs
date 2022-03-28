using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main()
        {
            List<Entity> list = new()
            {
                new Entity {Id = 1, ParentId = 0, Name = "Root entity"},
                new Entity {Id = 2, ParentId = 1, Name = "Child of 1 entity"},
                new Entity {Id = 3, ParentId = 1, Name = "Child of 1 entity"},
                new Entity {Id = 4, ParentId = 2, Name = "Child of 2 entity"},
                new Entity {Id = 5, ParentId = 4, Name = "Child of 4 entity"}
            };

            var dict = ConvertToDictionary(list);

            foreach (var x in dict)
            {
                string ids = string.Join(", ", x.Value.Select(v => v.Id));
                Console.WriteLine("Key = {0}, Value = List ( Entity ( Id = {1} ))", x.Key, ids);
            }
        }

        public static Dictionary<int, List<Entity>> ConvertToDictionary(List<Entity> list)
        {
            Dictionary<int, List<Entity>> dict = new();
            dict = list.GroupBy(x => x.ParentId).ToDictionary(x => x.Key, x => x.ToList());

            return dict;
        }

    }
}
