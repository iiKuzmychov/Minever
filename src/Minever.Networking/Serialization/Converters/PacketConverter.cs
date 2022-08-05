﻿using Minever.Networking.IO;

namespace Minever.Networking.Serialization.Converters;

public abstract class PacketConverter
{
    public abstract bool CanConvert(Type type);

    public abstract object Read(MinecraftReader reader, Type targetType);

    public abstract void Write(MinecraftWriter writer, object value);
}

public abstract class PacketConverter<T> : PacketConverter
    where T : notnull
{
    public override bool CanConvert(Type type)
    {
        if (type is null)
            throw new ArgumentNullException(nameof(type));

        return typeof(T) == type;
    }

    public abstract T Read(MinecraftReader reader);

    public abstract void Write(MinecraftWriter writer, T value);

    public sealed override object Read(MinecraftReader reader, Type targetType)
    {
        if (targetType is null)
            throw new ArgumentNullException(nameof(targetType));

        if (typeof(T) != targetType)
            throw new NotSupportedException("Converter does not support current value type.");

        return Read(reader);
    }

    public sealed override void Write(MinecraftWriter writer, object value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        if (writer is null)
            throw new ArgumentNullException(nameof(writer));

        Write(writer, (T)value);
    }

}
