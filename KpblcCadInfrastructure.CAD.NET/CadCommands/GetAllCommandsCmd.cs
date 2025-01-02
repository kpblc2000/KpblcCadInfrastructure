using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Interfaces;
using KpblcCadInfrastructure.CAD.NET.Infrastructure;
using Teigha.Runtime;

namespace KpblcCadInfrastructure.CAD.NET.CadCommands
{
    public static class GetAllCommandsCmd
    {
        [CommandMethod("-get-all-commands")]
        public static void GetAllCommandsCommandLineMode()
        {
            IAssemblyRepository assemblyRepository = new AssemblyRepository();
            ICommandInfoRepository commandInfoRepository = new CommandInfoRepository();
            IMessageService messageService = new MessageService();
            foreach (CommandInfo info in commandInfoRepository.Get(assemblyRepository.Get()))
            {
                string message = info.GlobalName;
                if (!string.IsNullOrWhiteSpace(info.LocalizedName))
                {
                    message += $" {info.LocalizedName}";
                }

                if (!string.IsNullOrWhiteSpace(info.Desctiption))
                {
                    message += $" {info.Desctiption}";
                }

                if (info.Assembly != null)
                {
                    message += $" {info.Assembly.FullName}";
                }

                messageService.ConsoleMessage(message);
            }
        }
    }
}
