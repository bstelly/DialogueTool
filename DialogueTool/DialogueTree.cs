using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DialogueTool
{
    internal class DialogueTree
    {
        public List<DialogueRoot> DialogueRoot = new List<DialogueRoot>();

        public void Save(string directory)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(directory, json);
        }

        public void Load(string directory)
        {
            var temp = JsonConvert.DeserializeObject<DialogueTree>(
                File.ReadAllText(directory));
            DialogueRoot = temp.DialogueRoot;
        }
    }
}