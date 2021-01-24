using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.finance.loan.qualification.get
    /// </summary>
    public class OapiFinanceLoanQualificationGetRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiFinanceLoanQualificationGetResponse>
    {
        /// <summary>
        /// 用户免登录授权码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 布点渠道类型
        /// </summary>
        public string OpenChannelType { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.finance.loan.qualification.get";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("code", this.Code);
            parameters.Add("open_channel_type", this.OpenChannelType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("code", this.Code);
            RequestValidator.ValidateRequired("open_channel_type", this.OpenChannelType);
        }

        #endregion
    }
}
