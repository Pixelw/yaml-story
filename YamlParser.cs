using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;
using static YamlStory.DialogBatch;

namespace YamlStory
{
    public class YamlParser
    {

        public static readonly string ROLE_LIST_TOKEN = "role";
        public static readonly string YAML_VERSION_TOKEN = "yaml-story";
        public static readonly string SCRIPT_SEQUENCE_TOKEN = "script";

        public static List<DialogBatch> ReadYamlStory(string yamlText)
        {

            var deserializer = new DeserializerBuilder()
                .Build();

            var story = deserializer.Deserialize<Story>(yamlText);

            return ParseDicts(story.script, story.GetRoleTokens(), story.roles);

        }



        /**
         * Parse List<Dictionary<string, object>> into readable List<DialogBatch>
         */
        private static List<DialogBatch> ParseDicts(List<Dictionary<string, object>> script, List<string> tokens, List<Role> roles)
        {
            var result = new List<DialogBatch>();
            foreach (var item in script)
            {
                var batch = new DialogBatch();
                foreach (var action in item)
                {
                    switch (action.Key)
                    {
                        case "bg":
                            batch.backgroundImg = action.Value.ToString();
                            break;
                        case "sound":
                            batch.sound = action.Value.ToString();
                            break;
                        case "autoplay":
                            batch.autoplay = Boolean.Parse(action.Value.ToString() ?? "false");
                            break;
                        case "visible":
                            if (Boolean.Parse(action.Value.ToString() ?? "false"))
                            {
                                batch.dialogVisibility = DialogBatch.VISIBILITY_VISIBLE;
                            }
                            else
                            {
                                batch.dialogVisibility = DialogBatch.VISIBILITY_GONE;
                            }
                            break;
                        case "show":
                            batch.dialogVisibility = DialogBatch.VISIBILITY_VISIBLE;
                            break;
                        case "hide":
                            batch.dialogVisibility = DialogBatch.VISIBILITY_GONE;
                            break;
                        case "select":
                            batch.options = new List<Option>();
                            var list = ConvertList((List<object>)action.Value);
                            foreach (Dictionary<string, object> dict in list)
                            {
                                var option = new Option();
                                var kvp = dict.First(); // one option only allow one "name" key
                                option.name = kvp.Key.ToString();
                                option.branchSeq = ParseDicts(ConvertList((List<object>)kvp.Value), tokens, roles);
                                batch.options.Add(option);
                            }
                            break;
                        case "trigger":
                            batch.trigger = action.Value.ToString();
                            break;
                        case "facial":
                            batch.facial = action.Value.ToString();
                            break;
                        default:
                            if (tokens.Contains(action.Key))
                            {
                                batch.text = action.Value.ToString();
                                batch.charaName = roles.Find(x => x.token == batch.text)?.name;
                            }
                            break;
                    }
                }
                result.Add(batch);

            }
            return result;

        }

        private static List<Dictionary<string, object>> ConvertList(List<object> list)
        {

            List<Dictionary<string, object>> convertedList = new List<Dictionary<string, object>>(); // real option:script
            foreach (Dictionary<object, object> dict in list)
            {
                var converted = new Dictionary<string, object>
                        {
                            { (string)dict.First().Key, dict.First().Value }
                        };
                convertedList.Add(converted);
            }
            return convertedList;
        }





    }
}
