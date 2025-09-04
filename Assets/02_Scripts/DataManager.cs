using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //Update this list everytime your user answers the relevent question
    public List<Question> myQuestions;
    public Question currentQuestion; //You MAY need these
    public int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadGame();
        //myQuestions[0].responses.Add("something new")
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Create a new SavedData file and give it all the questions in 'myQuestions'
    /// Encrypt that into a JSON file with the JSONManager
    /// </summary>
    [ ContextMenu("Save Game") ]
    public void SaveGame()
    {
        print("Attempting to Save Game");
        SavedData savedData = new SavedData();
        savedData.savedQuestions = myQuestions;
        JSONManager.SaveToJSON(savedData);
    }

    /// <summary>
    /// Use the JSONManager to retrieve the questions stored away.
    /// Push those questions on the 'myQuestions' list.
    /// If the Load() fails, Save() the game instead.
    /// </summary>
    [ ContextMenu("Load Game") ]
    public void LoadGame()
    {
        print("Attempting to Load Game");
        SavedData loadedData = JSONManager.LoadFromJSON();
        if (loadedData != null)
            myQuestions = loadedData.savedQuestions;
        else
            SaveGame();
    }
}

[Serializable]

//Datapack which contains a question (String) and list of responses (List<string>)
public class Question
{
    public string question;
    public List<string> responses;
}
