using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.finance.loan.contacts.list
    /// </summary>
    public class OapiFinanceLoanContactsListRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiFinanceLoanContactsListResponse>
    {
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string UserMobile { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.finance.loan.contacts.list";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id_card_no", this.IdCardNo);
            parameters.Add("user_mobile", this.UserMobile);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("id_card_no", this.IdCardNo);
            RequestValidator.ValidateRequired("user_mobile", this.UserMobile);
        }

        #endregion
    }
}
