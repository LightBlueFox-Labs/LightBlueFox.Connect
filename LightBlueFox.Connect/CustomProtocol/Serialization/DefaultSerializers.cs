﻿using System.Buffers.Binary;
using System.Text;

namespace LightBlueFox.Connect.CustomProtocol.Serialization
{
    /// <summary>
    /// A collection of serializers for primitives and common values that are added by default to every new <see cref="SerializationLibrary"/>.
    /// </summary>
    public static class DefaultSerializers
    {
        [AtomicDeserializer(sizeof(float))]
        public static float Float_Deserialize(ReadOnlyMemory<byte> buffer)
        {
            if (buffer.Length != sizeof(float)) throw new ArgumentException("Parsing a float requires exactly " + sizeof(float) + " bytes.");
            return BinaryPrimitives.ReadSingleLittleEndian(buffer.Span);
        }

        [AtomicSerializer(sizeof(float))]
        public static byte[] Float_Serialize(float f)
        {
            byte[] buff = new byte[sizeof(float)];
            BinaryPrimitives.WriteSingleLittleEndian(buff, f);
            return buff;
        }

        [AtomicDeserializer(sizeof(double))]
        public static double Double_Deserialize(ReadOnlyMemory<byte> buffer)
        {
            if (buffer.Length != sizeof(double)) throw new ArgumentException("Parsing a float requires exactly " + sizeof(float) + " bytes.");
            return BinaryPrimitives.ReadDoubleLittleEndian(buffer.Span);
        }

        [AtomicSerializer(sizeof(double))]
        public static byte[] Double_Serialize(double f)
        {
            byte[] buff = new byte[sizeof(double)];
            BinaryPrimitives.WriteDoubleLittleEndian(buff, f);
            return buff;
        }


        [AtomicDeserializer(sizeof(int))]
        public static int Int32_Deserialize(ReadOnlyMemory<byte> data)
        {
            if (data.Length != 4) throw new ArgumentException("Parsing an int32 requires exactly 4 bytes!");
            return BinaryPrimitives.ReadInt32LittleEndian(data.Span);
        }
        [AtomicSerializer(sizeof(int))]
        public static byte[] Int32_Serialize(int nr)
        {
            byte[] buff = new byte[sizeof(int)];
            BinaryPrimitives.WriteInt32LittleEndian(buff, nr);
            return buff;
        }

        [AtomicDeserializer(sizeof(uint))]
        public static uint UInt32_Deserialize(ReadOnlyMemory<byte> data)
        {
            if (data.Length != 4) throw new ArgumentException("Parsing an uint32 requires exactly 4 bytes!");
            return BinaryPrimitives.ReadUInt32LittleEndian(data.Span);
        }
        [AtomicSerializer(sizeof(uint))]
        public static byte[] UInt32_Serialize(uint nr)
        {
            byte[] buff = new byte[sizeof(int)];
            BinaryPrimitives.WriteUInt32LittleEndian(buff, nr);
            return buff;
        }

        [AtomicDeserializer(sizeof(byte))]
        public static byte Byte_Deserialize(ReadOnlyMemory<byte> data) => data.Span[0];
        [AtomicSerializer(sizeof(byte))]
        public static byte[] Byte_Serialize(byte b) => new byte[1] { b };

        [AtomicDeserializer(sizeof(long))]
        public static long Int64_Deserialize(ReadOnlyMemory<byte> data)
        {
            if (data.Length != sizeof(long)) throw new ArgumentException("Parsing an int32 requires exactly 4 bytes!");
            return BinaryPrimitives.ReadInt64LittleEndian(data.Span);
        }
        [AtomicSerializer(sizeof(long))]
        public static byte[] Int64_Serialize(long nr)
        {
            byte[] buff = new byte[sizeof(long)];
            BinaryPrimitives.WriteInt64LittleEndian(buff, nr);
            return buff;
        }

        [AtomicDeserializer(sizeof(ulong))]
        public static ulong UInt64_Deserialize(ReadOnlyMemory<byte> data)
        {
            if (data.Length != sizeof(ulong)) throw new ArgumentException("Parsing an int32 requires exactly 4 bytes!");
            return BinaryPrimitives.ReadUInt64LittleEndian(data.Span);
        }
        [AtomicSerializer(sizeof(ulong))]
        public static byte[] UInt64_Serialize(ulong nr)
        {
            byte[] buff = new byte[sizeof(ulong)];
            BinaryPrimitives.WriteUInt64LittleEndian(buff, nr);
            return buff;
        }

        [AtomicDeserializer]
        public static string Default_String_Deserialize(ReadOnlyMemory<byte> data)
        {
            return Encoding.UTF8.GetString(data.Span);
        }
        [AtomicSerializer]
        public static byte[] Default_String_Serialize(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        [AtomicDeserializer(1)]
        public static bool Bool_Deserialize(ReadOnlyMemory<byte> data)
        {
            return data.Span[0] != 0;
        }
        [AtomicSerializer(1)]
        public static byte[] Bool_Serialize(bool b) => new byte[1] { (byte)(b ? 1 : 0) };


        [AtomicDeserializer(sizeof(ulong) + sizeof(byte))]
        public static DateTime DateTime_Deserialize(ReadOnlyMemory<byte> data)
        {
            ulong ticks = UInt64_Deserialize(data.Slice(0, 4));
            int tz = 1;

            // Use native serialization functionallity? 
            throw new NotImplementedException();
        }

        [AtomicSerializer(sizeof(ulong) + sizeof(byte))]
        public static byte[] DateTime_Deserialize(DateTime t)
        {
            throw new NotImplementedException();
        }
    }
}
