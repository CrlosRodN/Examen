using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class CuentaManager : BaseManager
    {
        private CuentaCrudFactory crudCuenta;

        public CuentaManager()
        {
            crudCuenta = new CuentaCrudFactory();
        }

        public void Create(Cuenta cuenta)
        {
            try
            {
                var a = crudCuenta.Retrieve<Cuenta>(cuenta);

                if (a != null)
                {

                    throw new BussinessException(5);
                }
                crudCuenta.Create(cuenta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Cuenta> RetrieveAll()
        {
            return crudCuenta.RetrieveAll<Cuenta>();
        }

        public Cuenta RetrieveById(Cuenta cuenta)
        {
            Cuenta a = null;
            try
            {
                a = crudCuenta.Retrieve<Cuenta>(cuenta);
                if (a == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return a;
        }

        public void Update(Cuenta cuenta)
        {
            crudCuenta.Update(cuenta);
        }

        public void Delete(Cuenta cuenta)
        {
            crudCuenta.Delete(cuenta);
        }
    }
}
