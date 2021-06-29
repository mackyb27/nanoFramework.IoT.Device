﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Tests.CustomCode
{
    public class ElectricPotentialChangeRateTests : ElectricPotentialChangeRateTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;
        protected override double KilovoltsPerHoursInOneVoltPerSecond => 3.6;
        protected override double KilovoltsPerMicrosecondsInOneVoltPerSecond => 1e-09;
        protected override double KilovoltsPerMinutesInOneVoltPerSecond => 6e-2;
        protected override double KilovoltsPerSecondsInOneVoltPerSecond => 0.001;
        protected override double MegavoltsPerHoursInOneVoltPerSecond => 3.6e-3;
        protected override double MegavoltsPerMicrosecondsInOneVoltPerSecond => 1e-12;
        protected override double MegavoltsPerMinutesInOneVoltPerSecond => 6e-05;
        protected override double MegavoltsPerSecondsInOneVoltPerSecond => 1e-06;
        protected override double MicrovoltsPerHoursInOneVoltPerSecond => 3.6e9;
        protected override double MicrovoltsPerMicrosecondsInOneVoltPerSecond => 1;
        protected override double MicrovoltsPerMinutesInOneVoltPerSecond => 6e7;
        protected override double MicrovoltsPerSecondsInOneVoltPerSecond => 1e6;
        protected override double MillivoltsPerHoursInOneVoltPerSecond => 3.6e6;
        protected override double MillivoltsPerMicrosecondsInOneVoltPerSecond => 0.001;
        protected override double MillivoltsPerMinutesInOneVoltPerSecond => 6e4;
        protected override double MillivoltsPerSecondsInOneVoltPerSecond => 1000;
        protected override double VoltsPerHoursInOneVoltPerSecond => 3600;
        protected override double VoltsPerMicrosecondsInOneVoltPerSecond => 1e-06;
        protected override double VoltsPerMinutesInOneVoltPerSecond => 60;
        protected override double VoltsPerSecondsInOneVoltPerSecond => 1;
    }
}