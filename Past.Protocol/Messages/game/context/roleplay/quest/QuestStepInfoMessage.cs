using Past.Protocol.IO;
using Past.Protocol.Types;
using System;

namespace Past.Protocol.Messages
{
	public class QuestStepInfoMessage : NetworkMessage
	{
        public short questId;
        public short stepId;
        public short[] objectivesIds;
        public bool[] objectivesStatus;
        public override uint Id
        {
        	get { return 5625; }
        }
        public QuestStepInfoMessage()
        {
        }
        public QuestStepInfoMessage(short questId, short stepId, short[] objectivesIds, bool[] objectivesStatus)
        {
            this.questId = questId;
            this.stepId = stepId;
            this.objectivesIds = objectivesIds;
            this.objectivesStatus = objectivesStatus;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(questId);
            writer.WriteShort(stepId);
            writer.WriteUShort((ushort)objectivesIds.Length);
            foreach (var entry in objectivesIds)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort)objectivesStatus.Length);
            foreach (var entry in objectivesStatus)
            {
                 writer.WriteBoolean(entry);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            questId = reader.ReadShort();
            if (questId < 0)
                throw new Exception("Forbidden value on questId = " + questId + ", it doesn't respect the following condition : questId < 0");
            stepId = reader.ReadShort();
            if (stepId < 0)
                throw new Exception("Forbidden value on stepId = " + stepId + ", it doesn't respect the following condition : stepId < 0");
            var limit = reader.ReadUShort();
            objectivesIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectivesIds[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            objectivesStatus = new bool[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectivesStatus[i] = reader.ReadBoolean();
            }
		}
	}
}
