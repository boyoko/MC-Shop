using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public interface IBaseResponseDto
    {
        int? StatusCode { get; set; }
        string ErrorMessage { get; set; }
        //T ObjectValue{get;set;}
    }
}
