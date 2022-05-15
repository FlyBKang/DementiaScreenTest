using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LicalizationRefeat : MonoBehaviour
{
    [System.Serializable]
    public struct textLocal
    {
        public TextMeshProUGUI obj;
        [TextArea]
        public string korean;
        [TextArea]
        public string english;
    }    
    public bool korean = true;

    public TextMeshProUGUI[] textList;
    [SerializeField]
    public textLocal[] transList;
    
    public void Start()
    {
        int cnt = 0;
        foreach (TextMeshProUGUI t in textList)
        {
            if (korean)
                t.text = transList[cnt % transList.Length].korean;
            else
                t.text = transList[cnt % transList.Length].english;
            cnt++;
        }
    }
    public void Translate()
    {
        int cnt = 0;
        foreach (TextMeshProUGUI t in textList)
        {
            if (korean)
                t.text = transList[cnt % transList.Length].korean;
            else
                t.text = transList[cnt % transList.Length].english;
            cnt++;
        }
    }
}
