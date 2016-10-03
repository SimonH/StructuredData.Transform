# StructuredData.Transform
Extensible Library for transforming structured Data

Available as a package on [Nuget](https://www.nuget.org/packages/StructuredData.Transform/)

##Usage
  StructuredData.Transform provides data agnostic functions which can be extended, using MEF, to tranform any structured data.
  
* Install one (or more) of the implementation packages (e.g. StructuredData.Transform.JsonPatch)
* Call one of the extension methods on StructuredDataTransform

[e.g. "SourceFilePath.json".TransformFile("ResultFilePath.jsonpatch") or "SourceFilePath.json".TransformFile("ResultFilePath.json", "jsonPatch")]

This library uses [Media Type Map](https://www.nuget.org/packages/MediaTypeMap/) to obtain the mimetype from the extension of the source file and, when the transform method is not explictly provided uses the extension of the result file.

Available implementations are imported via MEF and the correct implementation selected at runtime using file extensions or the supplied parameters.

##Extending

Developers can write their own transforms by implementing and exporting ITransformStructuredData

 [Export(typeof(ITransformStructuredData))]  
 [ExportMetadata("MimeType", "text/xml")]  
 [ExportMetadata("Method", "xdt")]  
