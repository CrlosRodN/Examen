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
    public class CuentaController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new CuentaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new CuentaManager();
                var cuenta = new Cuenta
                {
                    Id = id
                };

                cuenta = mng.RetrieveById(cuenta);
                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada con éxito.";
                apiResp.Data = cuenta;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Cuenta cuenta)
        {

            try
            {
                var mng = new CuentaManager();
                mng.Create(cuenta);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada con éxito.";
                apiResp.Data = cuenta;

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Cuenta cuenta)
        {
            try
            {
                var mng = new CuentaManager();
                mng.Update(cuenta);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Cuenta cuenta)
        {
            try
            {
                var mng = new CuentaManager();
                mng.Delete(cuenta);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
