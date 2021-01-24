using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.im.chat.scencegroup.interactivecard.callback.register
    /// </summary>
    public class OapiImChatScencegroupInteractivecardCallbackRegisterRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiImChatScencegroupInteractivecardCallbackRegisterResponse>
    {
        /// <summary>
        /// 加密密钥用于校验来源
        /// </summary>
        public string ApiSecret { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallbackUrl { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.im.chat.scencegroup.interactivecard.callback.register";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("api_secret", this.ApiSecret);
            parameters.Add("callback_url", this.CallbackUrl);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("callback_url", this.CallbackUrl);
        }

        #endregion
    }
}
