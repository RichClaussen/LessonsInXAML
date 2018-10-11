using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace GuitarPlayers
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class LocalizableAttribute : DescriptionAttribute
    {
        public LocalizableAttribute(string description, Type resourcesType)
            : base(description)
        {
            this.resourcesType = resourcesType;
        }

        public override string Description
        {
            get
            {
                if (!isLocalized)
                {
                    var resMan =
                         resourcesType.InvokeMember(
                             @"ResourceManager",
                             BindingFlags.GetProperty | BindingFlags.Static |
                             BindingFlags.Public | BindingFlags.NonPublic,
                             null,
                             null,
                             new object[] { }) as ResourceManager;

                    var culture =
                         resourcesType.InvokeMember(
                             @"Culture",
                             BindingFlags.GetProperty | BindingFlags.Static |
                             BindingFlags.Public | BindingFlags.NonPublic,
                             null,
                             null,
                             new object[] { }) as CultureInfo;

                    isLocalized = true;

                    if (resMan != null)
                    {
                        DescriptionValue = resMan.GetString(DescriptionValue, culture);
                    }
                }

                return DescriptionValue;
            }
        }

        private readonly Type resourcesType;
        private bool isLocalized;
    }
}
