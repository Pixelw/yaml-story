using YamlDotNet.Serialization;
namespace YamlStory;

internal partial class YamlParser
{
    public class Story
    {
        [YamlMember(Alias = "yaml-story", ApplyNamingConventions = false)]
        public string yamlStory = "";

        [YamlMember(Alias = "role", ApplyNamingConventions = false)]
        public List<Role> roles = [];
        private readonly List<string> tokens = [];

        public List<string> GetRoleTokens()
        {
            if (tokens.Count == 0)
            {
                foreach (var role in roles)
                {
                    tokens.Add(role.token);
                }
            }

            return tokens;
        }

        [YamlMember(Alias = "script", ApplyNamingConventions = false)]
        public List<Dictionary<string, object>> script = [];
    }





}