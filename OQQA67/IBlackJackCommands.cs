﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQQA67
{
    internal interface IBlackJackCommands
    {
        public string Name { get; }
        public void Execute(Player player);
    }
}