using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Exceptions;
using Raven.Client.Exceptions.Database;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using Roknoe.Core.Contracts.Interfaces.Databases.Contexts;

namespace Roknoe.Core.Contracts.Databases.Contexts
{
    internal class DocumentStoreContext : IDocumentStoreContext
    {
        private static IDocumentStore _documentStore;
        private readonly IDocumentStoreConfig _config;

        public DocumentStoreContext(IDocumentStoreConfig config)
        {
            _config = config;
        }

        public void Initialize()
        {
            var documentStore = new DocumentStore
            {
                Urls = new[] { _config.Url },
                Database = _config.Database
            };
            
            documentStore.Initialize();

            EnsureDatabaseExists(documentStore);

            _documentStore = documentStore;
        }

        public IDocumentStore Store => _documentStore;

        private static void EnsureDatabaseExists(IDocumentStore store)
        {
            try
            {
                store.Maintenance.ForDatabase(store.Database).Send(new GetStatisticsOperation());
            }
            catch (DatabaseDoesNotExistException)
            {
                try
                {
                    store.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord(store.Database)));
                }
                catch (ConcurrencyException) { }
            }
        }
    }
}