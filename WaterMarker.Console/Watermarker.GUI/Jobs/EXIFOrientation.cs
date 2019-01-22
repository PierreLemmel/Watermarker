namespace Watermarker.Jobs
{
    internal enum EXIFOrientation : byte
    {
        NoRotation = 0x1,
        Rotation90 = 0x6,
        Rotation180 = 0x3,
        Rotation270 = 0x8
    }
}