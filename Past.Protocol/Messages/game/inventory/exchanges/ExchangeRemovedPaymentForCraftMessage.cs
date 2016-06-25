using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class ExchangeRemovedPaymentForCraftMessage : NetworkMessage
	{
        public bool onlySuccess;
        public int objectUID;
        public override uint Id
        {
        	get { return 6031; }
        }
        public ExchangeRemovedPaymentForCraftMessage()
        {
        }
        public ExchangeRemovedPaymentForCraftMessage(bool onlySuccess, int objectUID)
        {
            this.onlySuccess = onlySuccess;
            this.objectUID = objectUID;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(onlySuccess);
            writer.WriteInt(objectUID);
        }
        public override void Deserialize(IDataReader reader)
        {
            onlySuccess = reader.ReadBoolean();
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
		}
	}
}
