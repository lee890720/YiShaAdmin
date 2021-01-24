using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.finance.loan.bankcard.delete
    /// </summary>
    public class OapiFinanceLoanBankcardDeleteRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiFinanceLoanBankcardDeleteResponse>
    {
        /// <summary>
        /// 银行编码
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行卡id
        /// </summary>
        public Nullable<long> BankcardId { get; set; }

        /// <summary>
        /// 银行预留手机号
        /// </summary>
        public string BankcardMobile { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankcardNo { get; set; }

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
            return "dingtalk.oapi.finance.loan.bankcard.delete";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("bank_code", this.BankCode);
            parameters.Add("bank_name", this.BankName);
            parameters.Add("bankcard_id", this.BankcardId);
            parameters.Add("bankcard_mobile", this.BankcardMobile);
            parameters.Add("bankcard_no", this.BankcardNo);
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
            RequestValidator.ValidateRequired("bank_code", this.BankCode);
            RequestValidator.ValidateRequired("bank_name", this.BankName);
            RequestValidator.ValidateRequired("bankcard_id", this.BankcardId);
            RequestValidator.ValidateRequired("bankcard_mobile", this.BankcardMobile);
            RequestValidator.ValidateRequired("bankcard_no", this.BankcardNo);
            RequestValidator.ValidateRequired("id_card_no", this.IdCardNo);
            RequestValidator.ValidateRequired("user_mobile", this.UserMobile);
        }

        #endregion
    }
}
