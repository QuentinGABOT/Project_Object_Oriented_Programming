﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROBLEME_FINAL
{
    class Equipe : Competition
    {
        public Equipe(Club c) : base(c)
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
