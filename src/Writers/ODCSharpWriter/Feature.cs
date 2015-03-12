// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Vipr.Core.CodeModel;

namespace ODCSharpWriter
{
    internal class Feature
    {
        public string Name { get; set; }
        public IEnumerable<Enum> Enums { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Interface> Interfaces { get; set; }

        internal Feature()
        {
            Enums = global::ODCSharpWriter.Enums.Empty;
            Classes = global::ODCSharpWriter.Classes.Empty;
            Interfaces = global::ODCSharpWriter.Interfaces.Empty;
        }

        public static Feature ForCountableCollection(OdcmEntityClass odcmClass)
        {
            return new Feature
            {
                Classes = new[]
                {
                    Class.ForCountableCollection(odcmClass)
                },
                Interfaces = new[]
                {
                    Interface.ForCountableCollection(odcmClass)
                }
            };
        }

        public static Feature ForOdcmClassEntity(OdcmEntityClass odcmClass)
        {
            return new Feature
            {
                Classes = global::ODCSharpWriter.Classes.ForOdcmClassEntity(odcmClass),
                Interfaces = global::ODCSharpWriter.Interfaces.ForOdcmClassEntity(odcmClass),
            };
        }

        public static Feature ForOdcmClassComplex(OdcmClass odcmClass)
        {
            return new Feature
            {
                Classes = global::ODCSharpWriter.Classes.ForOdcmClassComplex(odcmClass),
            };
        }

        public static Feature ForOdcmClassService(OdcmClass odcmClass, OdcmModel model)
        {
            return new Feature
            {
                Classes = global::ODCSharpWriter.Classes.ForOdcmClassService(odcmClass, model),
                Interfaces = global::ODCSharpWriter.Interfaces.ForOdcmClassService(odcmClass),
            };
        }
    }
}