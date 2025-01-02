using System.Collections.Generic;
using System.Reflection;
using KpblcCadInfrastructure.Abstractions.Entities;

namespace KpblcCadInfrastructure.Abstractions.Interfaces
{
    public interface IAssemblyInfoRepository
    {
        /// <summary>
        /// Получение списка загруженных сборок
        /// </summary>
        /// <returns></returns>
        IEnumerable<AssemblyInfo> Get();
        /// <summary>
        /// Получение списка загруженных сборок, кроме тех, что из %ProgramFiles%
        /// </summary>
        /// <returns></returns>
        IEnumerable<AssemblyInfo> GetCustomAssemblies();
    }
}