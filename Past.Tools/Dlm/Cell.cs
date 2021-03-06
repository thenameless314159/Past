﻿using Past.Protocol.IO;
using Past.Tools.Dlm.Elements;

namespace Past.Tools.Dlm
{
    public class Cell
    {
        public short CellId { get; set; }
        public short ElementsCount { get; set; }
        public BasicElement[] Elements { get; set; }

        public Cell FromRaw(BigEndianReader raw)
        {
            Cell cell = new Cell();
            cell.CellId = raw.ReadShort();
            cell.ElementsCount = raw.ReadShort();
            cell.Elements = new BasicElement[cell.ElementsCount];
            for (int i = 0; i < cell.ElementsCount; i++)
            {
                BasicElement be = new BasicElement(cell);
                cell.Elements[i] = be.GetElementFromType(cell, raw);
            }
            return cell;
        }
    }
}
