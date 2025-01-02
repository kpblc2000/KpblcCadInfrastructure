using KpblcCadInfrastructure.Abstractions.Entities;
using System.Collections.Generic;
using System.Reflection;

namespace KpblcCadInfrastructure.Abstractions.Interfaces
{
    public interface ICommandInfoRepository
    {
        /// <summary>
        /// Получение перечня команд
        /// </summary>
        /// <param name="Assemblies">Перечень сборок, которые надо "проходить" на предмет описаний команд</param>
        /// <returns></returns>
        IEnumerable<CommandInfo> Get(IEnumerable<Assembly> Assemblies);
    }
}