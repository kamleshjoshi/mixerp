using MixERP.Net.Framework;

namespace PetaPoco
{
    public interface IDBAccess
    {
        bool HasAccess { get; }
        void Validate(AccessTypeEnum type, long loginId, bool noException);
    }
}