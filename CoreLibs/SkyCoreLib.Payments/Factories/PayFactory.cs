﻿using System;
using SkyCoreLib.Payments.Alipay.Abstractions;
using SkyCoreLib.Payments.Alipay.Configs;
using SkyCoreLib.Payments.Alipay.Services;
using SkyCoreLib.Payments.Core;
using SkyCoreLib.Payments.Wechatpay.Abstractions;
using SkyCoreLib.Payments.Wechatpay.Configs;
using SkyCoreLib.Payments.Wechatpay.Services;

namespace SkyCoreLib.Payments.Factories {
    /// <summary>
    /// 支付工厂
    /// </summary>
    public class PayFactory : IPayFactory {
        /// <summary>
        /// 支付宝配置提供器
        /// </summary>
        private readonly IAlipayConfigProvider _alipayConfigProvider;
        /// <summary>
        /// 微信支付配置提供器
        /// </summary>
        private readonly IWechatpayConfigProvider _wechatpayConfigProvider;

        /// <summary>
        /// 初始化支付工厂
        /// </summary>
        /// <param name="alipayConfigProvider">支付宝配置提供器</param>
        /// <param name="wechatpayConfigProvider">微信支付配置提供器</param>
        public PayFactory( IAlipayConfigProvider alipayConfigProvider, IWechatpayConfigProvider wechatpayConfigProvider ) {
            _alipayConfigProvider = alipayConfigProvider;
            _wechatpayConfigProvider = wechatpayConfigProvider;
        }

        /// <summary>
        /// 创建支付服务
        /// </summary>
        /// <param name="way">支付方式</param>
        public IPayService CreatePayService( PayWay way ) {
            switch( way ) {
                case PayWay.AlipayBarcodePay:
                    return new AlipayBarcodePayService( _alipayConfigProvider );
                case PayWay.AlipayQrCodePay:
                    return new AlipayQrCodePayService( _alipayConfigProvider );
                case PayWay.AlipayPagePay:
                    return new AlipayPagePayService( _alipayConfigProvider );
                case PayWay.AlipayWapPay:
                    return new AlipayWapPayService( _alipayConfigProvider );
                case PayWay.AlipayAppPay:
                    return new AlipayAppPayService( _alipayConfigProvider );
                case PayWay.WechatpayAppPay:
                    return new WechatpayAppPayService( _wechatpayConfigProvider );
                case PayWay.WechatpayMiniProgramPay:
                    return new WechatpayMiniProgramPayService( _wechatpayConfigProvider );
            }
            throw new NotImplementedException( way.Description() );
        }

        /// <summary>
        /// 创建支付宝回调通知服务
        /// </summary>
        public IAlipayNotifyService CreateAlipayNotifyService() {
            return new AlipayNotifyService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝返回服务
        /// </summary>
        public IAlipayReturnService CreateAlipayReturnService() {
            return new AlipayReturnService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝条码支付服务
        /// </summary>
        public IAlipayBarcodePayService CreateAlipayBarcodePayService() {
            return new AlipayBarcodePayService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝二维码支付服务
        /// </summary>
        public IAlipayQrCodePayService CreateAlipayQrCodePayService() {
            return new AlipayQrCodePayService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝电脑网站支付服务
        /// </summary>
        public IAlipayPagePayService CreateAlipayPagePayService() {
            return new AlipayPagePayService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝手机网站支付服务
        /// </summary>
        public IAlipayWapPayService CreateAlipayWapPayService() {
            return new AlipayWapPayService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝App支付服务
        /// </summary>
        public IAlipayAppPayService CreateAlipayAppPayService() {
            return new AlipayAppPayService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建微信回调通知服务
        /// </summary>
        public IWechatpayNotifyService CreateWechatpayNotifyService() {
            return new WechatpayNotifyService( _wechatpayConfigProvider );
        }

        /// <summary>
        /// 创建微信App支付服务
        /// </summary>
        public IWechatpayAppPayService CreateWechatpayAppPayService() {
            return new WechatpayAppPayService( _wechatpayConfigProvider );
        }

        /// <summary>
        /// 创建微信小程序支付服务
        /// </summary>
        public IWechatpayMiniProgramPayService CreateWechatpayMiniProgramPayService() {
            return new WechatpayMiniProgramPayService( _wechatpayConfigProvider );
        }
    }
}

