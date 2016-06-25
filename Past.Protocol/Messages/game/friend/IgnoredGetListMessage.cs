using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class IgnoredGetListMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5676; }
        }
        public IgnoredGetListMessage()
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
