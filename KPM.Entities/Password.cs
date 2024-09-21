using KARA.NET.Entities;
using System;

namespace KPM.Entities;
public class Password
    : AbstractEntity<Guid>
{
    public string Name { get; set; }
    public byte[] Value { get; set; }
}