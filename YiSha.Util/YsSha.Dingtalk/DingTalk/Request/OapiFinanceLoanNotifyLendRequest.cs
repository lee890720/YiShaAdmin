using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.finance.loan.notify.lend
    /// </summary>
    public class OapiFinanceLoanNotifyLendRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiFinanceLoanNotifyLendResponse>
    {
        /// <summary>
        /// 授信总额度(单位：分)
        /// </summary>
        public string AvailableAmount { get; set; }

        /// <summary>
        /// 剩余可用/可借额度(单位：分)
        /// </summary>
        public Nullable<long> AvailableLimit { get; set; }

        /// <summary>
        /// 收款银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 收款银行卡号
        /// </summary>
        public string BankcardNo { get; set; }

        /// <summary>
        /// 每月账单日，如每月3号
        /// </summary>
        public Nullable<long> BillDate { get; set; }

        /// <summary>
        /// 账单分期期次信息，借款失败时传空数组
        /// </summary>
        public string BillInfoList { get; set; }

        public List<BillInfoDomain> BillInfoList_ { set { this.BillInfoList = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 日利率(精确4位小数，百分之*)
        /// </summary>
        public string DailyInterestRate { get; set; }

        /// <summary>
        /// 优惠券id：不存在传0，多个使用,分隔
        /// </summary>
        public string DiscountsId { get; set; }

        /// <summary>
        /// 放款失败原因：失败时值不能为空（尽可能详细）
        /// </summary>
        public string FailReason { get; set; }

        /// <summary>
        /// 首期账单日：与每月账单日相同可不传
        /// </summary>
        public string FirstBillDate { get; set; }

        /// <summary>
        /// 首期还款日：与每月还款日相同可不传
        /// </summary>
        public string FirstRepayDate { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 最后还款日
        /// </summary>
        public string LastRepayDate { get; set; }

        /// <summary>
        /// 借款/支用金额(单位：分)
        /// </summary>
        public Nullable<long> LoanAmount { get; set; }

        /// <summary>
        /// 借据生效时间（成功）：用户支用金额申请/提交后，行方审核完成时间
        /// </summary>
        public string LoanEffectiveTime { get; set; }

        /// <summary>
        /// 结清日期：最后一期(逾期)还款成功完成/结束时间
        /// </summary>
        public string LoanEndTime { get; set; }

        /// <summary>
        /// 借据流水号：没有传0
        /// </summary>
        public string LoanOrderFlowNo { get; set; }

        /// <summary>
        /// 借据编号
        /// </summary>
        public string LoanOrderNo { get; set; }

        /// <summary>
        /// 分期申请提交时间：用户支用金额申请/提交时间
        /// </summary>
        public string LoanSubmitTime { get; set; }

        /// <summary>
        /// 入账成功(打款到用户银行卡)时间：用户支用金额申请/提交后&行方审核通过后向用户银行卡打款时间
        /// </summary>
        public string LoanTxnTime { get; set; }

        /// <summary>
        /// 借款用途
        /// </summary>
        public string LoanUsage { get; set; }

        /// <summary>
        /// 渠道方名称
        /// </summary>
        public string OpenChannelName { get; set; }

        /// <summary>
        /// 渠道方产品码
        /// </summary>
        public string OpenProductCode { get; set; }

        /// <summary>
        /// 渠道方产品名称
        /// </summary>
        public string OpenProductName { get; set; }

        /// <summary>
        /// 渠道方产品类型
        /// </summary>
        public string OpenProductType { get; set; }

        /// <summary>
        /// 应还利息(单位：分)
        /// </summary>
        public Nullable<long> PayableInterest { get; set; }

        /// <summary>
        /// 应还本金(单位：分)
        /// </summary>
        public Nullable<long> PayablePrincipal { get; set; }

        /// <summary>
        /// 应还总金额(单位：分)：应还本金+应还利息+应还罚息
        /// </summary>
        public Nullable<long> PayableTotalAmount { get; set; }

        /// <summary>
        /// 优惠券减免金额(单位：分)：不存在传0
        /// </summary>
        public Nullable<long> ReductionTotalAmount { get; set; }

        /// <summary>
        /// 每月还款日，如每月5号
        /// </summary>
        public Nullable<long> RepayDate { get; set; }

        /// <summary>
        /// 还款方式：RMT00 等额本息，RMT01 先息后本
        /// </summary>
        public string RepayType { get; set; }

        /// <summary>
        /// 状态：FAILED 审核不通过/支用失败，NORMAL 银行审核通过/支用成功/放款中，OVERDUE 逾期，CLEAR 结清，WRITEOFF 核销
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 分期总期数
        /// </summary>
        public Nullable<long> TotalTerm { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string UserMobile { get; set; }

        /// <summary>
        /// 年利率(精确2位小数，百分之*)
        /// </summary>
        public string YearLoanInterestRate { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.finance.loan.notify.lend";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("available_amount", this.AvailableAmount);
            parameters.Add("available_limit", this.AvailableLimit);
            parameters.Add("bank_name", this.BankName);
            parameters.Add("bankcard_no", this.BankcardNo);
            parameters.Add("bill_date", this.BillDate);
            parameters.Add("bill_info_list", this.BillInfoList);
            parameters.Add("daily_interest_rate", this.DailyInterestRate);
            parameters.Add("discounts_id", this.DiscountsId);
            parameters.Add("fail_reason", this.FailReason);
            parameters.Add("first_bill_date", this.FirstBillDate);
            parameters.Add("first_repay_date", this.FirstRepayDate);
            parameters.Add("id_card_no", this.IdCardNo);
            parameters.Add("last_repay_date", this.LastRepayDate);
            parameters.Add("loan_amount", this.LoanAmount);
            parameters.Add("loan_effective_time", this.LoanEffectiveTime);
            parameters.Add("loan_end_time", this.LoanEndTime);
            parameters.Add("loan_order_flow_no", this.LoanOrderFlowNo);
            parameters.Add("loan_order_no", this.LoanOrderNo);
            parameters.Add("loan_submit_time", this.LoanSubmitTime);
            parameters.Add("loan_txn_time", this.LoanTxnTime);
            parameters.Add("loan_usage", this.LoanUsage);
            parameters.Add("open_channel_name", this.OpenChannelName);
            parameters.Add("open_product_code", this.OpenProductCode);
            parameters.Add("open_product_name", this.OpenProductName);
            parameters.Add("open_product_type", this.OpenProductType);
            parameters.Add("payable_interest", this.PayableInterest);
            parameters.Add("payable_principal", this.PayablePrincipal);
            parameters.Add("payable_total_amount", this.PayableTotalAmount);
            parameters.Add("reduction_total_amount", this.ReductionTotalAmount);
            parameters.Add("repay_date", this.RepayDate);
            parameters.Add("repay_type", this.RepayType);
            parameters.Add("status", this.Status);
            parameters.Add("total_term", this.TotalTerm);
            parameters.Add("user_mobile", this.UserMobile);
            parameters.Add("year_loan_interest_rate", this.YearLoanInterestRate);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("available_amount", this.AvailableAmount);
            RequestValidator.ValidateRequired("available_limit", this.AvailableLimit);
            RequestValidator.ValidateRequired("bank_name", this.BankName);
            RequestValidator.ValidateRequired("bankcard_no", this.BankcardNo);
            RequestValidator.ValidateRequired("bill_date", this.BillDate);
            RequestValidator.ValidateRequired("bill_info_list", this.BillInfoList);
            RequestValidator.ValidateObjectMaxListSize("bill_info_list", this.BillInfoList, 360);
            RequestValidator.ValidateRequired("daily_interest_rate", this.DailyInterestRate);
            RequestValidator.ValidateRequired("discounts_id", this.DiscountsId);
            RequestValidator.ValidateRequired("fail_reason", this.FailReason);
            RequestValidator.ValidateRequired("first_bill_date", this.FirstBillDate);
            RequestValidator.ValidateRequired("first_repay_date", this.FirstRepayDate);
            RequestValidator.ValidateRequired("id_card_no", this.IdCardNo);
            RequestValidator.ValidateRequired("last_repay_date", this.LastRepayDate);
            RequestValidator.ValidateRequired("loan_amount", this.LoanAmount);
            RequestValidator.ValidateRequired("loan_effective_time", this.LoanEffectiveTime);
            RequestValidator.ValidateRequired("loan_end_time", this.LoanEndTime);
            RequestValidator.ValidateRequired("loan_order_flow_no", this.LoanOrderFlowNo);
            RequestValidator.ValidateRequired("loan_order_no", this.LoanOrderNo);
            RequestValidator.ValidateRequired("loan_submit_time", this.LoanSubmitTime);
            RequestValidator.ValidateRequired("loan_txn_time", this.LoanTxnTime);
            RequestValidator.ValidateRequired("loan_usage", this.LoanUsage);
            RequestValidator.ValidateRequired("open_channel_name", this.OpenChannelName);
            RequestValidator.ValidateRequired("open_product_code", this.OpenProductCode);
            RequestValidator.ValidateRequired("open_product_name", this.OpenProductName);
            RequestValidator.ValidateRequired("open_product_type", this.OpenProductType);
            RequestValidator.ValidateRequired("payable_interest", this.PayableInterest);
            RequestValidator.ValidateRequired("payable_principal", this.PayablePrincipal);
            RequestValidator.ValidateRequired("payable_total_amount", this.PayableTotalAmount);
            RequestValidator.ValidateRequired("reduction_total_amount", this.ReductionTotalAmount);
            RequestValidator.ValidateRequired("repay_date", this.RepayDate);
            RequestValidator.ValidateRequired("repay_type", this.RepayType);
            RequestValidator.ValidateRequired("status", this.Status);
            RequestValidator.ValidateRequired("total_term", this.TotalTerm);
            RequestValidator.ValidateRequired("user_mobile", this.UserMobile);
            RequestValidator.ValidateRequired("year_loan_interest_rate", this.YearLoanInterestRate);
        }

	/// <summary>
/// BillInfoDomain Data Structure.
/// </summary>
[Serializable]

public class BillInfoDomain : TopObject
{
	        /// <summary>
	        /// 本期账单日，样例
	        /// </summary>
	        [XmlElement("bill_date")]
	        public string BillDate { get; set; }
	
	        /// <summary>
	        /// 应还利息(单位：分)
	        /// </summary>
	        [XmlElement("payable_interest")]
	        public Nullable<long> PayableInterest { get; set; }
	
	        /// <summary>
	        /// 应还本金(单位：分)
	        /// </summary>
	        [XmlElement("payable_principal")]
	        public Nullable<long> PayablePrincipal { get; set; }
	
	        /// <summary>
	        /// 应还总金额(单位：分)：应还本金+应还利息+应还罚息
	        /// </summary>
	        [XmlElement("payable_total_amount")]
	        public Nullable<long> PayableTotalAmount { get; set; }
	
	        /// <summary>
	        /// 本期还款日，如每月5号
	        /// </summary>
	        [XmlElement("repay_date")]
	        public string RepayDate { get; set; }
	
	        /// <summary>
	        /// 本期还款状态：INIT 未还款、PAID 已还清、OVERDUE 已逾期，样例：INIT
	        /// </summary>
	        [XmlElement("status")]
	        public string Status { get; set; }
	
	        /// <summary>
	        /// 本期期次：2=第2期
	        /// </summary>
	        [XmlElement("terms")]
	        public string Terms { get; set; }
}

        #endregion
    }
}
