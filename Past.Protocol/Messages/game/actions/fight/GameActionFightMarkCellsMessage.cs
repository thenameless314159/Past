using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
	{
        public short markId;
        public sbyte markType;
        public GameActionMarkedCell[] cells;
        public override uint Id
        {
        	get { return 5540; }
        }
        public GameActionFightMarkCellsMessage()
        {
        }
        public GameActionFightMarkCellsMessage(short actionId, int sourceId, short markId, sbyte markType, GameActionMarkedCell[] cells) : base(actionId, sourceId)
        {
            this.markId = markId;
            this.markType = markType;
            this.cells = cells;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(markId);
            writer.WriteSByte(markType);
            writer.WriteUShort((ushort)cells.Length);
            foreach (var entry in cells)
            {
                 entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            markId = reader.ReadShort();
            markType = reader.ReadSByte();
            var limit = reader.ReadUShort();
            cells = new GameActionMarkedCell[limit];
            for (int i = 0; i < limit; i++)
            {
                 cells[i] = new GameActionMarkedCell();
                 cells[i].Deserialize(reader);
            }
		}
	}
}
