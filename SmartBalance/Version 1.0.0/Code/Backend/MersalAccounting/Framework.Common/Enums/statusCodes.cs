using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Enums
{
    public enum statusCodes
    {
        notFound=404,
        InvalidDate=406,
        InvalidValidation=407,
        InvalidPayment=402,
        InvalidAttribute=408,
        InvalidAmount=418,
        InvalidDescription=409,
        InvalidBranch=421,
        InvalidSource= 422,
        ItemAlreadyExsist=509
    }
}
