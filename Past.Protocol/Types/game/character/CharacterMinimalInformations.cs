using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class CharacterMinimalInformations
    {
        public int id;
        public string name;
        public byte level;
        public const short Id = 110;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public CharacterMinimalInformations()
        {
        }
        public CharacterMinimalInformations(int id, string name, byte level)
        {
            this.id = id;
            this.name = name;
            this.level = level;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
            writer.WriteUTF(name);
            writer.WriteByte(level);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            name = reader.ReadUTF();
            level = reader.ReadByte();
            if (level < 1 || level > 200)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 1 || level > 200");
        }
    }
}