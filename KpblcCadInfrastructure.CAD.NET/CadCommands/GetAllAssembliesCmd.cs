using KpblcCadInfrastructure.Abstractions.Interfaces;
using KpblcCadInfrastructure.CAD.NET.Infrastructure;
using System.Reflection;
using Teigha.Runtime;
using Exception = System.Exception;

namespace KpblcCadInfrastructure.CAD.NET.CadCommands
{
    public static class GetAllAssembliesCmd
    {
        [CommandMethod("-get-all-assemblies")]
        public static void GetAllAssembliesCommandLineMode()
        {
            IAssemblyRepository rep = new AssemblyRepository();
            IMessageService messageService = new MessageService();
            try
            {
                foreach (Assembly assembly in rep.Get().OrderBy(o => o.GetName(false).Name))
                {
                    messageService.ConsoleMessage(assembly.FullName);
                }
            }
            catch (Exception ex)
            {
                messageService.ExceptionMessage(ex);
            }
        }
    }
}
