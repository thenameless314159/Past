using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AlreadyConnectedMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 109; }
        }
        public AlreadyConnectedMessage()
        {
        }
        public override void Serialize(IDataWriter writer)
        {
        }
        public override void Deserialize(IDataReader reader)
        {
		}
	}
}
