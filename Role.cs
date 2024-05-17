using YamlDotNet.Serialization;

namespace YamlStory;

internal partial class YamlParser
{
    public class Role
    {
        [YamlMember(Alias = "token", ApplyNamingConventions = false)]
        public string token = "";

        [YamlMember(Alias = "name", ApplyNamingConventions = false)]
        public string name = "";
    }

}