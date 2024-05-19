using YamlDotNet.Serialization;

namespace YamlStory
{
#nullable enable
    public class Role
    {
        [YamlMember(Alias = "token", ApplyNamingConventions = false)]
        public string token = "";

        [YamlMember(Alias = "name", ApplyNamingConventions = false)]
        public string name = "";

        [YamlMember(Alias = "avatar", ApplyNamingConventions = false)]
        public string? avatar = null;

    }
}
