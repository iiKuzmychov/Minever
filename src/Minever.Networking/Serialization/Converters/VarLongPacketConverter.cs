﻿using Minever.Networking.IO;

namespace Minever.Networking.Serialization.Converters;

public class VarLongPacketConverter : PacketConverter<long>
{
    public override long Read(MinecraftReader reader)
    {
        ArgumentNullException.ThrowIfNull(reader);

        return reader.Read7BitEncodedInt64();
    }

    public override void Write(long value, MinecraftWriter writer)
    {
        ArgumentNullException.ThrowIfNull(writer);

        writer.Write7BitEncodedInt64(value);
    }
}