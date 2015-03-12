// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ODCSharpWriter
{
    public class GeneratedEdmModelCreateXmlReaderMethod : Method
    {
        public GeneratedEdmModelCreateXmlReaderMethod()
        {
            IsPublic = false;
            IsStatic = true;
            Name = "CreateXmlReader";
            Parameters = new[] { new Parameter(new Type(new Identifier("System", "String")), "edmxToParse") };
            ReturnType = new Type(new Identifier("global::System.Xml", "XmlReader"));
        }
    }
}