using KpblcCadInfrastructure.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KpblcCadInfrastructure.Abstractions.Repositories
{
    public abstract class AssemblyInfoRepository 
    {
        public virtual IEnumerable<AssemblyInfo> Get()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Select(o => new AssemblyInfo(o.Location, Version.Parse(o.ImageRuntimeVersion)));
        }

        public IEnumerable<AssemblyInfo> GetCustomAssemblies()
        {
            string programFiles = Environment.GetEnvironmentVariable("programfiles").ToUpper();
            return Get().Where(o =>
            {
                try
                {
                    return !o.Location.ToUpper().StartsWith(programFiles);
                }
                catch
                {
                    return true;
                }
            });
        }
    }
}
