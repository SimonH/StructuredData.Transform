namespace StructuredData.Transform.interfaces
{
    public interface IManageStructuredDataTransform
    {
        string Transform(string sourceFilePath, string resultDeclarationFilePath, string method);
        string Compare(string sourceData, string resultDeclarationData, string mimeType, string method);
    }
}