using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class CreditoController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new CreditoManager();
            apiResp.Data = mng.Retrieve();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new CreditoManager();
                var credito = new Credito
                {
                    Id = id
                };

                credito = mng.RetrieveById(credito);
                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";
                apiResp.Data = credito;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Credito credito)
        {

            try
            {
                var mng = new CreditoManager();
                mng.Create(credito);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Credito credito)
        {
            try
            {
                var mng = new CreditoManager();
                mng.Update(credito);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Credito credito)
        {
            try
            {
                var mng = new CreditoManager();
                mng.Delete(credito);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada con éxito";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}