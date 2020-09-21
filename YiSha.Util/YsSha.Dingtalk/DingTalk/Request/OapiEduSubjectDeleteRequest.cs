using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.edu.subject.delete
    /// </summary>
    public class OapiEduSubjectDeleteRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiEduSubjectDeleteResponse>
    {
        /// <summary>
        /// 学科编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 学科名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 操作人userId
        /// </summary>
        public string OperatorUserid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.edu.subject.delete";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("code", this.Code);
            parameters.Add("name", this.Name);
            parameters.Add("operator_userid", this.OperatorUserid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("code", this.Code);
            RequestValidator.ValidateRequired("operator_userid", this.OperatorUserid);
        }

        #endregion
    }
}
