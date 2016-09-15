// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http;

// Keep the type public for Security repo as it would be a breaking change to change the accessor now.
// Make this type internal for other repos as it could be used by multiple projects and having it public causes type conflicts.
#if SECURITY
namespace Microsoft.AspNetCore.Authentication.Cookies
{
    /// <summary>
    /// This is used by the CookieAuthenticationMiddleware to process request and response cookies.
    /// It is abstracted from the normal cookie APIs to allow for complex operations like chunking.
    /// </summary>
    public interface ICookieManager
    {
#else
namespace Microsoft.AspNetCore.Cookies
{
    internal interface ICookieManager
    {
#endif
        /// <summary>
        /// Retrieve a cookie of the given name from the request.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetRequestCookie(HttpContext context, string key);

        /// <summary>
        /// Append the given cookie to the response.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        void AppendResponseCookie(HttpContext context, string key, string value, CookieOptions options);

        /// <summary>
        /// Append a delete cookie to the response.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="options"></param>
        void DeleteCookie(HttpContext context, string key, CookieOptions options);
    }
}
