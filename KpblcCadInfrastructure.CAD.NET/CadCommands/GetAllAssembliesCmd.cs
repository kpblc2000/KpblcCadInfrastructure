using HostMgd.ApplicationServices;
using HostMgd.EditorInput;
using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Interfaces;
using KpblcCadInfrastructure.Abstractions.Repositories;
using KpblcCadInfrastructure.CAD.NET.Infrastructure;
using KpblcCadInfrastructure.Core.NET.ViewModels;
using KpblcCadInfrastructure.Core.NET.Views.Windows;
using Teigha.Runtime;
using Application = HostMgd.ApplicationServices.Application;
using Exception = System.Exception;

namespace KpblcCadInfrastructure.CAD.NET.CadCommands
{
    public static class GetAllAssembliesCmd
    {
        [CommandMethod("-get-all-assemblies")]
        public static void GetAllAssembliesCommandLineMode()
        {

            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null)
            {
                return;
            }

            PromptKeywordOptions options = new PromptKeywordOptions("\nВыводить полный список [Да/Нет] <Да> : ");
            options.Keywords.Add("Да");
            options.Keywords.Add("Yes");
            options.Keywords.Add("Нет");
            options.Keywords.Add("No");
            options.AllowNone = true;
            options.AllowArbitraryInput = false;

            PromptResult res = doc.Editor.GetKeywords(options);

            if (res.Status == PromptStatus.Cancel)
            {
                return;
            }

            if (res.Status == PromptStatus.None)
            {
                res.StringResult = "Y";
            }

            bool showAllAssemblies = res.StringResult.StartsWith("Y") || res.StringResult.StartsWith("Д");

            AssemblyInfoRepository rep = new CadAssemblyInfoRepository();
            AssemblyInfosViewModel vm = new AssemblyInfosViewModel(rep)
            {
                ShowCustomAssemblies = showAllAssemblies,
            };

            IMessageService messageService = new MessageService();
            try
            {
                foreach (AssemblyInfo assembly in vm.AssembliesList.OrderBy(o => o.Location))
                {
                    messageService.ConsoleMessage(assembly.Location);
                }
            }
            catch (Exception ex)
            {
                messageService.ExceptionMessage(ex);
            }
        }

        [CommandMethod("get-all-assemblies")]
        public static void GetAllAssembliesDialogMode()
        {
            AssemblyInfoRepository assemblyRepository = new CadAssemblyInfoRepository();
            AssemblyInfosViewModel vm = new AssemblyInfosViewModel(assemblyRepository);
            AssembliesWindow win = new AssembliesWindow()
            {
                DataContext = vm,
            };
            Application.ShowModalWindow(win);
        }
    }
}
