using Past.Protocol.IO;

namespace Past.Protocol.Types
{
    public class PaddockContentInformations : PaddockInformations
    {
        public int mapId;
        public MountInformationsForPaddock[] mountsInformations;
        public new const short Id = 183;
        public override short TypeId
        {
            get { return Id; }
        }
        public PaddockContentInformations()
        {
        }
        public PaddockContentInformations(short maxOutdoorMount, short maxItems, int mapId, MountInformationsForPaddock[] mountsInformations) : base(maxOutdoorMount, maxItems)
        {
            this.mapId = mapId;
            this.mountsInformations = mountsInformations;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(mapId);
            writer.WriteUShort((ushort)mountsInformations.Length);
            foreach (var entry in mountsInformations)
            {
                entry.Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            mapId = reader.ReadInt();
            var limit = reader.ReadUShort();
            mountsInformations = new Types.MountInformationsForPaddock[limit];
            for (int i = 0; i < limit; i++)
            {
                mountsInformations[i] = new MountInformationsForPaddock();
                mountsInformations[i].Deserialize(reader);
            }
        }
    }
}
    