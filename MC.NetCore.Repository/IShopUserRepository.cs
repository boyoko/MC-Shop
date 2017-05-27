﻿using MC.NetCore.DomainModels.Dto;
using MC.NetCore.DomainModels.RequestDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MC.NetCore.Repository
{
    public interface IShopUserRepository
    {
        /// <summary>
        /// 获取配送员列表
        /// </summary>
        /// <returns></returns>
        Task<IList<DeliverDto>> GetDeliverList();
        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UserDto> LoginOn(LoginOnRequestDto request);
    }
}
