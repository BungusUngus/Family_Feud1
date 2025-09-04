using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;


//STATIC -- Called upon anywhere without reference
public static class JSONManager
{
    public static void SayHello()
    {
        Debug.Log("Hello my little friend! :)");
    }


    /// <summary>
    /// JSON Encryption algorithm which takes an object (SavedData) and pushes it into a Text/JSON file
    /// CTRL-V in your File Browser application to see where it's been saved
    /// </summary>
    /// <param name="data"></param>
    public static void SaveToJSON(SavedData data)
    {
        string directory = Application.persistentDataPath + "/SavedData/";
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        string json = JsonUtility.ToJson(data, true); //This is the JSON encryption!
        File.WriteAllText(directory + "responseDatabase.json", json);

        GUIUtility.systemCopyBuffer = directory; //This is the CTRL-C
    }


    /// <summary>
    /// JSON Decryption that turns a Text/JSON file into an object (SavedData) which'll be returned.
    /// Returns NULL if it couldn't find a file.
    /// </summary>
    /// <returns></returns>
    public static SavedData LoadFromJSON()
    {
        string directory = Application.persistentDataPath + "/SavedData/" + "responseDatabase.json";
        if ( File.Exists(directory) )
        {
            string json = File.ReadAllText(directory);
            return JsonUtility.FromJson<SavedData>(json); //This is the JSON decryption
        } else
        {
            Debug.Log("Load failed. No File Found");
            return null;
        }
    }
}

[Serializable] //Readable in Unity Inspector

//SavedData -- a collection of information you'd like to be saved when prompted
//For this project, we just need to save a list of Question objects... but it could be more
public class SavedData
{
    //public string name = "Ronald";
    //public string surname = "McDonald";
    //public int age = 103;
    //public bool likesHamburgers = true;
    //public Vector3 position = new Vector3(1, 10, 100);
    public List<Question> savedQuestions;
}
