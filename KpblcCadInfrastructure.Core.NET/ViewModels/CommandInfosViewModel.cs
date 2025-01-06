using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Interfaces;
using KpblcCadInfrastructure.Abstractions.Repositories;
using KpblcCadInfrastructure.Abstractions.ViewModels.Base;

namespace KpblcCadInfrastructure.Core.NET.ViewModels
{
    public class CommandInfosViewModel : ViewModel
    {
        public CommandInfosViewModel(ICommandInfoRepository CommandInfoRepository)
        {
            _commandInfoRepository = CommandInfoRepository;
        }

        public bool ShowCustomCommands
        {
            get => _showCustomCommands;
            set
            {
                if (Set(ref _showCustomCommands, value))
                {
                    Refresh();
                }
            }
        }

        public List<CommandInfo> CommandInfosList
        {
            get => _commandInfosList;
            private set => Set(ref _commandInfosList, value);
        }

        private void Refresh()
        {
            if (ShowCustomCommands)
            {
                CommandInfosList = new List<CommandInfo>(_commandInfoRepository.Get());
            }
            else
            {
                CommandInfosList = new List<CommandInfo>(_commandInfoRepository.Get());
            }
        }

        private ICommandInfoRepository _commandInfoRepository;
        private bool _showCustomCommands;
        private List<CommandInfo> _commandInfosList;
    }
}
