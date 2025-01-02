using System;
using System.Reflection;

namespace KpblcCadInfrastructure.Abstractions.Entities
{
    public class AssemblyInfo
    {
        public AssemblyInfo(Assembly Assembly)
        {
            this.Assembly = Assembly;
            this.Location = Assembly.Location;
            this.Version = Assembly.GetName(false).Version;
        }

        public string Location { get; set; }
        public Version Version { get; set; }
        public Assembly Assembly { get; }
    }
}
