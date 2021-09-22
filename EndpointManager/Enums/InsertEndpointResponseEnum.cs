using System.ComponentModel;

namespace EndpointManager.Enums
{
    public enum InsertEndpointResponseEnum
    {
        [Description("Endpoint was inserted successfully!")]
        Success,
        [Description("An endpoint with this Serial Number has already been inserted.")]
        SerialNumberAllreadyExists,
        [Description("An unknown error has occurred, please try again.")]
        UnkownError,
    }
}
