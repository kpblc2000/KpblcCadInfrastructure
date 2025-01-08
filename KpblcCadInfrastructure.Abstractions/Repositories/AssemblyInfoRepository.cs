using System;
using System.Collections.Generic;
using System.Linq;
using KpblcCadInfrastructure.Abstractions.Entities;

namespace KpblcCadInfrastructure.Abstractions.Repositories
{
    public abstract class AssemblyInfoRepository
    {
        public abstract IEnumerable<AssemblyInfo> Get();

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
