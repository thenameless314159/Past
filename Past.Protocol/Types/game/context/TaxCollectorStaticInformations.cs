using System;
using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class TaxCollectorStaticInformations
    {
        public short firstNameId;
        public short lastNameId;
        public GuildInformations guildIdentity;
        public const short Id = 147;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public TaxCollectorStaticInformations()
        {
        }
        public TaxCollectorStaticInformations(short firstNameId, short lastNameId, GuildInformations guildIdentity)
        {
            this.firstNameId = firstNameId;
            this.lastNameId = lastNameId;
            this.guildIdentity = guildIdentity;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(firstNameId);
            writer.WriteShort(lastNameId);
            guildIdentity.Serialize(writer);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            firstNameId = reader.ReadShort();
            if (firstNameId < 0)
                throw new Exception("Forbidden value on firstNameId = " + firstNameId + ", it doesn't respect the following condition : firstNameId < 0");
            lastNameId = reader.ReadShort();
            if (lastNameId < 0)
                throw new Exception("Forbidden value on lastNameId = " + lastNameId + ", it doesn't respect the following condition : lastNameId < 0");
            guildIdentity = new GuildInformations();
            guildIdentity.Deserialize(reader);
        }
    }
}
