using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.workspace.circle.tag.create
    /// </summary>
    public class OapiWorkspaceCircleTagCreateRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiWorkspaceCircleTagCreateResponse>
    {
        /// <summary>
        /// 请求
        /// </summary>
        public string Req { get; set; }

        public FvTagCreateOpenDtoDomain Req_ { set { this.Req = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.workspace.circle.tag.create";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("req", this.Req);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("req", this.Req);
        }

	/// <summary>
/// FvTagCreateOpenDtoDomain Data Structure.
/// </summary>
[Serializable]

public class FvTagCreateOpenDtoDomain : TopObject
{
	        /// <summary>
	        /// 话题名
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 用户在圈子或项目内的userId
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
}

        #endregion
    }
}
