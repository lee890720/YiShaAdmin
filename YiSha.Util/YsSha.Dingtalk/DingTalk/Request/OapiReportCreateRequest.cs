using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.report.create
    /// </summary>
    public class OapiReportCreateRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiReportCreateResponse>
    {
        /// <summary>
        /// 创建日志的参数对象
        /// </summary>
        public string CreateReportParam { get; set; }

        public OapiCreateReportParamDomain CreateReportParam_ { set { this.CreateReportParam = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.report.create";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("create_report_param", this.CreateReportParam);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("create_report_param", this.CreateReportParam);
        }

	/// <summary>
/// OapiReportContentVoDomain Data Structure.
/// </summary>
[Serializable]

public class OapiReportContentVoDomain : TopObject
{
	        /// <summary>
	        /// 日志内容
	        /// </summary>
	        [XmlElement("content")]
	        public string Content { get; set; }
	
	        /// <summary>
	        /// 日志内容的类型
	        /// </summary>
	        [XmlElement("content_type")]
	        public string ContentType { get; set; }
	
	        /// <summary>
	        /// 写日志对应的模板某个字段的标题
	        /// </summary>
	        [XmlElement("key")]
	        public string Key { get; set; }
	
	        /// <summary>
	        /// 写日志对应的模板某个字段的唯一序列id
	        /// </summary>
	        [XmlElement("sort")]
	        public Nullable<long> Sort { get; set; }
	
	        /// <summary>
	        /// 写日志对应的模板某个字段的类型
	        /// </summary>
	        [XmlElement("type")]
	        public Nullable<long> Type { get; set; }
}

	/// <summary>
/// OapiCreateReportParamDomain Data Structure.
/// </summary>
[Serializable]

public class OapiCreateReportParamDomain : TopObject
{
	        /// <summary>
	        /// 保存日志内容对应的模板某个字段的唯一序列id
	        /// </summary>
	        [XmlArray("contents")]
	        [XmlArrayItem("oapi_report_content_vo")]
	        public List<OapiReportContentVoDomain> Contents { get; set; }
	
	        /// <summary>
	        /// 日志来源，每个组织可以自己起一个唯一的来源标识
	        /// </summary>
	        [XmlElement("dd_from")]
	        public string DdFrom { get; set; }
	
	        /// <summary>
	        /// 模板id
	        /// </summary>
	        [XmlElement("template_id")]
	        public string TemplateId { get; set; }
	
	        /// <summary>
	        /// 发送日志到员工时是否发送单聊消息
	        /// </summary>
	        [XmlElement("to_chat")]
	        public Nullable<bool> ToChat { get; set; }
	
	        /// <summary>
	        /// 日志发送到的群id
	        /// </summary>
	        [XmlArray("to_cids")]
	        [XmlArrayItem("string")]
	        public List<string> ToCids { get; set; }
	
	        /// <summary>
	        /// 日志发送到的员工id
	        /// </summary>
	        [XmlArray("to_userids")]
	        [XmlArrayItem("string")]
	        public List<string> ToUserids { get; set; }
	
	        /// <summary>
	        /// 创建日志的员工id
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
}

        #endregion
    }
}
