using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSRCDT
{
    internal class MeatTypeLoader
    {
        public Dictionary<string, Meat> Meats { get; }

        public MeatTypeLoader()
        {
            Meats = new Dictionary<string, Meat>();
            Assembly asm = Assembly.GetAssembly(typeof(MeatTypeLoader));
            if (asm == null)
                throw new InvalidOperationException("Error: Assembly is null.");

            var types = asm.GetTypes()
                .Where(type => type.IsClass
                        && (type.IsSubclassOf(typeof(Meat)))
                        || (type == typeof(Meat))  // szukseges sor, mivel az IsSubclassOf() nem erzekeli magat a parent osztalyt
                        );

            try
            {
                foreach (var type in types)
                {
                    Console.WriteLine(type.Name);
                    if (Activator.CreateInstance(type) is Meat meat)
                    {
                        Meats.Add(meat.GetType().Name, meat);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
