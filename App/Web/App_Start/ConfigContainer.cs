using System;
using System.Reflection;
using AppLayer;

namespace Web
{
    public static class ConfigContainer
    {
        public static void Configure()
        {
            var dependencyContainer = new DependencyConfig();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            dependencyContainer.ConfigContainer(assemblies);
        }
    }
}