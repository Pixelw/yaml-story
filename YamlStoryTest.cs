using System;
using System.IO;

namespace YamlStory
{
    internal class YamlStoryTest
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("D:\\VsProjects\\yaml-story\\example.yaml");
            var batch = YamlParser.ReadYamlStory(text);

            batch.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

    }
}
