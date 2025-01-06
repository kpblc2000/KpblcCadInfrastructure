﻿using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KpblcCadInfrastructure.NUnitTests
{
    public class AssemblyInfoRepTest
    {
        [OneTimeSetUp]
        public void StartUp()
        {
            _assemblyInfoRepositoryTest = new AssemblyInfoRepositoryTest();
        }

        [Test]
        public void CheckAllAssemblyInfoRange()
        {
            Assert.AreEqual(_assemblyInfoRepositoryTest.Get().Count(), 3);
        }

        [Test]
        public void CheckCustomAssemblyInfoRange()
        {
            Assert.AreEqual(_assemblyInfoRepositoryTest.GetCustomAssemblies().Count(), 1);
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

        private AssemblyInfoRepositoryTest _assemblyInfoRepositoryTest;
    }
}