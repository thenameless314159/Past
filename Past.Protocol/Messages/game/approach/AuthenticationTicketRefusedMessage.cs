using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class AuthenticationTicketRefusedMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 112; }
        }
        public AuthenticationTicketRefusedMessage()
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
