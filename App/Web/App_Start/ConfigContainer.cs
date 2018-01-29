using System;
using AppLayer.DependencyResolvers;

namespace Web
{
    public static class ConfigContainer
    {
        public static void Configure()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            WebAppResolver.ConfigContainer(assemblies);
        }
    }
}