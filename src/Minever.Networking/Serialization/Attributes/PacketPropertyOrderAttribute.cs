﻿namespace Minever.Networking.Serialization.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class PacketPropertyOrderAttribute : Attribute
{
    public int Order { get; }

    public PacketPropertyOrderAttribute(int priority)
    {
        Order = priority;
    }
}