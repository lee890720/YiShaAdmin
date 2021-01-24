using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.finance.loan.contacts.delete
    /// </summary>
    public class OapiFinanceLoanContactsDeleteRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiFinanceLoanContactsDeleteResponse>
    {
        /// <summary>
        /// 联系人id
        /// </summary>
        public Nullable<long> ContactId { get; set; }

        /// <summary>
        /// 联系人手机号
        /// </summary>
        public string ContactMobile { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 联系人职业
        /// </summary>
        public string UserCategory { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string UserMobile { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 联系人关系
        /// </summary>
        public string UserRelation { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.finance.loan.contacts.delete";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("contact_id", this.ContactId);
            parameters.Add("contact_mobile", this.ContactMobile);
            parameters.Add("id_card_no", this.IdCardNo);
            parameters.Add("user_category", this.UserCategory);
            parameters.Add("user_mobile", this.UserMobile);
            parameters.Add("user_name", this.UserName);
            parameters.Add("user_relation", this.UserRelation);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("contact_id", this.ContactId);
            RequestValidator.ValidateRequired("contact_mobile", this.ContactMobile);
            RequestValidator.ValidateRequired("id_card_no", this.IdCardNo);
            RequestValidator.ValidateRequired("user_category", this.UserCategory);
            RequestValidator.ValidateRequired("user_mobile", this.UserMobile);
            RequestValidator.ValidateRequired("user_name", this.UserName);
            RequestValidator.ValidateRequired("user_relation", this.UserRelation);
        }

        #endregion
    }
}
