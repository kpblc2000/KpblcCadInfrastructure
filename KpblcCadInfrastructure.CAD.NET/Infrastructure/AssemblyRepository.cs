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

        public IEnumerable<Assembly> GetCustomAssemblies()
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
