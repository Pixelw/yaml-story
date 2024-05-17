using YamlStory;

namespace yaml_story
{
    internal class Test
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
