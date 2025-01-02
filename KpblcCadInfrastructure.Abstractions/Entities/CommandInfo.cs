using System.Reflection;

namespace KpblcCadInfrastructure.Abstractions.Entities
{
    public class CommandInfo
    {
        /// <summary>
        /// Глобальное имя команды
        /// </summary>
        public string GlobalName { get; set; }
        /// <summary>
        /// Локализованное имя команды. М.б. пустым
        /// </summary>
        public string LocalizedName { get; set; }
        /// <summary>
        /// Описание команды. М.б. пустым
        /// </summary>
        public string Desctiption { get; set; }
        /// <summary>
        /// Сборка, из которой загружается команда
        /// </summary>
        public Assembly Assembly { get; set; }
    }
}