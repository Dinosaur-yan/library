﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Library.API.Configurations
{
    public static class AuthenticationConfig
    {
        /**
         * 认证（Authentication）：验证用户身份的过程
         * 1. Basic认证：将用户名、密码以冒号分割，并对组合后的字符串进行Base64编码
         * 2. Digest认证（摘要认证）：客户端根据服务器返回的nonce值、用户的认证信息、请求的URL、使用的http方法以MD5散列值算法计算得到
         * 3. Bearer认证：主要用在OAuth2.0认证，还广泛应用在常见的基于token的认证中
         * 
         * 
         * 授权（Authorization）：验证一个用户是否有权限做某事的过程
         * 基础角色的授权、基于Claim的授权、基于策略的授权
         */
        public static void AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var tokenSection = configuration.GetSection("Security:Token");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                #region 认证

                // jwt(json web token)是一个开放标准（RFC7519），由三部分组成：头部（header）、负载（payload）、签名（signature），各部分之间以.分割
                // 典型的格式为：header.payload.signature
                // 负载部分包括要传输的信息，通常由多个claim构成；claim有3种类型：已注册、公共、私有
                // 已注册：
                //      iss     Issue               签发者
                //      sub     Subject             主题
                //      aud     Audience            接收方
                //      exp     Expiration time     过期时间
                //      nbf     Not before          JWT有效的开始时间
                //      iat     Issue at            签发JWT时的时间
                //      jti     JWT ID              JWT的唯一标识符
                // 公共的：
                //      常见的如name、email、garden
                //      这一类的claim通常都已经在互联网数字分配机构（Internet Assigned Numbers Authority, IANA） json web token claims中注册
                // 私有的：
                //      自定义，信息发送方与接收方约定好的claim

                #endregion

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenSection["Issuer"],    //合法的签发这
                    ValidAudience = tokenSection["Audience"],   //合法的接收方
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSection["Key"])),   //用于指定进行签名验证的安全密钥
                    ClockSkew = TimeSpan.Zero,   //验证时间的时间偏移值
                };
            });
        }
    }
}
