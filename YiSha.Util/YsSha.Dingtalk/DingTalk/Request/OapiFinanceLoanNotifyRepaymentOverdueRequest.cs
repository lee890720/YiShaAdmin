using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.finance.loan.notify.repayment.overdue
    /// </summary>
    public class OapiFinanceLoanNotifyRepaymentOverdueRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiFinanceLoanNotifyRepaymentOverdueResponse>
    {
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 借据编号：还款对应的借据编号
        /// </summary>
        public string LoanOrderNo { get; set; }

        /// <summary>
        /// 渠道方名称
        /// </summary>
        public string OpenChannelName { get; set; }

        /// <summary>
        /// 渠道方产品名称
        /// </summary>
        public string OpenProductName { get; set; }

        /// <summary>
        /// 本次还款时逾期期数(不包括已经还逾期的，没有则为0)：如1,2=第1期+第2期都逾期
        /// </summary>
        public string OvdTerms { get; set; }

        /// <summary>
        /// 本次还款利息(单位：分)
        /// </summary>
        public Nullable<long> PaidInterest { get; set; }

        /// <summary>
        /// 本次还款罚息(单位：分)
        /// </summary>
        public Nullable<long> PaidPenalty { get; set; }

        /// <summary>
        /// 本次还款本金(单位：分)
        /// </summary>
        public Nullable<long> PaidPrincipal { get; set; }

        /// <summary>
        /// 本次还款总金额(单位：分)：本次逾期本金+本次逾期利息+本次逾期罚息
        /// </summary>
        public Nullable<long> PaidTotalAmount { get; set; }

        /// <summary>
        /// 本次还款日期
        /// </summary>
        public string RepayRealDate { get; set; }

        /// <summary>
        /// 还款期数：如1,2=第1期+第2期
        /// </summary>
        public string RepaymentTerms { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string UserMobile { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.finance.loan.notify.repayment.overdue";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("id_card_no", this.IdCardNo);
            parameters.Add("loan_order_no", this.LoanOrderNo);
            parameters.Add("open_channel_name", this.OpenChannelName);
            parameters.Add("open_product_name", this.OpenProductName);
            parameters.Add("ovd_terms", this.OvdTerms);
            parameters.Add("paid_interest", this.PaidInterest);
            parameters.Add("paid_penalty", this.PaidPenalty);
            parameters.Add("paid_principal", this.PaidPrincipal);
            parameters.Add("paid_total_amount", this.PaidTotalAmount);
            parameters.Add("repay_real_date", this.RepayRealDate);
            parameters.Add("repayment_terms", this.RepaymentTerms);
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
            RequestValidator.ValidateRequired("loan_order_no", this.LoanOrderNo);
            RequestValidator.ValidateRequired("open_channel_name", this.OpenChannelName);
            RequestValidator.ValidateRequired("open_product_name", this.OpenProductName);
            RequestValidator.ValidateRequired("ovd_terms", this.OvdTerms);
            RequestValidator.ValidateRequired("paid_interest", this.PaidInterest);
            RequestValidator.ValidateRequired("paid_penalty", this.PaidPenalty);
            RequestValidator.ValidateRequired("paid_principal", this.PaidPrincipal);
            RequestValidator.ValidateRequired("paid_total_amount", this.PaidTotalAmount);
            RequestValidator.ValidateRequired("repay_real_date", this.RepayRealDate);
            RequestValidator.ValidateRequired("repayment_terms", this.RepaymentTerms);
            RequestValidator.ValidateRequired("user_mobile", this.UserMobile);
        }

        #endregion
    }
}
