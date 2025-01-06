using System;
using System.Reflection;

namespace KpblcCadInfrastructure.Abstractions.Entities
{
    public class AssemblyInfo
    {
        public AssemblyInfo(Assembly Assembly)
        {
            this.Assembly = Assembly;
            Location = Assembly.Location;
            Version = Assembly.GetName(false).Version;
        }

        public AssemblyInfo(string Location, Version Version)
        {
            this.Location = Location;
            this.Version = Version;
        }

        public string Location { get; set; }
        public Version Version { get; set; }
        public Assembly Assembly { get; }
    }
}
