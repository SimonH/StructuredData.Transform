namespace StructuredData.Transform.interfaces
{
    public interface IManageStructuredDataTransform
    {
        string Transform(string sourceFilePath, string transformFilePath, string method);
        string Transform(string sourceData, string transformData, string mimeType, string method);
    }
}