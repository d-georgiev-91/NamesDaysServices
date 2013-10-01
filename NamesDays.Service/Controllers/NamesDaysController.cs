namespace NamesDays.Service.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Data;
    using Models;

    public class NamesDaysController : ApiController
    {
        private readonly IRepository<NamesDay> data;

        public NamesDaysController()
        {
            this.data = new EfRepository<NamesDay>(new NamesDaysEntities());
        }

        public NamesDaysController(IRepository<NamesDay> data)
        {
            this.data = data;
        }

        [HttpGet]
        [ActionName("all")]
        public HttpResponseMessage GetAll()
        {
            var namesDays = this.data.All().Select(NameDayModel.FromNameDay);

            return this.Request.CreateResponse(HttpStatusCode.OK, namesDays);
        }

        [HttpGet]
        public HttpResponseMessage GetByDate(int month, int day)
        {
            DateTime date;

            try
            {
                date = new DateTime(2000, month, day);
            }
            catch (ArgumentOutOfRangeException)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest,
                    string.Format("Invalid date {0}.{1}", month, day));
            }

            var namesDays = this.data.All()
                                .Select(NameDayModel.FromNameDay)
                                .Where(nd => nd.Date.Month == date.Month && nd.Date.Day == date.Day);

            return this.Request.CreateResponse(HttpStatusCode.OK, namesDays);
        }

        [HttpGet]
        public HttpResponseMessage GetByMonth(int month)
        {
            if (month < 1 || 12 < month)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid month " + month);
            }

            var namesDays = this.data.All()
                                .Select(NameDayModel.FromNameDay)
                                .Where(nd => nd.Date.Month == month);

            return this.Request.CreateResponse(HttpStatusCode.OK, namesDays);
        }

        [HttpGet]
        [ActionName("today")]
        public HttpResponseMessage GetTodays()
        {
            var today = DateTime.Today;

            var namesDays = this.data.All()
                                .Select(NameDayModel.FromNameDay)
                                .Where(nd => nd.Date.Month == today.Month && nd.Date.Day == today.Day);

            return this.Request.CreateResponse(HttpStatusCode.OK, namesDays);
        }
    }
}