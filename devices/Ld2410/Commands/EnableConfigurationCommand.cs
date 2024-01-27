﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Ld2410.Commands
{
    internal sealed class EnableConfigurationCommand : CommandFrame
    {
        internal EnableConfigurationCommand()
            : base(CommandWord.EnableConfiguration)
        {
            Value = new byte[] { 0x01, 0x00 };
        }
    }
}
