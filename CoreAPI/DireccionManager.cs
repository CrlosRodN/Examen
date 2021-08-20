using DataAcess.Crud;
using Entities_POJO;
using System;
using Exceptions;
using System.Collections.Generic;

namespace CoreAPI
{
    public class DireccionManager : BaseManager
    {
        private DireccionCrudFactory crudDireccion;

        public DireccionManager()
        {
            crudDireccion = new DireccionCrudFactory();
        }

        public void Create(Direccion direccion)
        {
            try
            {
                var a = crudDireccion.Retrieve<Direccion>(direccion);

                if (a != null)
                {
                    throw new BussinessException(6);
                }

                crudDireccion.Create(direccion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Direccion> Retrieve()
        {
            return crudDireccion.RetrieveAll<Direccion>();
        }

        public Direccion RetrieveById(Direccion direccion)
        {
            Direccion a = null;
            try
            {
                a = crudDireccion.Retrieve<Direccion>(direccion);
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

        public void Update(Direccion direccion)
        {
            crudDireccion.Update(direccion);
        }

        public void Delete(Direccion direccion)
        {
            crudDireccion.Delete(direccion);
        }
    }
}
