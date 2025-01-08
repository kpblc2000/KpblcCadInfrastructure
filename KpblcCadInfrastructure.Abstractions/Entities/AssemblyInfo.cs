using System;
using System.Reflection;

namespace KpblcCadInfrastructure.Abstractions.Entities
{
    /// <summary>
    /// Информация о загруженной в nanoCAD сборке
    /// </summary>
    public class AssemblyInfo
    {
        public AssemblyInfo(Assembly Assembly)
        {
            this.Assembly = Assembly;
            this.Location = Assembly.Location;
            this.Version = Assembly.GetName(false).Version;
        }

        public AssemblyInfo(string Location, Version Version)
        {
            this.Location = Location;
            this.Version = Version;
        }

        /// <summary>
        /// Расположение сборки
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Версия сборки
        /// </summary>
        public Version Version { get; set; }
        public Assembly Assembly { get; }
    }
}
