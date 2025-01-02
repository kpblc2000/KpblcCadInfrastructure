using KpblcCadInfrastructure.Abstractions.Interfaces;
using KpblcCadInfrastructure.Abstractions.ViewModels.Base;

namespace KpblcCadInfrastructure.Core.NET.ViewModels
{
    public class AssembliesViewModel : ViewModel
    {
        public AssembliesViewModel(IMessageService MessageService)
        {
            _messageService = MessageService;
            Title = "Показать сборки";
        }

        public bool ShowCustomAssemblies
        {
            get => _showCustomAssemblies;
            set
            {
                if (Set(ref _showCustomAssemblies, value))
                {
                    _messageService.InfoMessage("Показывать " +
                                                (_showCustomAssemblies ? "только пользовательские" : "все") +
                                                " сборки", nameof(ShowCustomAssemblies));
                }
            }
        }

        private IMessageService _messageService;
        private bool _showCustomAssemblies;
    }
}
