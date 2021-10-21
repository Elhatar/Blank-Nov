using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField] private Text mainText;

    [SerializeField] private Image[] imagesToChange;
    [SerializeField] private Sprite[] changedImages;

    [SerializeField] private Sprite[] startImages;
    int i = 0;
    public void Change()
    {
        i++;
        if (i%2 == 0)
        {
            for (int changeCode = 0; changeCode < imagesToChange.Length; changeCode++)
            {
                imagesToChange[changeCode].sprite = changedImages[changeCode];
            }
        }
    }

    public void Back()
    {
        for (int changeCode = 0; changeCode < imagesToChange.Length; changeCode++)
        {
            imagesToChange[changeCode].sprite = startImages[changeCode];
        }
    }
}
