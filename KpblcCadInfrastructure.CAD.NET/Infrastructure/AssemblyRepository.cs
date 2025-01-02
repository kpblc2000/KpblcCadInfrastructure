using KpblcCadInfrastructure.Abstractions.Interfaces;
using System.Reflection;
using KpblcCadInfrastructure.Abstractions.Entities;

namespace KpblcCadInfrastructure.CAD.NET.Infrastructure
{
    internal class AssemblyRepository : IAssemblyInfoRepository
    {
        public IEnumerable<AssemblyInfo> Get()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Select(o => new AssemblyInfo(o));
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
