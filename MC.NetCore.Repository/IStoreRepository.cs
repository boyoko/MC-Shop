﻿using MC.NetCore.DomainModels.RequestDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MC.NetCore.Repository
{
    public interface IStoreRepository
    {
        /// <summary>
        /// 售卖后更新库存
        /// </summary>
        /// <returns></returns>
        Task<bool> UpdateStore(IList<StoreRequestDto> request);
    }
}
