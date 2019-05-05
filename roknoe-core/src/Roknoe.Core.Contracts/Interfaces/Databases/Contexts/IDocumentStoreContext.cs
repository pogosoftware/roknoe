using Raven.Client.Documents;

namespace Roknoe.Core.Contracts.Interfaces.Databases.Contexts
{
    public interface IDocumentStoreContext
    {
        IDocumentStore Store { get; }
        void Initialize();
    }
}