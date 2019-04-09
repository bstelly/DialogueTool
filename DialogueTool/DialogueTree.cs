using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DialogueTool
{
    internal class DialogueTree
    {
        public List<DialogueRoot> DialogueRoot = new List<DialogueRoot>();
        /// <summary>
        /// Serializes a DialogueTree object into a json file at a specified location
        /// </summary>
        /// <param name="destination">Place the file is being saved</param>
        /// <param name="fileName">Name of the file</param>

        //Prototype: void Save(string directory)
        //Arguments: A string for the files directory
        //Description: Serializes a DialogueTree object into a json file at a specified location
        //Precondition: There must be a DialogueTree object
        //Postcondition: A DialogueTree object is serialized and saved to a location
        //Protection Level: public
        public void Save(string directory)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(directory, json);
        }

        /// <summary>
        /// Deserializes a DialogueTree object from a json file located at the
        /// specified location into another DialogueTree object
        /// </summary>
        /// <param name="directory">Directory for the file being loaded</param>

        //Prototype: void Load(string directory)
        //Arguments: Takes in a string
        //Description: Deserializes a DialogueTree object from a json file located at the
        //             specified location into another DialogueTree object
        //Precondition: There must be an instance of the DialogueTree class
        //Postcondition: The DialogueTree object calling the function is assigned the values
        //               of the deserialized file
        //Protection Level: public
        public void Load(string directory)
        {
            var temp = JsonConvert.DeserializeObject<DialogueTree>(
                File.ReadAllText(directory));
            DialogueRoot = temp.DialogueRoot;
        }
    }
}