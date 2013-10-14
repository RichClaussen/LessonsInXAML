using GuitarPlayers.Properties;

namespace GuitarPlayers.Models
{
    public enum OrderBy
    {
        [Localizable(@"Id", typeof(Resources))]
        Id,
        [Localizable(@"Name", typeof(Resources))]
        Name,
        [Localizable(@"Age", typeof(Resources))]
        Age,
    }
}
