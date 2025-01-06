using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Repositories;
using KpblcCadInfrastructure.Core.NET.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KpblcCadInfrastructure.NUnitTests
{
    public class AssemblyInfoVMTest
    {
        [OneTimeSetUp]
        public void StartUp()
        {
            _viewModel = new AssemblyInfosViewModel(new AssemblyInfoRepositoryTest());
        }

        [Test]
        public void CheckAllAssemblyInfoRange()
        {
            _viewModel.ShowCustomAssemblies = false;
            Assert.AreEqual(_viewModel.AssembliesList.Count, 3);
        }

        [Test]
        public void CheckCustomAssemblyInfoRange()
        {
            _viewModel.ShowCustomAssemblies = true;
            Assert.AreEqual(_viewModel.AssembliesList.Count, 1);
        }

        public class AssemblyInfoRepositoryTest : AssemblyInfoRepository
        {
            public AssemblyInfoRepositoryTest()
            {
                _assemblyInfos = new List<AssemblyInfo>()
                {
                    new AssemblyInfo(Path.Combine(progrmFilesPath, "kpblc\\test1.dll"), new Version(0, 0, 1, 1)),
                    new AssemblyInfo(Path.Combine(progrmFilesPath, "kpblc\\test2.dll"), new Version(0, 0, 1, 1)),
                    new AssemblyInfo(Path.Combine(Environment.GetEnvironmentVariable("appdata"), "kpblc\\test1.dll"),
                        new Version(0, 0, 1, 1)),
                };
            }

            public override IEnumerable<AssemblyInfo> Get()
            {
                return _assemblyInfos;
            }

            private List<AssemblyInfo> _assemblyInfos;
            private string progrmFilesPath = Environment.GetEnvironmentVariable("programfiles");
        }
        
        private AssemblyInfosViewModel _viewModel;
    }
}
