using CsvHelper;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is used to hold a dictionary of the dialogue scripts translations, so that
 * they can be retrieved when the player hovers over any given text.
 * 
 * I've lifted most of the code from Yarn.Unity.DialogueRunner
 */
public class DialogueTranslated : MonoBehaviour
{
    // Maps string IDs received from Yarn Spinner to user-facing text
    Dictionary<string, string> strings = new Dictionary<string, string>();

    // add scripts translated dialgue to the dictionary
    public void Add(TextAsset textToLoad)
    {
        // Use the invariant culture when parsing the CSV
        var configuration = new CsvHelper.Configuration.Configuration(
            System.Globalization.CultureInfo.InvariantCulture
        );

        using (var reader = new System.IO.StringReader(textToLoad.text))
        using (var csv = new CsvReader(reader, configuration))
        {
            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                string text;
                string[] splitText = csv.GetField("text").Split(':');

                /** 
                 *  all dialogue lines start with a name
                *   eg. "Sally: Where were you last night?"
                *   However player options do not have a name
                *   eg. "I was at the pub"
                *   so we need to do a check to make sure we don't
                *   get an IndexOutOfRangeException
                **/
                if (splitText.Length > 1)
                    text = splitText[1];
                else
                    text = splitText[0];

                strings.Add(csv.GetField("id"), text);
            }
        }
    }

    // retreive translated dialgue from it's line id
    public string Get(string id)
    {
        if (!strings.TryGetValue(id, out var result)) 
            return null;

        return result;
    }
}
