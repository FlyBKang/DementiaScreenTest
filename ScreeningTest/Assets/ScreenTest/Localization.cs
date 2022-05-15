using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Localization : MonoBehaviour
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

    [SerializeField]
    public textLocal[] transList;
    private void Start()
    {
        foreach(textLocal t in transList)
        {
            if (korean)
                t.obj.text = t.korean;
            else
                t.obj.text = t.english;
        }
    }
    public void Translate()
    {

        foreach (textLocal t in transList)
        {
            if (korean)
                t.obj.text = t.korean;
            else
                t.obj.text = t.english;
        }
    }
}
