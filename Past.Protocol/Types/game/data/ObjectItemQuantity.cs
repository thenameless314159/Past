using System;
using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class ObjectItemQuantity : Item
    {
        public int objectUID;
        public int quantity;
        public new const short Id = 119;
        public override short TypeId
        {
            get { return Id; }
        }
        public ObjectItemQuantity()
        {
        }
        public ObjectItemQuantity(int objectUID, int quantity)
        {
            this.objectUID = objectUID;
            this.quantity = quantity;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(objectUID);
            writer.WriteInt(quantity);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
        }
    }
}
