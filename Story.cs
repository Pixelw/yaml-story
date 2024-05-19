using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;

namespace YamlStory
{
    public class Story
    {
        [YamlMember(Alias = "yaml-story", ApplyNamingConventions = false)]
        public string yamlStory = "";

        [YamlMember(Alias = "role", ApplyNamingConventions = false)]
        public List<Role> roles = new List<Role>();
        private readonly List<string> tokens = new List<string>();

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
        public List<Dictionary<string, object>> script = new List<Dictionary<string, object>>();
    }

}
