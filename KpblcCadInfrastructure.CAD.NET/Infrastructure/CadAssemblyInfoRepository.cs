using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Repositories;

namespace KpblcCadInfrastructure.CAD.NET.Infrastructure
{
    internal class CadAssemblyInfoRepository : AssemblyInfoRepository
    {
        public IEnumerable<AssemblyInfo> Get()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Select(o => new AssemblyInfo(o));
        }
    }
}
