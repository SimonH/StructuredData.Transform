using System.IO;

namespace StructuredData.Transform
{
    public static class StructuredDataTransform
    {

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

        public static string TransformFile(this string filePath, string transformFilePath, string method)
        {
        }

        public static string ContentTransform(this string sourceData, string transformData, string mimetype, string method)
        {
        }

        private static string ExtractMethodFromTransformFilePath(string transformFilePath)
        {
            return Path.GetExtension(transformFilePath)?.Substring(1);
        }
    }
}