using System.Collections.ObjectModel;
using System.Reflection;
using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Interfaces;
using KpblcCadInfrastructure.Abstractions.ViewModels.Base;

namespace KpblcCadInfrastructure.Core.NET.ViewModels
{
    public class AssembliesViewModel : ViewModel
    {
        public AssembliesViewModel(IAssemblyInfoRepository AssemblyRepository)
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

        public List<AssemblyInfo> AssembliesList
        {
            get => _assembliesList;
            private set => Set(ref _assembliesList, value);
        }

        private void Refresh()
        {
            if (ShowCustomAssemblies)
            {
                AssembliesList = new List<AssemblyInfo>(_assemblyRepository.GetCustomAssemblies());
            }
            else
            {
                AssembliesList = new List<AssemblyInfo>(_assemblyRepository.Get());
            }
        }

        private IAssemblyInfoRepository _assemblyRepository;
        private bool _showCustomAssemblies;
        private List<AssemblyInfo> _assembliesList;
    }
}
