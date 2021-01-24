using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiKacDatavAnnualReportGetResponse.
    /// </summary>
    public class OapiKacDatavAnnualReportGetResponse : DingTalkResponse
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 返回结果对象
        /// </summary>
        [XmlElement("result")]
        public AnnualReportResponseDomain Result { get; set; }

	/// <summary>
/// AnnualReportResponseDomain Data Structure.
/// </summary>
[Serializable]

public class AnnualReportResponseDomain : TopObject
{
	        /// <summary>
	        /// 年累计打卡天数
	        /// </summary>
	        [XmlElement("at_check_days_1y")]
	        public long AtCheckDays1y { get; set; }
	
	        /// <summary>
	        /// 年累计智能填表的人次，仅当type=1时有效
	        /// </summary>
	        [XmlElement("general_form_user_cnt_1y")]
	        public long GeneralFormUserCnt1y { get; set; }
	
	        /// <summary>
	        /// 年累计新增内部群聊数量，仅当type=3时有效
	        /// </summary>
	        [XmlElement("inner_group_cnt_1y")]
	        public long InnerGroupCnt1y { get; set; }
	
	        /// <summary>
	        /// 年累计发起视频会议时长（分钟）
	        /// </summary>
	        [XmlElement("join_succ_video_conf_len_1y")]
	        public string JoinSuccVideoConfLen1y { get; set; }
	
	        /// <summary>
	        /// 年累计参与（含发起）视频会议次数
	        /// </summary>
	        [XmlElement("join_succ_video_conf_num_1y")]
	        public long JoinSuccVideoConfNum1y { get; set; }
	
	        /// <summary>
	        /// 年累计参与（含发起）视频会议人次，仅当type=1时有效
	        /// </summary>
	        [XmlElement("join_succ_video_conf_user_cnt_1y")]
	        public long JoinSuccVideoConfUserCnt1y { get; set; }
	
	        /// <summary>
	        /// 年累计参与（含发起）语音会议时长（分钟）
	        /// </summary>
	        [XmlElement("join_succ_voip_conf_len_1y")]
	        public string JoinSuccVoipConfLen1y { get; set; }
	
	        /// <summary>
	        /// 年累计参与（含发起）语音会议次数
	        /// </summary>
	        [XmlElement("join_succ_voip_conf_num_1y")]
	        public long JoinSuccVoipConfNum1y { get; set; }
	
	        /// <summary>
	        /// 年累计参与（含发起）语音会议人次，仅当type=1时有效
	        /// </summary>
	        [XmlElement("join_succ_voip_conf_user_cnt_1y")]
	        public long JoinSuccVoipConfUserCnt1y { get; set; }
	
	        /// <summary>
	        /// 年累计参与直播次数
	        /// </summary>
	        [XmlElement("live_join_succ_cnt_1y")]
	        public long LiveJoinSuccCnt1y { get; set; }
	
	        /// <summary>
	        /// 年累计参与直播时长（分钟）
	        /// </summary>
	        [XmlElement("live_join_succ_time_len_1y")]
	        public string LiveJoinSuccTimeLen1y { get; set; }
	
	        /// <summary>
	        /// 年累计外勤天数
	        /// </summary>
	        [XmlElement("outside_days_1y")]
	        public long OutsideDays1y { get; set; }
	
	        /// <summary>
	        /// 处理审批数
	        /// </summary>
	        [XmlElement("process_inst_operate_cnt_1y")]
	        public long ProcessInstOperateCnt1y { get; set; }
	
	        /// <summary>
	        /// 发起审批数
	        /// </summary>
	        [XmlElement("process_inst_submit_cnt_1y")]
	        public long ProcessInstSubmitCnt1y { get; set; }
	
	        /// <summary>
	        /// 年累计使用的应用数量
	        /// </summary>
	        [XmlElement("use_micro_app_cnt_1y")]
	        public long UseMicroAppCnt1y { get; set; }
	
	        /// <summary>
	        /// 年累计使用的应用人数，仅当type=1,2时有效
	        /// </summary>
	        [XmlElement("use_micro_user_cnt_1y")]
	        public long UseMicroUserCnt1y { get; set; }
}

    }
}
