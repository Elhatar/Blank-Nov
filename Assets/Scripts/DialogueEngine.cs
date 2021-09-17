using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueEngine : MonoBehaviour
{
    public TextAsset asset;

    int i = 0;

    public Text dialogueText;
    public Image cyuImage;

    public int[] spriteID;
    public Sprite[] cyuSprites;

    TakeTextFromFile dialogue;

    public GameObject[] buttons;
    public GameObject NextButton;

    void Start()
    {
        dialogue = TakeTextFromFile.Load(asset);
        cyuImage.GetComponent<Animator>().SetTrigger("go");
    }

    
    void Update()
    {
        cyuImage.sprite = cyuSprites[spriteID[i]];
        if(dialogue.nodes[i].endnode != "true")
        {
            NextButton.SetActive(false);
            for(int j = 0; j < dialogue.nodes[i].answers.Length; j++)
            {
                buttons[j].SetActive(true);
                buttons[j].GetComponent<ButtonOnClick>().end = "";
                buttons[j].GetComponentInChildren<Text>().text = dialogue.nodes[i].answers[j].anstext;
                buttons[j].GetComponent<ButtonOnClick>().curI = dialogue.nodes[i].answers[j].n;
                if(dialogue.nodes[i].answers[j].end == "true")
                {
                    buttons[j].GetComponent<ButtonOnClick>().end = dialogue.nodes[i].answers[j].end;
                    buttons[j].GetComponent<ButtonOnClick>().ending = dialogue.nodes[i].answers[j].ending;
                }
            }
        }
        else
        {
            NextButton.SetActive(true);
            for(int j = 0; j <buttons.Length; j++)
            {
                buttons[j].SetActive(false);
            }
        }
    }

    public void Next(int nextNode, string end, string ending)
    {
        if(i < dialogue.nodes.Length - 1)
        {
            if (dialogue.nodes[i].endnode == "true")
            {
                i++;
            }
            else
            {
                if (end != "true")
                {
                    i = nextNode;
                }
                else
                {
                    string nextSceneName;
                    nextSceneName = ending;
                    UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
                }
            }
            cyuImage.GetComponent<Animator>().SetTrigger("go");
        }
        StopAllCoroutines();
        StartCoroutine(TypeText(dialogue.nodes[i].text));
    }

    IEnumerator TypeText(string dial)
    {
        dialogueText.text = "";
        foreach(char letter in dial.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void NextB()
    {
        Next(0, "", "");
    }
}
