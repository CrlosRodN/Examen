using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Credito : BaseEntity
    {
        public string id { get; set; }
        public double monto { get; set; }
        public double tasa { get; set; }
        public string nombre { get; set; }
        public double cuota { get; set; }
        public DateTime fechaInicio { get; set; }
        public string estado { get; set; }
        public double saldo { get; set; }

        public Credito(){
        }

        public Credito(string[] arr)
        {
            if (arr != null && arr.Length >= 8)
            {
                id = arr[0];
                monto = Convert.ToDouble(arr[1]);
                tasa = Convert.ToDouble(arr[2]);
                nombre = arr[3];
                cuota = Convert.ToDouble(arr[4]);
                fechaInicio = DateTime.Parse(arr[5]);
                estado = arr[6];
                saldo = Convert.ToDouble(arr[7]);
            }
            else
            {
                throw new Exception("Favor ingrese todos los valores solicitados.");
            }
        }
    }
}
