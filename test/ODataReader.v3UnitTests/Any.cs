﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Linq;

namespace Microsoft.Its.Recipes
{
    internal partial class Any
    {
        /// <summary>
        /// Generate a CamelCaseName using <see cref="Words"/>
        /// </summary>
        /// <param name="wordCount">Number of words to compose together as the name</param>
        public static string PascalCaseName(int wordCount = 4)
        {
            string camelCaseName = CamelCaseName(wordCount);
            return camelCaseName.Substring(0, 1).ToLowerInvariant() + camelCaseName.Substring(1);
        }

        public static XElement Association(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string actionString = string.Format(ODataReader.v3UnitTests.Properties.Resources.Association_element,
                pascalCaseName);

            XElement element = XElement.Parse(actionString);

            if (config != null) config(element);

            return element;
        }

        public static XElement AssociationSet(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string actionImportString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.AssociationSet_element, pascalCaseName);

            XElement element = XElement.Parse(actionImportString);

            if (config != null) config(element);

            return element;
        }

        public static XElement ComplexType(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string complexTypeString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.ComplexType_element, pascalCaseName);

            XElement element = XElement.Parse(complexTypeString);

            if (config != null) config(element);

            return element;
        }

        public static XElement DataServices(Action<XElement> config = null)
        {
            XElement element = XElement.Parse(ODataReader.v3UnitTests.Properties.Resources.DataServices_element);

            if (config != null) config(element);

            return element;
        }

        public static XElement Edmx(Action<XElement> config = null)
        {
            XElement element = XElement.Parse(ODataReader.v3UnitTests.Properties.Resources.Edmx_element);

            if (config != null) config(element);

            return element;
        }

        public static XElement End(Action<XElement> config = null)
        {
            XElement element = XElement.Parse(ODataReader.v3UnitTests.Properties.Resources.End_element);

            if (config != null) config(element);

            return element;
        }

        public static XElement EntityContainer(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1,3));
            string entityContainerString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.EntityContainer_element, pascalCaseName);

            XElement element = XElement.Parse(entityContainerString);

            if (config != null) config(element);

            return element;
        }

        public static XElement EntitySet(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string entitySetString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.EntitySet_element, pascalCaseName);

            XElement element = XElement.Parse(entitySetString);

            if (config != null) config(element);

            return element;
        }

        public static XElement EntityType(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string entityTypeString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.EntityType_element, pascalCaseName);

            XElement element = XElement.Parse(entityTypeString);

            if (config != null) config(element);

            return element;
        }

        public static XElement EnumType(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string enumTypeString = string.Format(ODataReader.v3UnitTests.Properties.Resources.EnumType_element,
                pascalCaseName);

            XElement element = XElement.Parse(enumTypeString);

            if (config != null) config(element);

            return element;
        }

        public static XElement FunctionImport(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string functionImportString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.FunctionImport_element, pascalCaseName);

            XElement element = XElement.Parse(functionImportString);

            if (config != null) config(element);

            return element;
        }

        public static XElement Key(Action<XElement> config = null)
        {
            XElement element = XElement.Parse(ODataReader.v3UnitTests.Properties.Resources.Key_element);

            if (config != null) config(element);

            return element;
        }

        public static XElement Member(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string memberString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.Member_element, pascalCaseName);

            XElement element = XElement.Parse(memberString);

            if (config != null) config(element);

            return element;
        }

        public static XElement NavigationProperty(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string navigationPropertyString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.NavigationProperty_element, pascalCaseName);

            XElement element = XElement.Parse(navigationPropertyString);

            if (config != null) config(element);

            return element;
        }

        public static XElement Parameter(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string parameterString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.Parameter_element, pascalCaseName);

            XElement element = XElement.Parse(parameterString);

            if (config != null) config(element);

            return element;
        }

        public static XElement Property(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string propertyString =
                string.Format(ODataReader.v3UnitTests.Properties.Resources.Property_element, pascalCaseName);

            XElement element = XElement.Parse(propertyString);

            if (config != null) config(element);

            return element;
        }

        public static XElement PropertyRef(Action<XElement> config = null)
        {
            XElement element = XElement.Parse(ODataReader.v3UnitTests.Properties.Resources.PropertyRef_element);

            if (config != null) config(element);

            return element;
        }

        public static XElement Schema(Action<XElement> config = null)
        {
            string pascalCaseName = PascalCaseName(Int(1, 3));
            string schemaString = string.Format(ODataReader.v3UnitTests.Properties.Resources.Schema_element,
                pascalCaseName);

            XElement element = XElement.Parse(schemaString);

            if (config != null) config(element);

            return element;
        }
    }
}
