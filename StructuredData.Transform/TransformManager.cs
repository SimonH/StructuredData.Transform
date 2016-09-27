using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using MimeTypes;
using StructuredData.Common.interfaces;
using StructuredData.Transform.Exceptions;
using StructuredData.Transform.interfaces;

namespace StructuredData.Transform
{
    [Export(typeof(IManageStructuredDataTransform))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class TransformManager : IManageStructuredDataTransform
    {
        private readonly IEnumerable<Lazy<ITransformStructuredData, ITransformStructuredDataMetadata>> _structuredDataTranformers;
        private readonly IFileSystem _fileSystem;

        [ImportingConstructor]
        public TransformManager(IFileSystem fileSystem,
            [ImportMany] IEnumerable<Lazy<ITransformStructuredData, ITransformStructuredDataMetadata>> structuredDataTransformers)
        {
            _fileSystem = fileSystem;
            _structuredDataTranformers = structuredDataTransformers;
        }

        public string Transform(string sourceFilePath, string transformFilePath, string method)
        {
            if (!_fileSystem.Exists(sourceFilePath) || !_fileSystem.Exists(transformFilePath))
            {
                throw new StructuredDataTransformException("Cannot perform transform. File does not exist");
            }
            var mimeType = MimeTypeMap.GetMimeType(Path.GetExtension(sourceFilePath));
            return Transform(_fileSystem.ReadAllText(sourceFilePath), _fileSystem.ReadAllText(transformFilePath), mimeType, method);
        }

        public string Transform(string sourceData, string transformData, string mimeType, string method)
        {
            var transformer = _structuredDataTranformers
                ?.FirstOrDefault(sdt => string.Equals(sdt.Metadata.Method, method, StringComparison.OrdinalIgnoreCase) && string.Equals(sdt.Metadata.MimeType, mimeType, StringComparison.OrdinalIgnoreCase))
                ?.Value;
            if (transformer == null)
            {
                throw new StructuredDataTransformException($"Could not locate a transformer for mimetype : {mimeType}, method : {method}");
            }
            return transformer.Transform(sourceData, transformData);
        }
    }
}