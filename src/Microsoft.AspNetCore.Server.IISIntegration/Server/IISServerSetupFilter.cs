// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.AspNetCore.Server.IISIntegration
{
    internal class IISServerSetupFilter : IStartupFilter
    {
        private string _virtualPath;

        public IISServerSetupFilter(string virtualPath)
        {
            _virtualPath = virtualPath;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UsePathBase(_virtualPath);
                next(app);
            };
        }
    }
}
