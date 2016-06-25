using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class GameFightMonsterInformations : GameFightAIInformations
    {
        public short creatureGenericId;
        public sbyte creatureGrade;
        public new const short Id = 29;
        public override short TypeId
        {
            get { return Id; }
        }
        public GameFightMonsterInformations()
        {
        }
        public GameFightMonsterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats, short creatureGenericId, sbyte creatureGrade): base(contextualId, look, disposition, teamId, alive, stats)
        {
            this.creatureGenericId = creatureGenericId;
            this.creatureGrade = creatureGrade;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(creatureGenericId);
            writer.WriteSByte(creatureGrade);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            creatureGenericId = reader.ReadShort();
            if (creatureGenericId < 0)
                throw new Exception("Forbidden value on creatureGenericId = " + creatureGenericId + ", it doesn't respect the following condition : creatureGenericId < 0");
            creatureGrade = reader.ReadSByte();
            if (creatureGrade < 0)
                throw new Exception("Forbidden value on creatureGrade = " + creatureGrade + ", it doesn't respect the following condition : creatureGrade < 0");
        }
    }
}
