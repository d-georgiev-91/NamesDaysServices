using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NamesDays.Data;

namespace NamesDays.Service.Models
{
    public class NamesController : ApiController
    {
        private readonly IRepository<Name> data;

        public NamesController()
        {
            this.data = new EfRepository<Name>(new NamesDaysEntities());
        }

        public NamesController(IRepository<Name> data)
        {
            this.data = data;
        }

        [HttpGet]
        public HttpResponseMessage GetNameDetails(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Name should not be empty");    
            }

            var nameDetail = this.data.All()
                                 .Select(NameModelFull.FromName)
                                 .Where(n => n.Name.ToLower() == name.Trim().ToLower());

            return this.Request.CreateResponse(HttpStatusCode.OK, nameDetail);
        }
    }
}