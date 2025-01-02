using HostMgd.ApplicationServices;
using HostMgd.EditorInput;
using KpblcCadInfrastructure.Abstractions.Interfaces;
using System.Runtime.CompilerServices;
using Application = HostMgd.ApplicationServices.Application;

namespace KpblcCadInfrastructure.CAD.NET.Infrastructure
{
    internal class MessageService : IMessageService
    {
        public MessageService()
        {
            Version _version = typeof(MessageService).Assembly.GetName().Version;
            _title = "Kpblc.CAD.NET v." + _version + " : ";
        }

        public void ConsoleMessage(string Message, [CallerMemberName] string? CallerName = null)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null)
            {
                InfoMessage(Message, CallerName);
            }

            Editor ed = doc.Editor;
            ed.WriteMessage("\n" + Message);
        }

        public void InfoMessage(string Message, [CallerMemberName] string? CallerName = null)
        {
            MessageBox.Show((string.IsNullOrWhiteSpace(CallerName) ? "" : $"{CallerName} : ") + Message,
                _title + "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ErrorMessage(string Message, [CallerMemberName] string? CallerName = null)
        {
            MessageBox.Show((string.IsNullOrWhiteSpace(CallerName) ? "" : $"{CallerName} : ") + Message,
                _title + "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ExceptionMessage(Exception Ex, [CallerMemberName] string? CallerName = null)
        {
            MessageBox.Show(
                (string.IsNullOrWhiteSpace(CallerName) ? "" : $"{CallerName} : ") + "\n" + Ex.Message + "\n" +
                Ex.StackTrace, _title + "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string _title;
    }
}