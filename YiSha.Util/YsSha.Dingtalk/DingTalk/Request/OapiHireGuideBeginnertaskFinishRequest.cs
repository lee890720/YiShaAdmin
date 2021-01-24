using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.hire.guide.beginnertask.finish
    /// </summary>
    public class OapiHireGuideBeginnertaskFinishRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiHireGuideBeginnertaskFinishResponse>
    {
        /// <summary>
        /// 任务编码
        /// </summary>
        public string TaskCode { get; set; }

        /// <summary>
        /// 任务类型：0表示基础任务，1表示高阶任务
        /// </summary>
        public Nullable<long> TaskType { get; set; }

        /// <summary>
        /// 员工标识
        /// </summary>
        public string Userid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.hire.guide.beginnertask.finish";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("task_code", this.TaskCode);
            parameters.Add("task_type", this.TaskType);
            parameters.Add("userid", this.Userid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("task_code", this.TaskCode);
            RequestValidator.ValidateRequired("task_type", this.TaskType);
            RequestValidator.ValidateRequired("userid", this.Userid);
        }

        #endregion
    }
}
