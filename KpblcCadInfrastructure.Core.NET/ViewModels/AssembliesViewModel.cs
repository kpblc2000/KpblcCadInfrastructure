using System.Reflection;
using KpblcCadInfrastructure.Abstractions.Interfaces;
using KpblcCadInfrastructure.Abstractions.ViewModels.Base;

namespace KpblcCadInfrastructure.Core.NET.ViewModels
{
    public class AssembliesViewModel : ViewModel
    {
        public AssembliesViewModel(IAssemblyRepository AssemblyRepository)
        {
            _assemblyRepository = AssemblyRepository;
            Title = "Показать сборки";
            Refresh();
        }

        public bool ShowCustomAssemblies
        {
            get => _showCustomAssemblies;
            set
            {
                if (Set(ref _showCustomAssemblies, value))
                {
                    Refresh();
                }
            }
        }

        public List<Assembly> AssembliesList
        {
            get => _assembliesList;
            private set => Set(ref _assembliesList, value);
        }

        private void Refresh()
        {
            if (ShowCustomAssemblies)
            {
                AssembliesList = _assemblyRepository.GetCustomAssemblies().ToList();
            }
            else
            {
                AssembliesList = _assemblyRepository.Get().ToList();
            }
        }

        private IAssemblyRepository _assemblyRepository;
        private bool _showCustomAssemblies;
        private List<Assembly> _assembliesList;
    }
}
