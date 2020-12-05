using System;
using System.Collections.Generic;

using LatinoNETOnline.App.Client.Core.Enums;

namespace LatinoNETOnline.App.Client.Authentication.Extensions
{
    public static class RoleExtensions
    {
        public static IEnumerable<string> GetNamesGreaterOrEqualsRoles(this UserRole role)
        {
            var names = Enum.GetNames(role.GetType());
            for (int i = 0; i < names.Length; i++)
            {
                if (i >= (int)role)
                    yield return names[i];
            }
        }
    }
}
