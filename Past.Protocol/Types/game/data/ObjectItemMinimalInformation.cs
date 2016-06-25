using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class ObjectItemMinimalInformation : Item
    {
        public short objectGID;
        public ObjectEffect[] effects;
        public new const short Id = 124;
        public override short TypeId
        {
            get { return Id; }
        }
        public ObjectItemMinimalInformation()
        {
        }
        public ObjectItemMinimalInformation(short objectGID, ObjectEffect[] effects)
        {
            this.objectGID = objectGID;
            this.effects = effects;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(objectGID);
            writer.WriteUShort((ushort)effects.Length);
            foreach (var entry in effects)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            objectGID = reader.ReadShort();
            if (objectGID < 0)
                throw new Exception("Forbidden value on objectGID = " + objectGID + ", it doesn't respect the following condition : objectGID < 0");
            var limit = reader.ReadUShort();
            effects = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                effects[i] = (ObjectEffect)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                effects[i].Deserialize(reader);
            }
        }
    }
}
