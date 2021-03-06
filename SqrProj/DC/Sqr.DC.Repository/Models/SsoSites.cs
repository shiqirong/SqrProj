//-----------------------------------------------------------------------
// <copyright file=" sso_sites.cs" company="xxxx Enterprises">
// * Copyright (C) 2018 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: SsoSites.cs
// * history : Created by T4 10/19/2018 21:39:33 
// </copyright>
//-----------------------------------------------------------------------
using System;
using Sqr.DC.Repository.Core;

namespace Sqr.DC.Repository.Models
{
    /// <summary>
    /// SsoSites Entity Model
    /// </summary>    
    [Serializable]
    public class SsoSites:ModelBase
    {
      
			/// <summary>
			/// 站点名称
			/// </summary>
						public string SiteName { get; set; }

      
			/// <summary>
			/// 站点域名
			/// </summary>
						public string SiteUrl { get; set; }

      
			/// <summary>
			/// 登入地址
			/// </summary>
						public string SiteLoginUrl { get; set; }

      
			/// <summary>
			/// 登出地址
			/// </summary>
						public string SiteLogoutUrl { get; set; }

    }
}
