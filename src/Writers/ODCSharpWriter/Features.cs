// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Vipr.Core.CodeModel;

namespace ODCSharpWriter
{
    internal static class Features
    {
        public static IEnumerable<Feature> ForOdcmEnum(OdcmEnum odcmEnum)
        {
            return new[]
            {
                new Feature 
                {
                    Enums = new[]
                    {
                        new Enum(odcmEnum)
                    }
                }
            };
        }

        public static IEnumerable<Feature> ForOdcmClass(OdcmClass odcmClass)
        {
            switch (odcmClass.Kind)
            {
                case OdcmClassKind.Complex:
                    return Features.ForOdcmClassComplex(odcmClass);

                case OdcmClassKind.MediaEntity:
                case OdcmClassKind.Entity:
                    return Features.ForOdcmClassEntity((OdcmEntityClass)odcmClass);

                case OdcmClassKind.Service:
                    return Enumerable.Empty<Feature>();
            }

            throw new NotImplementedException(string.Format("OdcmClassKind {0} is not recognized", odcmClass.Kind));
        }

        public static IEnumerable<Feature> ForEntityContainer(OdcmClass odcmClass, OdcmModel model)
        {
            switch (odcmClass.Kind)
            {
                case OdcmClassKind.Complex:
                case OdcmClassKind.MediaEntity:
                case OdcmClassKind.Entity:
                    return Enumerable.Empty<Feature>();

                case OdcmClassKind.Service:
                    return Features.ForOdcmClassService(odcmClass, model);
            }

            throw new NotImplementedException(string.Format("OdcmClassKind {0} is not recognized", odcmClass.Kind));
        }

        private static IEnumerable<Feature> ForOdcmClassService(OdcmClass odcmClass, OdcmModel model)
        {
            return new[]
            {
                Feature.ForOdcmClassService(odcmClass, model),
            };
        }

        private static IEnumerable<Feature> ForOdcmClassEntity(OdcmEntityClass odcmClass)
        {
            return new[]
            {
                Feature.ForOdcmClassEntity(odcmClass),
                Feature.ForCountableCollection(odcmClass),
            };
        }

        private static IEnumerable<Feature> ForOdcmClassComplex(OdcmClass odcmClass)
        {
            return new[]
            {
                Feature.ForOdcmClassComplex(odcmClass),
            };
        }
    }
}