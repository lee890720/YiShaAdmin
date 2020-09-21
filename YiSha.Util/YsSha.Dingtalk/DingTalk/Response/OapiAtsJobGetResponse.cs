using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiAtsJobGetResponse.
    /// </summary>
    public class OapiAtsJobGetResponse : DingTalkResponse
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
        /// 职位结果
        /// </summary>
        [XmlElement("result")]
        public JobSimpleVODomain Result { get; set; }

	/// <summary>
/// JobAddressVODomain Data Structure.
/// </summary>
[Serializable]

public class JobAddressVODomain : TopObject
{
	        /// <summary>
	        /// 地点详情
	        /// </summary>
	        [XmlElement("detail")]
	        public string Detail { get; set; }
	
	        /// <summary>
	        /// 经度
	        /// </summary>
	        [XmlElement("latitude")]
	        public string Latitude { get; set; }
	
	        /// <summary>
	        /// 纬度
	        /// </summary>
	        [XmlElement("longitude")]
	        public string Longitude { get; set; }
	
	        /// <summary>
	        /// 地点名
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
}

	/// <summary>
/// JobSimpleVODomain Data Structure.
/// </summary>
[Serializable]

public class JobSimpleVODomain : TopObject
{
	        /// <summary>
	        /// 职位地址详情
	        /// </summary>
	        [XmlElement("address")]
	        public JobAddressVODomain Address { get; set; }
	
	        /// <summary>
	        /// 职位地址 市
	        /// </summary>
	        [XmlElement("city")]
	        public string City { get; set; }
	
	        /// <summary>
	        /// 企业id
	        /// </summary>
	        [XmlElement("corpid")]
	        public string Corpid { get; set; }
	
	        /// <summary>
	        /// 职位描述
	        /// </summary>
	        [XmlElement("description")]
	        public string Description { get; set; }
	
	        /// <summary>
	        /// 职位地址 区/县
	        /// </summary>
	        [XmlElement("district")]
	        public string District { get; set; }
	
	        /// <summary>
	        /// 招募人数
	        /// </summary>
	        [XmlElement("head_count")]
	        public long HeadCount { get; set; }
	
	        /// <summary>
	        /// 职位编码
	        /// </summary>
	        [XmlElement("job_code")]
	        public string JobCode { get; set; }
	
	        /// <summary>
	        /// 职位唯一标识
	        /// </summary>
	        [XmlElement("job_id")]
	        public string JobId { get; set; }
	
	        /// <summary>
	        /// 最高薪水，单位分
	        /// </summary>
	        [XmlElement("max_salary")]
	        public long MaxSalary { get; set; }
	
	        /// <summary>
	        /// 最低薪水，单位分
	        /// </summary>
	        [XmlElement("min_salary")]
	        public long MinSalary { get; set; }
	
	        /// <summary>
	        /// 职位名称
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 职位地址 升
	        /// </summary>
	        [XmlElement("province")]
	        public string Province { get; set; }
	
	        /// <summary>
	        /// 1小学 2初中 3高中 4中专 5大专 6本科 7硕士 8 博士 9其他
	        /// </summary>
	        [XmlElement("required_edu")]
	        public long RequiredEdu { get; set; }
	
	        /// <summary>
	        /// 是否薪资面议
	        /// </summary>
	        [XmlElement("salary_negotiable")]
	        public bool SalaryNegotiable { get; set; }
}

    }
}
