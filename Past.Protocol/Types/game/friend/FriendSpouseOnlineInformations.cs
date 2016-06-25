using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class FriendSpouseOnlineInformations : FriendSpouseInformations
    {
        public bool inFight;
        public bool followSpouse;
        public bool pvpEnabled;
        public int mapId;
        public short subAreaId;
        public string guildName;
        public sbyte alignmentSide;
        public new const short Id = 93;
        public override short TypeId
        {
            get { return Id; }
        }
        public FriendSpouseOnlineInformations()
        {
        }
        public FriendSpouseOnlineInformations(int spouseId, string spouseName, byte spouseLevel, sbyte breed, sbyte sex, EntityLook spouseEntityLook, bool inFight, bool followSpouse, bool pvpEnabled, int mapId, short subAreaId, string guildName, sbyte alignmentSide) : base(spouseId, spouseName, spouseLevel, breed, sex, spouseEntityLook)
        {
            this.inFight = inFight;
            this.followSpouse = followSpouse;
            this.pvpEnabled = pvpEnabled;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.guildName = guildName;
            this.alignmentSide = alignmentSide;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, inFight);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, followSpouse);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, pvpEnabled);
            writer.WriteByte(flag1);
            writer.WriteInt(mapId);
            writer.WriteShort(subAreaId);
            writer.WriteUTF(guildName);
            writer.WriteSByte(alignmentSide);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            inFight = BooleanByteWrapper.GetFlag(flag1, 0);
            followSpouse = BooleanByteWrapper.GetFlag(flag1, 1);
            pvpEnabled = BooleanByteWrapper.GetFlag(flag1, 2);
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            subAreaId = reader.ReadShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            guildName = reader.ReadUTF();
            alignmentSide = reader.ReadSByte();
        }
    }
}
