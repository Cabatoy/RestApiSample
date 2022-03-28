using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EntitiesAndCore.Models.Dto.ResultDto;

namespace Entities.Core.Extension.Managers
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (result.Success != HttpStatusCode.OK || result.Success != HttpStatusCode.Accepted)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
