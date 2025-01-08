using System.Diagnostics;
using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Repositories;

namespace KpblcCadInfrastructure.CAD.NET.Infrastructure
{
    internal class CadAssemblyInfoRepository : AssemblyInfoRepository
    {
        public override IEnumerable<AssemblyInfo> Get()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Select(o =>
                {
                    var version = FileVersionInfo.GetVersionInfo(o.Location).FileVersion;
                    if (Version.TryParse(version, out Version ver))
                    {
                        return new AssemblyInfo(o.Location, ver);
                    }

                    return new AssemblyInfo(o.Location, new Version(0, 0, 0, 0));
                });
        }
    }
}
