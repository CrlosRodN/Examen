using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Direccion : BaseEntity
    {
        public string id { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string sennas { get; set; }
        public string tipo { get; set; }

        public Direccion() {
        }

        public Direccion(string[] arr)
        {
            if (arr != null && arr.Length >= 6)
            {
                id = arr[0];
                provincia = arr[1];
                canton = arr[2];
                distrito = arr[3];
                sennas = arr[4];
                tipo = arr[5];
            }
            else
            {
                throw new Exception("Favor ingresar todos los valores solicitados.");
            }

        }
    }
}
