using Aleph1.DI.Contracts;
using Aleph1.Security.Contracts;
using Aleph1.Security.Implementation.RijndaelManagedCipher;
using MatrixTest.Security.Contracts;

using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

namespace MatrixTest.Security.Implementation
{
    /// <summary>Used to register concrete implementations to the DI container</summary>
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        /// <summary>Used to register concrete implementations to the DI container</summary>
        /// <param name="registrar">add implementation to the DI container using this registrar</param>
        public void Initialize(IModuleRegistrar registrar)
        {
            Contract.Requires(registrar != null);

            registrar.RegisterTypeAsSingelton<ICipher, RijndaelManagedCipher>();
            registrar.RegisterTypeAsSingelton<ISecurity, SecurityService>();
            registrar.RegisterTypeAsSingelton<HashHelpers, HashHelpers>();
        }
    }
}
