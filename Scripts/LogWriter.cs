using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LogWriter : MonoBehaviour
{
    [HideInInspector]
    public string text;

    public void AddText(string txt)
    {
        text += txt;
        GameObject.Find("LogText").GetComponent<TextMesh>().text += txt;
    }

    public void SaveText()
    {
        string path = Path.Combine(Application.persistentDataPath, "Log.txt");
        using (TextWriter writer = File.CreateText(path))
        {
            writer.Write(text);
            writer.Flush();
            writer.Close();
        }
    }
}