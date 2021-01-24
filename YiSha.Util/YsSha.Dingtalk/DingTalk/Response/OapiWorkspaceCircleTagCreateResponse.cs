using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiWorkspaceCircleTagCreateResponse.
    /// </summary>
    public class OapiWorkspaceCircleTagCreateResponse : DingTalkResponse
    {
        /// <summary>
        /// dingOpenErrcode
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// errorMsg
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 返回结果数据
        /// </summary>
        [XmlElement("result")]
        public FvPostTagOpenDtoDomain Result { get; set; }

        /// <summary>
        /// 请求是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// FvPostTagOpenDtoDomain Data Structure.
/// </summary>
[Serializable]

public class FvPostTagOpenDtoDomain : TopObject
{
	        /// <summary>
	        /// 话题名
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 话题Id
	        /// </summary>
	        [XmlElement("tag_id")]
	        public long TagId { get; set; }
	
	        /// <summary>
	        /// 话题类型
	        /// </summary>
	        [XmlElement("tag_type")]
	        public long TagType { get; set; }
}

    }
}
