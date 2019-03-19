using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetCore.Rd.Data.Dto.Generic
{
    public class GenericResponseDto<TEntity> : GenericDto where TEntity : class
    {
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public object DataResponse { get; set; }

        public GenericResponseDto(GenericResponseType type, List<TEntity> collection = null, TEntity entity = null)
        {
            switch (type)
            {
                case GenericResponseType.DataCollection:
                    DataResponse = collection;
                    break;
                case GenericResponseType.DataEntity:
                    DataResponse = entity;
                    break;
                case GenericResponseType.Error:
                    DataResponse = null;
                    break;
                default:
                    break;
            }
        }
    }

    public enum GenericResponseType
    {
        DataCollection,
        DataEntity,
        Error
    }
}
