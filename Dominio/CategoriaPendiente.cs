﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CategoriaPendiente
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }
}
