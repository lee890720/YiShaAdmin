using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.crm.app.create
    /// </summary>
    public class OapiCrmAppCreateRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiCrmAppCreateResponse>
    {
        /// <summary>
        /// 创建应用入参
        /// </summary>
        public string Request { get; set; }

        public CreateCrmMicroAppRequestDomain Request_ { set { this.Request = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.crm.app.create";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("request", this.Request);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("request", this.Request);
        }

	/// <summary>
/// CreateCrmMicroAppRequestDomain Data Structure.
/// </summary>
[Serializable]

public class CreateCrmMicroAppRequestDomain : TopObject
{
	        /// <summary>
	        /// app_desc
	        /// </summary>
	        [XmlElement("app_desc")]
	        public string AppDesc { get; set; }
	
	        /// <summary>
	        /// app_icon
	        /// </summary>
	        [XmlElement("app_icon")]
	        public string AppIcon { get; set; }
	
	        /// <summary>
	        /// biz_key
	        /// </summary>
	        [XmlElement("biz_key")]
	        public string BizKey { get; set; }
	
	        /// <summary>
	        /// homepage
	        /// </summary>
	        [XmlElement("homepage")]
	        public string Homepage { get; set; }
	
	        /// <summary>
	        /// ip_white_list
	        /// </summary>
	        [XmlElement("ip_white_list")]
	        public string IpWhiteList { get; set; }
	
	        /// <summary>
	        /// name
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// pc_homepage
	        /// </summary>
	        [XmlElement("pc_homepage")]
	        public string PcHomepage { get; set; }
}

        #endregion
    }
}
