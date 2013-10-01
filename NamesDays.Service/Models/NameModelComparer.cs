namespace NamesDays.Service.Models
{
    using System;
    using System.Collections.Generic;

    public class NameModelComparer : IEqualityComparer<NameModel>
    {
        public bool Equals(NameModel x, NameModel y)
        {
            return x.Name.ToLower() == y.Name.ToLower();
        }

        public int GetHashCode(NameModel nameModel)
        {
            int hashNameModelName = nameModel.Name == null ? 0 : nameModel.Name.GetHashCode();

            return hashNameModelName;
        }
    }
}