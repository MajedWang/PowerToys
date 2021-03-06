﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace Microsoft.PowerToys.Telemetry.Events
{
    /// <summary>
    /// A base class to implement properties that are common to all telemetry events.
    /// </summary>
    [EventData]
    public class EventBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Part of telem, can't adjust")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Part of telem, can't adjust")]
        public bool UTCReplace_AppSessionGuid => true;

        private string _version;

        public string Version
        {
            get
            {
                if (string.IsNullOrEmpty(_version))
                {
                    _version = GetVersionFromAssembly();
                }

                return _version;
            }
        }

        private static string GetVersionFromAssembly()
        {
            // For consistency this should be formatted the same way as
            // https://github.com/microsoft/PowerToys/blob/710f92d99965109fd788d85ebf8b6b9e0ba1524a/src/common/common.cpp#L635
            var version = Assembly.GetExecutingAssembly()?.GetName()?.Version ?? new Version();

            return $"v{version.Major}.{version.Minor}.{version.Build}";
        }
    }
}
