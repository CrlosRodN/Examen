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
    public class DireccionController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new DireccionManager();
            apiResp.Data = mng.Retrieve();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new DireccionManager();
                var direccion = new Direccion()
                {
                    Id = id
                };

                direccion = mng.RetrieveById(direccion);
                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada con éxito.";
                apiResp.Data = direccion;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Direccion direccion)
        {

            try
            {
                var mng = new DireccionManager();
                mng.Create(direccion);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada con éxito.";
                apiResp.Data = direccion;

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Direccion direccion)
        {
            try
            {
                var mng = new DireccionManager();
                mng.Update(direccion);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada con éxito";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Direccion direccion)
        {
            try
            {
                var mng = new DireccionManager();

                mng.Delete(direccion);

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