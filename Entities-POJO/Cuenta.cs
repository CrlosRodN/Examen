using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Cuenta : BaseEntity
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public DateTime fechaApert { get; set; }
        public double saldo { get; set; }

        public Cuenta(){
        }

        public Cuenta(string[] arr)
        {
            if (arr != null && arr.Length >= 6)
            {
                id = arr[0];
                nombre = arr[1];
                tipo = arr[2];
                fechaApert = DateTime.Parse(arr[3]);
                saldo = Convert.ToDouble(arr[4]);
            }
            else
            {
                throw new Exception("Favor ingresar todos los datos solicitados.");
            }

        }
    }
}
