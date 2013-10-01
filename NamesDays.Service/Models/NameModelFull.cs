namespace NamesDays.Service.Models
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using NamesDays.Data;

    [DataContract]
    public class NameModelFull : NameModel
    {
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "nameDayTitle")]
        public string NameDayTitle { get; set; }

        public static Expression<Func<Name, NameModelFull>> FromName
        {
            get
            {
                return name => new NameModelFull()
                {
                    Name = name.Name1,
                    NameDayTitle = name.NamesDay.Title,
                    Date = name.NamesDay.NameDayDate,
                };
            }
        }
    }
}