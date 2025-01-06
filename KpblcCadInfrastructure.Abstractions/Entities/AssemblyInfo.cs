using System;
using System.Reflection;

namespace KpblcCadInfrastructure.Abstractions.Entities
{
    public class AssemblyInfo : IEquatable<AssemblyInfo>
    {
        public AssemblyInfo(string Location, Version Version)
        {
            this.Location = Location;
            this.Version = Version;
        }

        public string Location { get; set; }
        public Version Version { get; set; }
        public Assembly Assembly { get; }

        public bool Equals(AssemblyInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Location == other.Location && Equals(Version, other.Version) && Equals(Assembly, other.Assembly);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AssemblyInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Version != null ? Version.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Assembly != null ? Assembly.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
