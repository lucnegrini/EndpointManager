using System.ComponentModel;

namespace EndpointManager.Enums
{
    public enum EditEndpointResponseEnum
    {
        [Description("Endpoint was edited successfully!")]
        Success,
        [Description("Couldn't find an endpoint with this Serial Number.")]
        EndpointNotFound,
        [Description("An unknown error has occurred, please try again.")]
        UnkownError,
    }
}
