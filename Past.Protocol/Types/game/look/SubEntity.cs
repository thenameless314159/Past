using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class SubEntity
    {
        public sbyte bindingPointCategory;
        public sbyte bindingPointIndex;
        public EntityLook subEntityLook;
        public const short Id = 54;
        public virtual short TypeId
        {
            get { return Id; }
        }
        public SubEntity()
        {
        }
        public SubEntity(sbyte bindingPointCategory, sbyte bindingPointIndex, EntityLook subEntityLook)
        {
            this.bindingPointCategory = bindingPointCategory;
            this.bindingPointIndex = bindingPointIndex;
            this.subEntityLook = subEntityLook;
        }
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(bindingPointCategory);
            writer.WriteSByte(bindingPointIndex);
            subEntityLook.Serialize(writer);
        }
        public virtual void Deserialize(IDataReader reader)
        {
            bindingPointCategory = reader.ReadSByte();
            if (bindingPointCategory < 0)
                throw new Exception("Forbidden value on bindingPointCategory = " + bindingPointCategory + ", it doesn't respect the following condition : bindingPointCategory < 0");
            bindingPointIndex = reader.ReadSByte();
            if (bindingPointIndex < 0)
                throw new Exception("Forbidden value on bindingPointIndex = " + bindingPointIndex + ", it doesn't respect the following condition : bindingPointIndex < 0");
            subEntityLook = new EntityLook();
            subEntityLook.Deserialize(reader);
        }
    }
}