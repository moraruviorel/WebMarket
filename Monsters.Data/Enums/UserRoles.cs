using System;
using System.ComponentModel;

namespace Monsters.Data.Enums
{
    [Serializable]
    public enum UserRoles
    {
        [Description("Administrator")]
        Administrator = 1,

        [Description("User")]
        User = 2
    }
}
