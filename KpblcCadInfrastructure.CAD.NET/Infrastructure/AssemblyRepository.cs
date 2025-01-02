using KpblcCadInfrastructure.Abstractions.Interfaces;
using System.Reflection;

namespace KpblcCadInfrastructure.CAD.NET.Infrastructure
{
    internal class AssemblyRepository : IAssemblyRepository
    {
        public IEnumerable<Assembly> Get()
        {
            return AppDomain.CurrentDomain.GetAssemblies().ToList();
        }
    }
}
