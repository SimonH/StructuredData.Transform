using System.IO;
using StructuredData.Common.Container;
using StructuredData.Transform.interfaces;

namespace StructuredData.Transform
{
    public static class StructuredDataTransform
    {
        private static IManageStructuredDataTransform GetTransformManager()
        {
            return ContainerManager.CompositionContainer.GetExport<IManageStructuredDataTransform>()?.Value;
        }

        public static string Transform(this FileInfo sourceFile, FileInfo transformFile)
        {
            return sourceFile.FullName.TransformFile(transformFile.FullName);
        }

        public static string Transform(this FileInfo sourceFile, FileInfo transformFile, string method)
        {
            return sourceFile.FullName.TransformFile(transformFile.FullName, method);
        }

        public static string TransformFile(this string filePath, string transformFilePath)
        {
            return TransformFile(filePath, transformFilePath, ExtractMethodFromTransformFilePath(transformFilePath));
        }

        public static string TransformFile(this string sourceFilePath, string transformFilePath, string method)
        {
            return GetTransformManager().Transform(sourceFilePath, transformFilePath, method);
        }

        public static string Transform(this string sourceData, string transformData, string mimetype, string method)
        {
            return GetTransformManager().Transform(sourceData, transformData, mimetype, method);
        }

        private static string ExtractMethodFromTransformFilePath(string transformFilePath)
        {
            return Path.GetExtension(transformFilePath)?.Substring(1);
        }
    }
}