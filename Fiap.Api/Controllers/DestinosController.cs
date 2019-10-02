using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Api.Custom;
using Fiap.Core.Context;
using Fiap.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    //[CustomAuthorize]
    [Authorize]
    [EnableCors("default")]
    public class DestinosController : ControllerBase
    {
        private TurismoContext _turismoContext;

        public DestinosController(TurismoContext context)
        {
            _turismoContext = context;
        }

        //[HttpGet]
        //public List<Destino> List()
        //{

        //    return _turismoContext.Destinos.ToList();
        //}


        //[HttpGet]
        //[ProducesResponseType(200, Type= typeof(List<Destino>))]
        //[ProducesResponseType(404)]
        //public IActionResult List()
        //{

        //    return new CreatedResult("teste", _turismoContext.Destinos.ToList());
        //}


        [HttpGet]
        public ActionResult<List<Destino>> List()
        {

            var teste = User.Identity.Name;
            return new OkObjectResult(_turismoContext.Destinos.ToList());
        }

        [HttpPost]
        public ActionResult<Destino> Create(Destino destino)
        {
            if (ModelState.IsValid)
            {

                _turismoContext.Destinos.Add(destino);
                _turismoContext.SaveChanges();


                return new CreatedResult($"/api/destinos/{destino.Id}", destino);
            }
            return BadRequest(ModelState);
        }

    }
}