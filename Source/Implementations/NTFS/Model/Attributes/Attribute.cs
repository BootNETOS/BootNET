using BootNET.Implementations.NTFS.Model.Enums;
using BootNET.Implementations.NTFS.Model.Headers;
using BootNET.Implementations.NTFS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace BootNET.Implementations.NTFS.Model.Attributes
{
    public abstract class Attribute : ISaveableObject
    {
        public AttributeType Type { get; set; }
        public ushort TotalLength { get; set; }
        public ResidentFlag NonResidentFlag { get; set; }
        public byte NameLength { get; set; }
        public ushort OffsetToName { get; set; }
        public AttributeFlags Flags { get; set; }
        public ushort Id { get; set; }

        public FileReference OwningRecord { get; set; }
        public string AttributeName { get; set; }

        public AttributeResidentHeader ResidentHeader { get; set; }
        public AttributeNonResidentHeader NonResidentHeader { get; set; }

        public abstract AttributeResidentAllow AllowedResidentStates { get; }

        public static AttributeType GetType(byte[] data, int offset)
        {
            // Debug.Assert(data.Length - offset >= 4);

            return (AttributeType)BitConverter.ToUInt32(data, offset);
        }

        public static ushort GetTotalLength(byte[] data, int offset)
        {
            // Debug.Assert(data.Length - offset + 4 >= 2);

            return BitConverter.ToUInt16(data, offset + 4);
        }

        private void ParseHeader(byte[] data, int offset)
        {
            // Debug.Assert(data.Length - offset >= 16);
            // Debug.Assert(0 <= offset && offset <= data.Length);

            Type = (AttributeType)BitConverter.ToUInt32(data, offset);

            if (Type == AttributeType.EndOfAttributes)
                return;

            TotalLength = BitConverter.ToUInt16(data, offset + 4);
            NonResidentFlag = (ResidentFlag)data[offset + 8];
            NameLength = data[offset + 9];
            OffsetToName = BitConverter.ToUInt16(data, offset + 10);
            Flags = (AttributeFlags)BitConverter.ToUInt16(data, offset + 12);
            Id = BitConverter.ToUInt16(data, offset + 14);

            if (NameLength == 0)
                AttributeName = string.Empty;
            else
                AttributeName = Encoding.Unicode.GetString(data, offset + OffsetToName, NameLength * 2);
        }

        internal virtual void ParseAttributeResidentBody(byte[] data, int maxLength, int offset)
        {
            // Debug.Assert(NonResidentFlag == ResidentFlag.Resident);
            // Debug.Assert((AllowedResidentStates & AttributeResidentAllow.Resident) != 0);

            // Debug.Assert(data.Length - offset >= maxLength);
            // Debug.Assert(0 <= offset && offset <= data.Length);
        }

        internal virtual void ParseAttributeNonResidentBody(Ntfs ntfsInfo)
        {
            // Debug.Assert(NonResidentFlag == ResidentFlag.NonResident);
            // Debug.Assert((AllowedResidentStates & AttributeResidentAllow.NonResident) != 0);
            // Debug.Assert(ntfsInfo != null);
        }

        public static Attribute ParseSingleAttribute(byte[] data, int maxLength, int offset = 0)
        {
            // Debug.Assert(data.Length - offset >= maxLength);
            // Debug.Assert(0 <= offset && offset <= data.Length);

            AttributeType type = GetType(data, offset);

            if (type == AttributeType.EndOfAttributes)
            {
                Attribute tmpRes = new AttributeGeneric();
                tmpRes.ParseHeader(data, offset);

                return tmpRes;
            }

            Attribute res = type switch
            {
                AttributeType.Unknown => new AttributeGeneric(),
                AttributeType.STANDARD_INFORMATION => new AttributeStandardInformation(),
                AttributeType.ATTRIBUTE_LIST => new AttributeList(),
                AttributeType.FILE_NAME => new AttributeFileName(),
                AttributeType.OBJECT_ID => new AttributeObjectId(),// Also OBJECT_ID
                                                                   // TODO: Handle either case
                AttributeType.SECURITY_DESCRIPTOR => new AttributeSecurityDescriptor(),
                AttributeType.VOLUME_NAME => new AttributeVolumeName(),
                AttributeType.VOLUME_INFORMATION => new AttributeVolumeInformation(),
                AttributeType.DATA => new AttributeData(),
                AttributeType.INDEX_ROOT => new AttributeIndexRoot(),
                AttributeType.INDEX_ALLOCATION => new AttributeIndexAllocation(),
                AttributeType.BITMAP => new AttributeBitmap(),
                AttributeType.REPARSE_POINT => new AttributeGeneric(),// TODO
                AttributeType.EA_INFORMATION => new AttributeExtendedAttributeInformation(),
                AttributeType.EA => new AttributeExtendedAttributes(),
                // Property set seems to be obsolete
                //case AttributeType.PROPERTY_SET:
                //    res = new MFTAttributeGeneric();
                //    break;
                AttributeType.LOGGED_UTILITY_STREAM => new AttributeLoggedUtilityStream(),
                _ => new AttributeGeneric(),// TODO
            };
            res.ParseHeader(data, offset);
            if (res.NonResidentFlag == ResidentFlag.Resident)
            {
                // Debug.Assert((res.AllowedResidentStates & AttributeResidentAllow.Resident) != 0);

                res.ResidentHeader = AttributeResidentHeader.ParseHeader(data, offset + 16);

                int bodyOffset = offset + res.ResidentHeader.ContentOffset;
                int length = offset + res.TotalLength - bodyOffset;

                // Debug.Assert(length >= res.ResidentHeader.ContentLength);
                // Debug.Assert(offset + maxLength >= bodyOffset + length);

                res.ParseAttributeResidentBody(data, length, bodyOffset);
            }
            else if (res.NonResidentFlag == ResidentFlag.NonResident)
            {
                // Debug.Assert((res.AllowedResidentStates & AttributeResidentAllow.NonResident) != 0);

                res.NonResidentHeader = AttributeNonResidentHeader.ParseHeader(data, offset + 16);

                int bodyOffset = offset + res.NonResidentHeader.ListOffset;
                int length = res.TotalLength - res.NonResidentHeader.ListOffset;

                // Debug.Assert(offset + maxLength >= bodyOffset + length);

                res.NonResidentHeader.Fragments = DataFragment.ParseFragments(data, length, bodyOffset, res.NonResidentHeader.StartingVCN, res.NonResidentHeader.EndingVCN);

                // Compact compressed fragments
                if (res.NonResidentHeader.CompressionUnitSize != 0)
                {
                    List<DataFragment> fragments = res.NonResidentHeader.Fragments;
                    DataFragment.CompactCompressedFragments(fragments);
                    res.NonResidentHeader.Fragments = fragments;
                }
            }
            else
            {
                throw new NotImplementedException("Couldn't process residentflag");
            }

            return res;
        }

        public virtual int GetSaveLength()
        {
            throw new NotImplementedException();

            if (Type == AttributeType.EndOfAttributes)
                return 4;

            int length = 16 + NameLength * 2;

            if (NonResidentFlag == ResidentFlag.NonResident)
            {
                length += NonResidentHeader.GetSaveLength();
            }
            else if (NonResidentFlag == ResidentFlag.Resident)
            {
                length += ResidentHeader.GetSaveLength();
            }

            return length;
        }

        public virtual void Save(byte[] buffer, int offset)
        {
            throw new NotImplementedException();

            // Debug.Assert(buffer.Length - offset >= GetSaveLength());
            // Debug.Assert(offset >= 0);

            LittleEndianConverter.GetBytes(buffer, offset, (uint)Type);

            if (Type == AttributeType.EndOfAttributes)
                return;

            LittleEndianConverter.GetBytes(buffer, offset + 4, TotalLength);
            LittleEndianConverter.GetBytes(buffer, offset + 8, (byte)NonResidentFlag);
            LittleEndianConverter.GetBytes(buffer, offset + 9, NameLength);
            LittleEndianConverter.GetBytes(buffer, offset + 10, OffsetToName);
            LittleEndianConverter.GetBytes(buffer, offset + 12, (ushort)Flags);
            LittleEndianConverter.GetBytes(buffer, offset + 14, Id);

            if (NameLength != 0)
            {
                byte[] stringData = Encoding.Unicode.GetBytes(AttributeName);

                // Debug.Assert(NameLength * 2 == stringData.Length);

                Array.Copy(stringData, 0, buffer, offset + OffsetToName, stringData.Length);
            }

            // Header
            if (NonResidentFlag == ResidentFlag.NonResident)
            {
                NonResidentHeader.Save(buffer, offset + 16);
            }
            else if (NonResidentFlag == ResidentFlag.Resident)
            {
                ResidentHeader.Save(buffer, offset + 16);
            }
        }
    }
}