using System.ComponentModel.Composition;
using StructuredData.Transform.interfaces;

namespace StructuredData.Transform
{
    [Export(typeof(IManageStructuredDataTransform))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class TransformManager : IManageStructuredDataTransform
    {
        public string Transform(string sourceFilePath, string resultDeclarationFilePath, string method)
        {
            throw new System.NotImplementedException();
        }

        public string Compare(string sourceData, string resultDeclarationData, string mimeType, string method)
        {
            throw new System.NotImplementedException();
        }
    }
}