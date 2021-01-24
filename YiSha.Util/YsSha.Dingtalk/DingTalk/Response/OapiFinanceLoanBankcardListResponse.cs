using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiFinanceLoanBankcardListResponse.
    /// </summary>
    public class OapiFinanceLoanBankcardListResponse : DingTalkResponse
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
        /// 银行卡查询结果
        /// </summary>
        [XmlElement("result")]
        public OpenBankcardQueryResultDomain Result { get; set; }

        /// <summary>
        /// true 成功，false 异常
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// OpenBankcardInfoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenBankcardInfoDomain : TopObject
{
	        /// <summary>
	        /// 银行编码
	        /// </summary>
	        [XmlElement("bank_code")]
	        public string BankCode { get; set; }
	
	        /// <summary>
	        /// 银行名称
	        /// </summary>
	        [XmlElement("bank_name")]
	        public string BankName { get; set; }
	
	        /// <summary>
	        /// 银行卡id
	        /// </summary>
	        [XmlElement("bankcard_id")]
	        public long BankcardId { get; set; }
	
	        /// <summary>
	        /// 银行预留手机号
	        /// </summary>
	        [XmlElement("bankcard_mobile")]
	        public string BankcardMobile { get; set; }
	
	        /// <summary>
	        /// 银行卡号
	        /// </summary>
	        [XmlElement("bankcard_no")]
	        public string BankcardNo { get; set; }
}

	/// <summary>
/// OpenBankcardQueryResultDomain Data Structure.
/// </summary>
[Serializable]

public class OpenBankcardQueryResultDomain : TopObject
{
	        /// <summary>
	        /// 银行卡模型
	        /// </summary>
	        [XmlArray("bankcard_list")]
	        [XmlArrayItem("open_bankcard_info")]
	        public List<OpenBankcardInfoDomain> BankcardList { get; set; }
}

    }
}
