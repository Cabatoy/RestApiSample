using System.Net;
using EntitiesAndCore.Models.Dto.ResultDto;

namespace EntitiesAndCore.Core.Extension.Tools
{
    public static class BusinessRules
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
