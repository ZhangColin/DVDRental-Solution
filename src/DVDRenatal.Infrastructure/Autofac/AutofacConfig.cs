using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.IoC;
using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Mvc;

namespace DVDRenatal.Infrastructure.Autofac
{
    public static class AutofacConfig {
        private static string assemblySkipLoadingPattern =
           "^System|^mscorlib|^Microsoft|^CppCodeProvider|^VJSharpCodeProvider|^WebDev|^Castle|^Iesi|^log4net|^NHibernate|^nunit|^TestDriven|^MbUnit|^Rhino|^QuickGraph|^TestFu|^Telerik|^ComponentArt|^MvcContrib|^AjaxControlToolkit|^Antlr3|^Remotion|^Recaptcha";
        private static string assemblyRestrictToLoadingPattern = ".*";

        public static void Initialize() {
            ContainerBuilder builder = new ContainerBuilder();


            Assembly[] assemblies =
                BuildManager.GetReferencedAssemblies().Cast<Assembly>().Where(assembly => assembly.FullName.StartsWith("DVDRental")).ToArray();
            builder.RegisterIDependency(assemblies);

            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>();
            builder.RegisterType<DefaultMessageBus>().As<IMessageBus>();
            //                        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();

            //            try {
            //assemblies.SelectMany(assembly => assembly.GetTypes())
            //                .Where(type => type.IsAssignableFrom(typeof (IModule)) && type.IsClass)
            //                .ForEach(type => {
            //                    IModule module = (IModule) Activator.CreateInstance(type);
            //                    module.Load(builder);
            //                });
            //            }
            //            catch(Exception ex) {
            //                
            //                throw;
            //            }

            //            builder.RegisterType<UserContext>().InstancePerHttpRequest();
            builder.RegisterAssemblyModules(assemblies);


            builder.RegisterControllers(assemblies);
            //            builder.RegisterApiControllers(assemblies);

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            ServiceLocator.Resolver = new MvcResolver();

            //            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //            ServiceLocator.Resolver = new ApiResolver();
        }

        private static bool Matches(string assemblyFullName) {
            return !Matches(assemblyFullName, assemblySkipLoadingPattern)
                   && Matches(assemblyFullName, assemblyRestrictToLoadingPattern);
        }

        private static bool Matches(string assemblyFullName, string pattern) {
            return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
    }
}