using System;
using System.Collections.Generic;
using System.Reflection;
using Ninject;
using Ninject.Activation;
using Ninject.Activation.Blocks;
using Ninject.Components;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Planning.Bindings;
using Ninject.Syntax;

namespace SourceCodeCounter.Common
{
    public static class GlobalServiceLocator
    {
        private static readonly IKernel Kernel = new StandardKernel();

        public static IBindingToSyntax<T> Bind<T>()
        {
            return Kernel.Bind<T>();
        }

        public static IBindingToSyntax<T1, T2> Bind<T1, T2>()
        {
            return Kernel.Bind<T1, T2>();
        }

        public static IBindingToSyntax<T1, T2, T3> Bind<T1, T2, T3>()
        {
            return Kernel.Bind<T1, T2, T3>();
        }

        public static IBindingToSyntax<T1, T2, T3, T4> Bind<T1, T2, T3, T4>()
        {
            return Kernel.Bind<T1, T2, T3, T4>();
        }

        public static IBindingToSyntax<object> Bind(params Type[] services)
        {
            return Kernel.Bind(services);
        }

        public static void Unbind<T>()
        {
            Kernel.Unbind<T>();
        }

        public static void Unbind(Type service)
        {
            Kernel.Unbind(service);
        }

        public static IBindingToSyntax<T1> Rebind<T1>()
        {
            return Kernel.Rebind<T1>();
        }

        public static IBindingToSyntax<T1, T2> Rebind<T1, T2>()
        {
            return Kernel.Rebind<T1, T2>();
        }

        public static IBindingToSyntax<T1, T2, T3> Rebind<T1, T2, T3>()
        {
            return Kernel.Rebind<T1, T2, T3>();
        }

        public static IBindingToSyntax<T1, T2, T3, T4> Rebind<T1, T2, T3, T4>()
        {
            return Kernel.Rebind<T1, T2, T3, T4>();
        }

        public static IBindingToSyntax<object> Rebind(params Type[] services)
        {
            return Kernel.Rebind(services);
        }

        public static void AddBinding(IBinding binding)
        {
            Kernel.AddBinding(binding);
        }

        public static void RemoveBinding(IBinding binding)
        {
            Kernel.RemoveBinding(binding);
        }

        public static bool CanResolve(IRequest request)
        {
            return Kernel.CanResolve(request);
        }

        public static bool CanResolve(IRequest request, bool ignoreImplicitBindings)
        {
            return Kernel.CanResolve(request, ignoreImplicitBindings);
        }

        public static IEnumerable<object> Resolve(IRequest request)
        {
            return Kernel.Resolve(request);
        }

        public static IRequest CreateRequest(Type service, Func<IBindingMetadata, bool> constraint, IEnumerable<IParameter> parameters, bool isOptional, bool isUnique)
        {
            return Kernel.CreateRequest(service, constraint, parameters, isOptional, isUnique);
        }

        public static object GetService(Type serviceType)
        {
            return Kernel.GetService(serviceType);
        }

        public static void Dispose()
        {
            Kernel.Dispose();
        }

        public static bool IsDisposed { get { return Kernel.IsDisposed; }}
        public static IEnumerable<INinjectModule> GetModules()
        {
            return Kernel.GetModules();
        }

        public static bool HasModule(string name)
        {
            return Kernel.HasModule(name);
        }

        public static void Load(IEnumerable<INinjectModule> m)
        {
            Kernel.Load(m);
        }

        public static void Load(IEnumerable<string> filePatterns)
        {
            Kernel.Load(filePatterns);
        }

        public static void Load(IEnumerable<Assembly> assemblies)
        {
            Kernel.Load(assemblies);
        }

        public static void Unload(string name)
        {
            Kernel.Unload(name);
        }

        public static void Inject(object instance, params IParameter[] parameters)
        {
            Kernel.Inject(instance, parameters);
        }

        public static bool Release(object instance)
        {
            return Kernel.Release(instance);
        }

        public static IEnumerable<IBinding> GetBindings(Type service)
        {
            return Kernel.GetBindings(service);
        }

        public static IActivationBlock BeginBlock()
        {
            return Kernel.BeginBlock();
        }

        public static INinjectSettings Settings { get { return Kernel.Settings; } }
        public static IComponentContainer Components { get { return Kernel.Components; } }
    }
}
