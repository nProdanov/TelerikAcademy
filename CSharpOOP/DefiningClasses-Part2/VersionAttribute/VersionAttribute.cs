namespace VersionAttribute
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Enum |
        AttributeTargets.Method)]
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(string name, string version)
        {
            this.Name = name;
            this.Version = version;
        }

        public string Name { get; set; }
        
        public string Version { get; set; }
    }
}
