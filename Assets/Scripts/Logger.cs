using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Logger
{

    private System.Type type;
    public bool disabled = false;
    public Logger(System.Type type)
    {
        this.type = type;
    }

    public void Log(string msg)
    {
        if (!disabled)
        {
            Debug.Log(type.Name + ": " + msg);
        }
    }

    public void Log(Object msg)
    {
        Log(msg.ToString());
    }
}