using System.ComponentModel;

namespace EndpointManager.Enums
{
    public enum MainMenuEnum
    {
        [Description("Insert new endpoint")]
        InsertEndpoint = 1,
        [Description("Edit existing endpoint")]
        EditEndpoint = 2,
        [Description("Delete existing endpoint")]
        DeleteEndpoint = 3,
        [Description("List all endpoints")]
        ListEndpoints = 4,
        [Description("Find by Serial Number")]
        FindEndpoint = 5,
        [Description("Exit")]
        Exit = 6,
    }
}
