using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogue")]
public class TakeTextFromFile
{
    [XmlElement("node")]
    public Node[] nodes;
    public static TakeTextFromFile Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TakeTextFromFile));
        StringReader reader = new StringReader(_xml.text);
        TakeTextFromFile dial = serializer.Deserialize(reader) as TakeTextFromFile;
        return dial;
    }
}

[System.Serializable]
    public class Node 
{
    [XmlElement("text")]
    public string text;

    [XmlElement("endnode")]
    public string endnode;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}
    [System.Serializable]
    public class Answer
{
    [XmlAttribute("tonode")]
    public int n;

    [XmlElement("ans_text")]
    public string anstext;

    [XmlElement("end")]
    public string end;

    [XmlElement("toending")]
    public string ending;
}