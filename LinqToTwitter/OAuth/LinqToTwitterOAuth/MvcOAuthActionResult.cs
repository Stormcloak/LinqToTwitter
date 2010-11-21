﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LinqToTwitter
{
    public class MvcOAuthActionResult : ActionResult
    {
        private WebAuthorizer m_webAuth;

        public MvcOAuthActionResult(WebAuthorizer webAuth)
        {
            m_webAuth = webAuth;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            m_webAuth.PerformRedirect = authUrl =>
            {
                HttpContext.Current.Response.Redirect(authUrl);
            };

            m_webAuth.BeginAuthorization(HttpContext.Current.Request.Url);
        }
    }
}
