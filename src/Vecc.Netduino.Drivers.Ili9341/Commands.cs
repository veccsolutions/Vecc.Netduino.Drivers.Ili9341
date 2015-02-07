namespace Vecc.Netduino.Drivers.Ili9341
{
    public enum Commands
    {
        NoOp = 0x00,
        /// <summary>
        /// <para>
        ///     When the Software Reset command is written, it causes a software reset. It resets the commands and parameters to their
        ///     S/W Reset default values. (See default tables in each command description.)
        /// </para>
        /// <para>
        ///     Note: The Frame Memory contents are unaffected by this command
        /// </para>
        /// <para>
        /// It will be necessary to wait 5msec before sending new command following software reset. The display module loads all display
        /// supplier factory default values to the registers during this 5msec. If Software Reset is applied during Sleep Out mode, it will be
        /// necessary to wait 120msec before sending Sleep out command. Software Reset Command cannot be sent during Sleep Out
        /// sequence
        /// </para>
        /// </summary>
        SoftwareReset = 0x01,
        ReadDisplayInformation = 0x04,
        ReadDisplayStatus = 0x09,
        ReadDisplayPowerMode = 0x0A,
        ReadDisplayMADCTL = 0x0B,
        ReadDisplayPixelFormat = 0x0C,
        ReadDisplayImageFormat = 0x0D,
        ReadDisplaySignalMode = 0x0E,
        ReadDisplaySelfDiagnosticResult = 0x0F,
        /// <summary>
        /// <para>This command causes the LCD module to enter the minimum power consumption mode.</para>
        /// <para>In this mode e.g. the DC/DC converter is stopped, Internal oscillator is stopped, and panel scanning is stopped.</para>
        /// <para>MCU interface and memory are still working and the memory keeps its contents. </para>
        /// </summary>
        /// <remarks>
        /// This command has no effect when module is already in sleep in mode. Sleep In Mode can only be left by the Sleep Out
        /// Command (11h). It will be necessary to wait 5msec before sending next to command, this is to allow time for the supply
        /// voltages and clock circuits to stabilize. It will be necessary to wait 120msec after sending Sleep Out command (when in Sleep
        /// In Mode) before Sleep In command can be sent
        /// </remarks>
        EnterSleepMode = 0x10,
        /// <summary>
        /// This command turns off sleep mode.
        /// In this mode e.g. the DC/DC converter is enabled, Internal oscillator is started, and panel scanning is started.
        /// </summary>
        /// <remarks>
        /// This command has no effect when module is already in sleep out mode. Sleep Out Mode can only be left by the Sleep In
        /// Command (10h). It will be necessary to wait 5msec before sending next command, this is to allow time for the supply voltages
        /// and clock circuits stabilize. The display module loads all display supplier’s factory default values to the registers during this
        /// 5msec and there cannot be any abnormal visual effect on the display image if factory default and register values are same
        /// when this load is done and when the display module is already Sleep Out –mode. The display module is doing self-diagnostic
        /// functions during this 5msec. It will be necessary to wait 120msec after sending Sleep In command (when in Sleep Out mode)
        /// before Sleep Out command can be sent.
        /// </remarks>
        SleepOut = 0x11,
        PartialModeOn = 0x12,
        NormalDisplayModeOn = 0x13,
        DisplayInversionOff = 0x20,
        DisplayInversionOn = 0x21,
        GammaSet = 0x26,
        DisplayOff = 0x28,
        DisplayOn = 0x29,
        ColumnAddressSet = 0x2A,
        PageAddressSet = 0x2B,
        MemoryWrite = 0x2C,
        ColorSet = 0x2D,
        MemoryRead = 0x2E,
        ParialArea = 0x30,
        VerticalScrollingDefinition = 0x33,
        TearingEffectLineOff = 0x34,
        TearingEffectLineOn = 0x35,
        MemoryAccessControl = 0x36,
        VerticalScrollingStartAddress = 0x37,
        IdleModeOff = 0x38,
        IdleModeOn = 0x39,
        PixelFormatSet = 0x3A,
        WriteMemoryContinue = 0x3C,
        ReadMemoryContinue = 0x3E,
        SetTearScanLine = 0x44,
        GetScanLine = 0x45,
        WriteDisplayBrightness = 0x51,
        ReadDisplayBrightness = 0x52,
        WriteCtrlDisplay = 0x53,
        ReadCtrlDisplay = 0x54,
        WriteContentAdaptiveBrightnessControl = 0x55,
        ReadContentAdaptiveBrightnessControl = 0x56,
        WriteCabcMinimumBrightness = 0x5E,
        ReadCabcMinimumBrightness = 0x5F,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        RgbInterfaceSignalControl = 0xB0,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        FrameControlNormal = 0xB1,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        FrameControlIdle = 0xB2,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        FrameControlPartial = 0xB3,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        DisplayInversionControl = 0xB4,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        BlankingPorchControl = 0xB5,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        DisplayFunctionControl = 0xB6,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        EntryModeSet = 0xB7,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        BacklightControl1 = 0xB8,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        BacklightControl2 = 0xB9,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        BacklightControl3 = 0xBA,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        BacklightControl4 = 0xBB,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        BacklightControl5 = 0xBC,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        BacklightControl6 = 0xBD,// BacklightControl6 did not exist in the Ilitek documentation, BD is assumed
        /// <summary>
        /// Manufacturer only
        /// </summary>
        BacklightControl7 = 0xBE,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        BacklightControl8 = 0xBF,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        PowerControl1 = 0xC0,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        PowerControl2 = 0xC1,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        VCOMControl1 = 0xC5,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        VCOMControl2 = 0xC7,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        NVMemoryWrite = 0xD0,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        NVMemoryProtectionKey = 0xD1,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        NVMemoryStatusRead = 0xD2,
        /// <summary>
        /// Manufacturer only
        /// </summary>
        ReadId4 = 0xD3,
        ReadId1 = 0xDA,
        ReadId2 = 0xDB,
        ReadId3 = 0xDC,
        PositiveGammaCorrection = 0xE0,
        NegativeGammaCorrection = 0xE1,
        DigitalGammaControl1 = 0xE2,
        DigitalGammaControl2 = 0xE3,
        InterfaceControl = 0xF6
    }
}