using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiFinanceLoanQualificationGetResponse.
    /// </summary>
    public class OapiFinanceLoanQualificationGetResponse : DingTalkResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 开放平台布点查询用户客户切分模型
        /// </summary>
        [XmlElement("result")]
        public CustomerInfoDomain Result { get; set; }

        /// <summary>
        /// true 成功，false 异常
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// CustomerInfoDomain Data Structure.
/// </summary>
[Serializable]

public class CustomerInfoDomain : TopObject
{
	        /// <summary>
	        /// 显示/不显示入口
	        /// </summary>
	        [XmlElement("enable")]
	        public string Enable { get; set; }
	
	        /// <summary>
	        /// 临时动态url，该url会302到真正的借款入口url
	        /// </summary>
	        [XmlElement("url")]
	        public string Url { get; set; }
}

    }
}
