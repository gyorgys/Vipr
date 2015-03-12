﻿using System.Collections.Generic;

namespace ODCSharpWriter.Settings
{
    public class CSharpWriterSettings
    {
        public CSharpWriterSettings()
        {
            OdcmNamespaceToProxyNamespace = new Dictionary<string, string>();
            OdcmClassNameToProxyClassName = new Dictionary<string, IDictionary<string, string>>();
        }

        public IDictionary<string, string> OdcmNamespaceToProxyNamespace { get; set; }

        public IDictionary<string, IDictionary<string, string>> OdcmClassNameToProxyClassName { get; set; }

        public string NamespacePrefix { get; set; }

        public bool OmitFetcherUpcastMethods { get; set; }
        
        public bool ForcePropertyPascalCasing { get; set; }
    }
}
