using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnClick : MonoBehaviour
{
    public int curI;
    public string end;
    public string ending;
    public DialogueEngine d;

    private void Start()
    {
        d = GetComponentInParent<DialogueEngine>();
    }

    public void next()
    {
        d.Next(curI, end, ending);
    }
}
