using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.finance.loan.contacts.add
    /// </summary>
    public class OapiFinanceLoanContactsAddRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiFinanceLoanContactsAddResponse>
    {
        /// <summary>
        /// 联系人手机号
        /// </summary>
        public string ContactMobile { get; set; }

        /// <summary>
        /// 钉钉客户唯一身份标识
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
        /// 联系人关系：配偶、父母、子女、朋友、同事、同学、其他家庭联系人、其他血亲、其他姻亲
        /// </summary>
        public string UserRelation { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.finance.loan.contacts.add";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
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
