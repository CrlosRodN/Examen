using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class CreditoManager : BaseManager
    {
        private CreditoCrudFactory crudCredito;

        public CreditoManager()
        {
            crudCredito = new CreditoCrudFactory();
        }

        public void Create(Credito credito)
        {
            try
            {
                var c = crudCredito.Retrieve<Credito>(credito);

                if (c != null)
                {
                    throw new BussinessException(7);
                }
                crudCredito.Create(credito);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Credito> Retrieve()
        {
            return crudCredito.RetrieveAll<Credito>();
        }

        public Credito RetrieveById(Credito credito)
        {
            Credito c = null;
            try
            {
                c = crudCredito.Retrieve<Credito>(credito);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Credito credito)
        {
            crudCredito.Update(credito);
        }

        public void Delete(Credito credito)
        {
            crudCredito.Delete(credito);
        }
    }
}
