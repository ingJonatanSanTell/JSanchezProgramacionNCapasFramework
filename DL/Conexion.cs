using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    static public class Conexion
    {
        static public String Get()
        {
            String Conexion = "Data Source=.;Initial Catalog=JSanchezProgramacionNCapas;Persist Security Info=True;User ID=sa;Password=pass@word1";
            return Conexion;
        }
    }
}
