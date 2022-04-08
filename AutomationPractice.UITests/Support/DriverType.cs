using System.Runtime.Serialization;

namespace AutomationPractice.UITests.Support
{
    public enum DriverType
    {
        [EnumMember(Value = "Chrome")]
        Chrome = 0,

        [EnumMember(Value = "Firefox")]
        Firefox = 1,
    }
}