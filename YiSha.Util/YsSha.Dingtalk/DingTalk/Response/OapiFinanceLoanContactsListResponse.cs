using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiFinanceLoanContactsListResponse.
    /// </summary>
    public class OapiFinanceLoanContactsListResponse : DingTalkResponse
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
        /// 查询返回数据模型
        /// </summary>
        [XmlElement("result")]
        public OpenContactInfoQueryResultDomain Result { get; set; }

        /// <summary>
        /// true 成功，false 异常
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// OpenContactInfoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenContactInfoDomain : TopObject
{
	        /// <summary>
	        /// 联系人id
	        /// </summary>
	        [XmlElement("contact_id")]
	        public long ContactId { get; set; }
	
	        /// <summary>
	        /// 联系人职业
	        /// </summary>
	        [XmlElement("user_category")]
	        public string UserCategory { get; set; }
	
	        /// <summary>
	        /// 联系人关系
	        /// </summary>
	        [XmlElement("user_mobile")]
	        public string UserMobile { get; set; }
	
	        /// <summary>
	        /// 联系人姓名
	        /// </summary>
	        [XmlElement("user_name")]
	        public string UserName { get; set; }
	
	        /// <summary>
	        /// 联系人关系
	        /// </summary>
	        [XmlElement("user_relation")]
	        public string UserRelation { get; set; }
}

	/// <summary>
/// OpenContactInfoQueryResultDomain Data Structure.
/// </summary>
[Serializable]

public class OpenContactInfoQueryResultDomain : TopObject
{
	        /// <summary>
	        /// 联系人列表
	        /// </summary>
	        [XmlArray("contact_info_list")]
	        [XmlArrayItem("open_contact_info")]
	        public List<OpenContactInfoDomain> ContactInfoList { get; set; }
}

    }
}
