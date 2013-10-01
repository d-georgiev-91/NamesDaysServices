namespace NamesDays.Service.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using NamesDays.Data;

    [DataContract]
    public class NameModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        public int DayId { get; set; }

        public static Expression<Func<Name, NameModel>> FromName
        {
            get
            {
                return name => new NameModel()
                {
                    Name = name.Name1,
                    DayId = name.DayId
                };
            }
        }
    }
}