using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Interfaces;
using KpblcCadInfrastructure.CAD.NET.Infrastructure;
using KpblcCadInfrastructure.Core.NET.Views.Windows;
using Teigha.Runtime;
using Application = HostMgd.ApplicationServices.Application;

namespace KpblcCadInfrastructure.CAD.NET.CadCommands
{
    public static class GetAllCommandsCmd
    {
        [CommandMethod("-get-all-commands")]
        public static void GetAllCommandsCommandLineMode()
        {
            IAssemblyInfoRepository assemblyRepository = new AssemblyRepository();
            ICommandInfoRepository commandInfoRepository = new CommandInfoRepository();
            IMessageService messageService = new MessageService();
            foreach (CommandInfo info in commandInfoRepository.Get(assemblyRepository.Get().Select(o => o.Assembly)))
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

        [CommandMethod("get-all-commands")]
        public static void GetAllCommandsDialogMode()
        {
            CommandsWindow win = new CommandsWindow();
            Application.ShowModalWindow(win);
        }
    }
}
