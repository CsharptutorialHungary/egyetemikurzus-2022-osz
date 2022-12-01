using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Commands
{
    internal interface IWeatherCommand
    {
        string Name { get; }

        Task<bool> Execute();
    }
}
