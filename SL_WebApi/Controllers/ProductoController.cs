using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        //nombre api
        [Route("api/Producto/GetAll")]
        //codigos de error HTTP 
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


        //nombre api
        [Route("api/Producto/GetById")]
        //codigos de error HTTP 
        [HttpGet]
        public IHttpActionResult GetById([FromUri] int IdProducto)
        {
            ML.Result result = BL.Producto.GetById(IdProducto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        //nombre api
        [Route("api/Producto/Add")]
        //codigos de error HTTP 
        [HttpPost]
        public IHttpActionResult Add([FromBody]ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        //nombre api
        [Route("api/Producto/Update")]
        //codigos de error HTTP 
        [HttpPut]
        public IHttpActionResult Update([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.Update(producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        //nombre api
        [Route("api/Producto/Delete")]
        //codigos de error HTTP 
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int IdProducto)
        {
            ML.Result result = BL.Producto.Delete(IdProducto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


        


    }
}
