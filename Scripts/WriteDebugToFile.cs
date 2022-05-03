using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteDebugToFile : MonoBehaviour
{
    private string fileName;
    private StreamWriter writer;

    public void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    public void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    void Awake()
    {
        fileName = Path.Combine(Application.dataPath, "logOutput.txt");
        writer = new StreamWriter(fileName);
    }

    public void Log(string logString, string stackTrace, LogType logType)
    {
        writer.WriteLine(logString);
        writer.Flush();
    }

}
