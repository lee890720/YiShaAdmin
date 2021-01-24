using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiCrmObjectdataContactCreateResponse.
    /// </summary>
    public class OapiCrmObjectdataContactCreateResponse : DingTalkResponse
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
        /// 结果
        /// </summary>
        [XmlElement("result")]
        public ObjectDataCreateDtoDomain Result { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// ObjectDataCreateDtoDomain Data Structure.
/// </summary>
[Serializable]

public class ObjectDataCreateDtoDomain : TopObject
{
	        /// <summary>
	        /// 联系人用户ID
	        /// </summary>
	        [XmlElement("contact_unionid")]
	        public string ContactUnionid { get; set; }
	
	        /// <summary>
	        /// 联系人通讯录员工ID
	        /// </summary>
	        [XmlElement("contact_userid")]
	        public string ContactUserid { get; set; }
	
	        /// <summary>
	        /// 联系人数据id
	        /// </summary>
	        [XmlElement("instance_id")]
	        public string InstanceId { get; set; }
}

    }
}
