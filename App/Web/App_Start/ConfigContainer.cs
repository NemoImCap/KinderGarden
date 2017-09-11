using System;
using System.Reflection;
using AppLayer;

namespace Web
{
    public static class ConfigContainer
    {
        public static void Configure()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            DependencyConfig.ConfigContainer(assemblies);
        }
    }
}