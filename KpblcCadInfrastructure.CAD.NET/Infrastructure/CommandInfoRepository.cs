using KpblcCadInfrastructure.Abstractions.Entities;
using KpblcCadInfrastructure.Abstractions.Interfaces;
using System.ComponentModel;
using System.Reflection;
using Teigha.Runtime;

namespace KpblcCadInfrastructure.CAD.NET.Infrastructure
{
    internal class CommandInfoRepository : ICommandInfoRepository
    {
        public IEnumerable<CommandInfo> Get(IEnumerable<Assembly> Assemblies)
        {
            List<CommandInfo> cmdInfos = new List<CommandInfo>();
            foreach (Assembly assembly in Assemblies)
            {
                try
                {
                    Type[] expTypes = assembly.GetTypes();
                    foreach (Type t in expTypes)
                    {
                        MethodInfo[] methods = t.GetMethods();
                        foreach (MethodInfo methodInfo in methods)
                        {
                            CommandInfo item = GetCommandInfo(assembly, methodInfo);
                            if (!string.IsNullOrWhiteSpace(item.GlobalName))
                            {
                                cmdInfos.Add(item);
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            return cmdInfos;
        }

        private CommandInfo GetCommandInfo(Assembly Assembly, MethodInfo Method)
        {
            object[] attributes = Method.GetCustomAttributes(true);
            CommandInfo cmdInfo = new CommandInfo();
            foreach (object attribute in attributes)
            {
                cmdInfo.Assembly = Assembly;
                if (attribute is CommandMethodAttribute cmdAttr)
                {
                    cmdInfo.GlobalName = cmdAttr.GlobalName;
                    cmdInfo.LocalizedName = cmdAttr.LocalizedNameId;
                }
                else if (attribute is DescriptionAttribute descAttribute)
                {
                    cmdInfo.Desctiption = descAttribute.Description;
                }
            }

            return cmdInfo;
        }
    }
}