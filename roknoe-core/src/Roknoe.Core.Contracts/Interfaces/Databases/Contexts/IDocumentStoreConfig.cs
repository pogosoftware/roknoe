namespace Roknoe.Core.Contracts.Interfaces.Databases.Contexts
{
    public interface IDocumentStoreConfig
    {
        string Database { get; set; }
        string Url { get; set; }
    }
}