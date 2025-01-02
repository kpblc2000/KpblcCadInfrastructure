using System.Collections.Generic;
using System.Reflection;

namespace KpblcCadInfrastructure.Abstractions.Interfaces
{
    public interface IAssemblyRepository
    {
        /// <summary>
        /// Получение списка загруженных сборок
        /// </summary>
        /// <returns></returns>
        IEnumerable<Assembly> Get();
        /// <summary>
        /// Получение списка загруженных сборок, кроме тех, что из %ProgramFiles%
        /// </summary>
        /// <returns></returns>
        IEnumerable<Assembly> GetCustomAssemblies();
    }
}