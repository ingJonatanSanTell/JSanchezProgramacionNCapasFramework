﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Colonia
    {
        public int IdColonia { get; set; }
        public String Nombre { get; set; }
        public String CodigoPostal { get; set; }
        public ML.Municipio Municipio { get; set; }
    }
}
