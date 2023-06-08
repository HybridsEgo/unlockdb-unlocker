using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the XML file location as a command line argument.");
            return;
        }

        string xmlFilePath = args[0];
        string attributeName = "state";
        string attributeValue = "eUnlockState_Unlocked";

        try
        {
            // Load the XML file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Get all elements with the specified attribute
            XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes($"//*[@{attributeName}]");

            // Update the attribute value for each matching element
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes != null && node.Attributes[attributeName] != null)
                {
                    node.Attributes[attributeName].Value = attributeValue;
                }
            }

            // Save the modified XML document
            xmlDoc.Save(xmlFilePath);

            Console.WriteLine("XML file updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
