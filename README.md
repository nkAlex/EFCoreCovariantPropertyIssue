Possible issue with EF Core, C#9 covariant properties, inheritance when using generic methods with `EntityTypeBuilder`.

https://github.com/dotnet/efcore/issues/23596

Running these command inside the `Persistence` project folder will succeed and produce expected result:
```commandline
dotnet ef migrations add DbContextSimpleWithoutHelperClass_Initial --context "DbContextSimpleWithoutHelperClass"
dotnet ef migrations script -o "DbContextSimpleWithoutHelperClass.sql" --context "DbContextSimpleWithoutHelperClass"

dotnet ef migrations add DbContextSimpleWithHelperClass_Initial --context "DbContextSimpleWithHelperClass"
dotnet ef migrations script -o "DbContextSimpleWithHelperClass.sql" --context "DbContextSimpleWithHelperClass"

dotnet ef migrations add DbContextCovariantWithoutHelperClass_Initial --context "DbContextCovariantWithoutHelperClass"
dotnet ef migrations script -o "DbContextCovariantWithoutHelperClass.sql" --context "DbContextCovariantWithoutHelperClass"
```

However, running these:
```commandline
dotnet ef migrations add DbContextCovariantWithHelperClass_Initial --context "DbContextCovariantWithHelperClass"
dotnet ef migrations script -o "DbContextCovariantWithHelperClass.sql" --context "DbContextCovariantWithHelperClass"
```

will fail with an exception:
```
System.InvalidOperationException: No suitable constructor was found for entity type 'CovariantEntity'. The following constructors had parameters that could not be bound to properties of the entity type: cannot bind 'id' in 'CovariantEntity(EntityId id)'.
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.ConstructorBindingConvention.ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext`1 context)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.ImmediateConventionScope.OnModelFinalizing(IConventionModelBuilder modelBuilder)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.OnModelFinalizing(IConventionModelBuilder modelBuilder)
   at Microsoft.EntityFrameworkCore.Metadata.Internal.Model.FinalizeModel()
   at Microsoft.EntityFrameworkCore.ModelBuilder.FinalizeModel()
   at Microsoft.EntityFrameworkCore.Infrastructure.ModelSource.CreateModel(DbContext context, IConventionSetBuilder conventionSetBuilder, ModelDependencies modelDependencies)
   at Microsoft.EntityFrameworkCore.Infrastructure.ModelSource.GetModel(DbContext context, IConventionSetBuilder conventionSetBuilder, ModelDependencies modelDependencies)
   at Microsoft.EntityFrameworkCore.Internal.DbContextServices.CreateModel()
   at Microsoft.EntityFrameworkCore.Internal.DbContextServices.get_Model()
   at Microsoft.EntityFrameworkCore.Infrastructure.EntityFrameworkServicesBuilder.<>c.<TryAddCoreServices>b__7_3(IServiceProvider p)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitFactory(FactoryCallSite factoryCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite callSite, RuntimeResolverContext context, ServiceProviderEngineScope serviceProviderEngine, RuntimeResolverLock lockType)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite singletonCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite constructorCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite callSite, RuntimeResolverContext context, ServiceProviderEngineScope serviceProviderEngine, RuntimeResolverLock lockType)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite singletonCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite callSite, ServiceProviderEngineScope scope)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.DynamicServiceProviderEngine.<>c__DisplayClass1_0.<RealizeService>b__0(ServiceProviderEngineScope scope)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService(Type serviceType)
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider provider, Type serviceType)
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider provider)
   at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies()
   at Microsoft.EntityFrameworkCore.DbContext.get_InternalServiceProvider()
   at Microsoft.EntityFrameworkCore.DbContext.Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure<System.IServiceProvider>.get_Instance()
   at Microsoft.EntityFrameworkCore.Infrastructure.Internal.InfrastructureExtensions.GetService[TService](IInfrastructure`1 accessor)
   at Microsoft.EntityFrameworkCore.Infrastructure.AccessorExtensions.GetService[TService](IInfrastructure`1 accessor)
   at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.CreateContext(Func`1 factory)
   at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.CreateContext(String contextType)
   at Microsoft.EntityFrameworkCore.Design.Internal.MigrationsOperations.AddMigration(String name, String outputDir, String contextType, String namespace)
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.AddMigrationImpl(String name, String outputDir, String contextType, String namespace)
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.AddMigration.<>c__DisplayClass0_0.<.ctor>b__0()
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OperationBase.<>c__DisplayClass3_0`1.<Execute>b__0()
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OperationBase.Execute(Action action)
No suitable constructor was found for entity type 'CovariantEntity'. The following constructors had parameters that could not be bound to properties of the entity type: cannot bind 'id' in 'CovariantEntity(EntityId id)'.
```

The project is also making an `IRelationalTypeMappingSourcePlugin` injection to make EF Core understand custom `Identifier` types, but the failure seems to occur even before this plugin is called.
