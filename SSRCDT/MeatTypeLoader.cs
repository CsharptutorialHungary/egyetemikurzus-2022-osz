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
        public List<string> Meats { get; }

        public MeatTypeLoader()
        {
            Meats = new List<string>();
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
                        Meats.Add(type.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
