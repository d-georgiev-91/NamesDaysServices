namespace NamesDays.Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using NamesDays.Data;

    [DataContract]
    public class NameDayModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "Names")]
        public IEnumerable<NameModel> Names { get; set; }

        public static Expression<Func<NamesDay, NameDayModel>> FromNameDay
        {
            get
            {
                return nameDay => new NameDayModel()
                {
                    Title = nameDay.Title,
                    Date = nameDay.NameDayDate,
                    Names = nameDay.Names
                                   .AsQueryable()
                                   .Select(NameModel.FromName)
                                   .Where(n => n.DayId == nameDay.NameDayId)
                };
            }
        }
    }
}