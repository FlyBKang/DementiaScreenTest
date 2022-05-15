using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocalizationCtrl : MonoBehaviour
{    
    public List<Localization> list1;
    public List<LicalizationRefeat> list2;
    public ScreenTestController stc;
    public int languageNum = 0; // 0Korean 1English
    private bool saveFile;
    public GameObject[] btn;
    private void Awake()
    {
        saveFile = PlayerPrefs.HasKey("language");        
        if(saveFile)
        {
            languageNum = PlayerPrefs.GetInt("language");
        }
        else
        {
            languageNum = 0;
        }
        if (languageNum == 0)
        {
            stc.isKorean = true;
            foreach (Localization l in list1)
            {
                l.korean = true;
                l.Translate();
            }
            foreach (LicalizationRefeat l in list2)
            {
                l.korean = true;
                l.Translate();
            }
        }
        else
        {
            stc.isKorean = false;

            foreach (Localization l in list1)
            {
                l.korean = false;
                l.Translate();
            }
            foreach (LicalizationRefeat l in list2)
            {
                l.korean = false;
                l.Translate();
            }
        }

        foreach (GameObject g in btn)
            g.SetActive(false);
        btn[languageNum].SetActive(true);
    }

    public void LanguageBtn(int num)
    {
        languageNum = num;
        PlayerPrefs.SetInt("language", languageNum);        
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);      
    }
}
