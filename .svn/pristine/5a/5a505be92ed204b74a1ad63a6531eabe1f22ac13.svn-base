using MC.NetCore.DomainModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC.NetCore.ShopApp.Extension
{
    public static class OperationTypeExtensions
    {
        public static EnumOperationType ToEnumOperationType(this int value)
        {
            EnumOperationType retval = EnumOperationType.OnShelf;
            switch (value)
            {
                case 0:
                    retval = EnumOperationType.OnShelf;
                    break;
                case 1:
                    retval = EnumOperationType.Checkout;
                    break;
                case 2:
                    retval = EnumOperationType.OffShelf;
                    break;
                case 3:
                    retval = EnumOperationType.OffShelf;
                    break;
                default:
                    retval = EnumOperationType.UnKnown;
                    break;
            }
            return retval;
        }    

    }
}
