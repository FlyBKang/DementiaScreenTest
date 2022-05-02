using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenTestController : MonoBehaviour
{
    public GameObject[] panelList;
    public PillarBoxCanvas PillarBox;
    public int Score = 0;
    private AudioSource mySound;
    private void Awake()
    {
        mySound = GetComponent<AudioSource>();
        foreach (GameObject g in panelList)
            g.SetActive(false);
        panelList[0].SetActive(true);
    }
    public void Exit()
    {
        Exit();
    }
    #region 생년월일  
    [Header("Birth")]
    public int year, month, day;
    public TextMeshProUGUI yearTMP, monthTMP, dayTMP;
    public void StartBirthPanel()
    {
        BirthReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[1], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void BirthReset()
    {
        year = 1960;
        month = 1;
        day = 1;
        yearTMP.text = year.ToString();
        monthTMP.text = month.ToString();
        dayTMP.text = day.ToString();
    }
    public void YearCtrl(int num)
    {
        year = year + num;
        if (year < 1900)
            year = 1900;
        if (year > 2030)
            year = 2030;

        yearTMP.text = year.ToString();
    }
    public void MonthCtrl(int num)
    {
        month = month + num;
        if (month < 1)
            month = 1;
        if (month > 12)
            month = 12;
        monthTMP.text = month.ToString();
    }
    public void DayCtrl(int num)
    {
        day = day + num;
        if (day < 1)
            day = 1;
        if (day > 31)
            day = 31;
        dayTMP.text = day.ToString();
    }
    #endregion

    #region 오늘의 날짜  
    [Header("Today")]
    public int todayYear, todayMonth, todayDate, todayDay;
    public TextMeshProUGUI todayTMP_Y, todayTMP_M, todayTMP_Date, todayTMP_Day;    
    public void StartTodayPanel()
    {
        TodayReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[2], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void TodayReset()
    {
        todayYear = 2020;
        todayMonth = 1;
        todayDate = 1;
        todayDay = 0;
        todayTMP_Y.text = todayYear.ToString();
        todayTMP_M.text = todayMonth.ToString();
        todayTMP_Date.text = todayDate.ToString();
        TodayDayCtrl(0);

    }
    public void TodayYearCtrl(int num)
    {
        todayYear += num;
        if (todayYear < 1900)
            todayYear = 1900;
        if (todayYear > 2030)
            todayYear = 2030;
        todayTMP_Y.text = todayYear.ToString();
    }
    public void TodayMonthCtrl(int num)
    {
        todayMonth += num;
        if (todayMonth < 1)
            todayMonth = 1;
        if (todayMonth > 12)
            todayMonth = 12;
        todayTMP_M.text = todayMonth.ToString();
    }
    public void TodayDateCtrl(int num)
    {
        todayDate += num;
        if (todayDate < 1)
            todayDate = 1;
        if (todayDate > 31)
            todayDate = 31;
        todayTMP_Date.text = todayDate.ToString();
    }
    public void TodayDayCtrl(int num)
    {
        todayDay += num;
        if (todayDay > 6)
            todayDay = 0;
        if (todayDay < 0)
            todayDay = 6;
        
        if (SystemLanguage.Korean != Application.systemLanguage)
        {
            switch (todayDay)
            {
                case 0:
                    todayTMP_Day.text = "Mon";
                    break;
                case 1:
                    todayTMP_Day.text = "Tue";
                    break;
                case 2:
                    todayTMP_Day.text = "Wed";
                    break;
                case 3:
                    todayTMP_Day.text = "Thu";
                    break;
                case 4:
                    todayTMP_Day.text = "Fri";
                    break;
                case 5:
                    todayTMP_Day.text = "Sat";
                    break;
                case 6:
                    todayTMP_Day.text = "Sun";
                    break;
            }
        }
        else
        {
            switch (todayDay)
            {
                case 0:
                    todayTMP_Day.text = "월요일";
                    break;
                case 1:
                    todayTMP_Day.text = "화요일";
                    break;
                case 2:
                    todayTMP_Day.text = "수요일";
                    break;
                case 3:
                    todayTMP_Day.text = "목요일";
                    break;
                case 4:
                    todayTMP_Day.text = "금요일";
                    break;
                case 5:
                    todayTMP_Day.text = "토요일";
                    break;
                case 6:
                    todayTMP_Day.text = "일요일";
                    break;
            }
        }
        
        

    }
    public void DateCheck()
    {
        string tempYear = System.DateTime.Now.ToString("yyyy");
        if (tempYear == todayTMP_Y.text)
            Score++;
        //print(tempYear);
        string tempMonth = System.DateTime.Now.ToString("MM");
        if (int.Parse(tempMonth) == int.Parse(todayTMP_M.text))
            Score++;
        //print(tempMonth);
        string tempDate = System.DateTime.Now.ToString("dd");
        if (int.Parse(tempDate) == int.Parse(todayTMP_Date.text))            
            Score++;
        //print(tempDate);
        int currentDay = 0;
        switch (System.DateTime.Now.DayOfWeek)
        {
            case System.DayOfWeek.Monday:
                currentDay = 0;
                break;
            case System.DayOfWeek.Tuesday:
                currentDay = 1;
                break;
            case System.DayOfWeek.Wednesday:
                currentDay = 2;
                break;
            case System.DayOfWeek.Thursday:
                currentDay = 3;
                break;
            case System.DayOfWeek.Friday:
                currentDay = 4;
                break;
            case System.DayOfWeek.Saturday:
                currentDay = 5;
                break;
            case System.DayOfWeek.Sunday:
                currentDay = 6;
                break;
            default:
                currentDay = 7;
                break;
        }
        if (currentDay == todayDay)
            Score++;
        print(currentDay);
        StartStuffPanel();
    }
    #endregion

    #region 물건
    [Header("Stuff")]
    public GameObject[] stuffPicture;
    public TextMeshProUGUI stuffExplain;
    public float stuffShowTime = 3.0f;
    public GameObject stuffStartBtn;
    public List<int> stuffimgArr;
    public GameObject stuffAnswerPanel;
    public int[] stuffAnswer = new int[] { 0, 1, 2 };
    public Transform stuffAnswerObj0, stuffAnswerObj1, stuffAnswerObj2;
    public void StartStuffPanel()
    {
        StuffReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[3], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void StuffReset()
    {
        stuffimgArr = new List<int>();
        for (int i = 0; i < 10; ++i)
        {
            stuffimgArr.Add(i);
            stuffPicture[i].SetActive(false);
        }
        Util.ShuffleList(stuffimgArr);
        stuffAnswer = new int[] { 0, 1, 2 };
        stuffAnswerPanel.SetActive(false);
        StuffImageChage(0);
        stuffStartBtn.SetActive(true);
    }
    public void ShowImage()
    {
        stuffStartBtn.SetActive(false);
        StartCoroutine(ShowIMG());
        IEnumerator ShowIMG()
        {
            WaitForSeconds wfs = new WaitForSeconds(stuffShowTime);
            for (int j = 0; j < 3; ++j)
            {
                for (int i = 0; i < 10; ++i)
                    stuffPicture[i].SetActive(false);
                stuffPicture[stuffimgArr[j]].SetActive(true);

                yield return wfs;
            }
            stuffAnswerPanel.SetActive(true);
        }
    }
    public void StuffImageChage(int n) //{1,2,3,-1,-2,-3}
    {
        switch (n)
        {
            case 1:
                stuffAnswer[0]++;
                if (stuffAnswer[0] > 9)
                    stuffAnswer[0] = 0;
                break;
            case -1:
                stuffAnswer[0]--;
                if (stuffAnswer[0] < 0)
                    stuffAnswer[0] = 9;
                break;
            case 2:
                stuffAnswer[1]++;
                if (stuffAnswer[1] > 9)
                    stuffAnswer[1] = 0;
                break;
            case -2:
                stuffAnswer[1]--;
                if (stuffAnswer[1] < 0)
                    stuffAnswer[1] = 9;
                break;
            case 3:
                stuffAnswer[2]++;
                if (stuffAnswer[2] > 9)
                    stuffAnswer[2] = 0;
                break;
            case -3:
                stuffAnswer[2]--;
                if (stuffAnswer[2] < 0)
                    stuffAnswer[2] = 9;
                break;
            default:
                break;
        }
        for (int i = 0; i < stuffAnswerObj0.childCount; ++i)
        {
            stuffAnswerObj0.GetChild(i).gameObject.SetActive(false);
            stuffAnswerObj1.GetChild(i).gameObject.SetActive(false);
            stuffAnswerObj2.GetChild(i).gameObject.SetActive(false);
        }
        stuffAnswerObj0.GetChild(stuffAnswer[0]).gameObject.SetActive(true);
        stuffAnswerObj1.GetChild(stuffAnswer[1]).gameObject.SetActive(true);
        stuffAnswerObj2.GetChild(stuffAnswer[2]).gameObject.SetActive(true);
    }
    public void StuffCheck()
    {
        bool check0, check1, check2, order;
        check0 = check1 = check2 = order = false;
        for (int i = 0; i < 3; ++i)
        {
            if (stuffAnswer[i] == stuffimgArr[0])
                check0 = true;
            if (stuffAnswer[i] == stuffimgArr[1])
                check1 = true;
            if (stuffAnswer[i] == stuffimgArr[2])
                check2 = true;
        }
        if (stuffAnswer[0] == stuffimgArr[0])
            if (stuffAnswer[1] == stuffimgArr[1])
                if (stuffAnswer[2] == stuffimgArr[2])
                    order = true;
        if (check0)
            Score++;
        if (check1)
            Score++;
        if (check2)
            Score++;
        if (order)
            Score++;
        StartCalcPanel();
    }

    #endregion
    #region 계산
    [Header("Calc")]
    public TextMeshProUGUI calc1_1, calc1_2, calc1_answer;
    public TextMeshProUGUI calc2_1, calc2_2, calc2_answer;
    public TextMeshProUGUI calc3_1, calc3_2, calc3_answer;
    public TextMeshProUGUI calc4_1, calc4_2, calc4_answer;
    bool calcCheck1, calcCheck2, calcCheck3, calcCheck4;
    public GameObject[] calcQuestion;
    int calcNumber = 100;
    int random1, random2, random3, random4;
    int calcAnswer1, calcAnswer2, calcAnswer3, calcAnswer4;
    public void StartCalcPanel()
    {
        CalcReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[4], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void CalcReset()
    {
        calcNumber = 100;
        calcAnswer1 = 90;
        calcAnswer2 = 60;
        calcAnswer3 = 70;
        calcAnswer4 = 90;
        random1 = Random.Range(5, 9);
        random2 = Random.Range(26, 29);
        random3 = Random.Range(5, 9);
        random4 = Random.Range(26, 29);
        for (int i = 0; i < calcQuestion.Length; ++i)
            calcQuestion[i].SetActive(false);
        CalcSetting1();
        calcQuestion[0].SetActive(true);
        calcCheck1 = calcCheck2 = calcCheck3 = calcCheck4 = false;


    }
    public void CalcSetting1()
    {
        calc1_1.text = calcNumber.ToString();
        calc1_2.text = random1.ToString();
        calc1_answer.text = calcAnswer1.ToString();
    }
    public void CalcSetting2()
    {

        if (calcCheck1)
            return;
        calcCheck1 = true;
        calc2_1.text = calcAnswer1.ToString();
        calc2_2.text = random2.ToString();
        calc2_answer.text = calcAnswer2.ToString();

        if (calcNumber - random1 == calcAnswer1)
            Score++;
        calcQuestion[1].SetActive(true);
    }
    public void CalcSetting3()
    {
        if (calcCheck2)
            return;
        calcCheck2 = true;
        calc3_1.text = calcAnswer2.ToString();
        calc3_2.text = random3.ToString();
        calc3_answer.text = calcAnswer3.ToString();

        if (calcAnswer1 - random2 == calcAnswer2)
            Score++;
        calcQuestion[2].SetActive(true);

    }
    public void CalcSetting4()
    {
        if (calcCheck3)
            return;
        calcCheck3 = true;
        calc4_1.text = calcAnswer3.ToString();
        calc4_2.text = random4.ToString();
        calc4_answer.text = calcAnswer4.ToString();

        if (calcAnswer2 + random3 == calcAnswer3)
            Score++;
        calcQuestion[3].SetActive(true);
    }
    public void CalcUpDownCtrl(int num)
    {
        switch (num)
        {
            case 1:
                calcAnswer1++;
                break;
            case -1:
                calcAnswer1--;
                break;
            case 2:
                calcAnswer2++;
                break;
            case -2:
                calcAnswer2--;
                break;
            case 3:
                calcAnswer3++;
                break;
            case -3:
                calcAnswer3--;
                break;
            case 4:
                calcAnswer4++;
                break;
            case -4:
                calcAnswer4--;
                break;
        }

        calc1_answer.text = calcAnswer1.ToString();
        calc2_answer.text = calcAnswer2.ToString();
        calc3_answer.text = calcAnswer3.ToString();
        calc4_answer.text = calcAnswer4.ToString();

    }
    public void CalcCheck()
    {
        if (calcCheck4)
            return;
        calcCheck4 = true;
        if (calcAnswer3 + random4 == calcAnswer4)
            Score++;
        CubeStart();
    }
    #endregion
    #region 큐브
    [Header("Cube")]
    public Transform[] cubeButton;
    public GameObject[] cubeQuestion;
    int cubeQuestionCnt = 0;
    int cubeBtnSelect = -1;
    List<int> cubeOrder;
    //
    public void CubeReset()
    {
        cubeOrder = new List<int>();
        for (int i = 0; i < 5; ++i)
            cubeOrder.Add(i);
        cubeBtnSelect = -1;
        cubeQuestionCnt = 0;
        Util.ShuffleList(cubeOrder);
        CubePanelOpen();
    }
    public void CubeStart()
    {
        CubeReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[5], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void CubeSelectCube(int num)
    {
        cubeBtnSelect = num;

        for (int j = 0; j < 5; ++j)
        {
            for (int i = 0; i < 5; ++i)
                cubeButton[j].GetChild(i).gameObject.SetActive(false);
            if (num != -1)                
                cubeButton[j].GetChild(num).gameObject.SetActive(true);
        }
    }
    public void CubeNextBtn()
    {
        if (cubeBtnSelect == cubeOrder[cubeQuestionCnt])
            Score++;
        cubeQuestionCnt++;
        cubeBtnSelect = -1;
        CubeSelectCube(-1);

        if (cubeQuestionCnt == 3)
            Shape1Start();
        else
            CubePanelOpen();
    }
    public void CubePanelOpen()
    {
        for (int i = 0; i < 5; ++i)
            cubeQuestion[i].SetActive(false);
        cubeQuestion[cubeOrder[cubeQuestionCnt]].SetActive(true);
    }

    #endregion
    #region 도형
    [Header("Shape1")]
    public GameObject shape1Question;
    public Transform shape1Select;
    public AudioClip[] shape1Audio;
    public int shape1QuestNum = 0;
    public int shape1SelectNum = -1;
    List<int> shape1Order;
    public void Shape1Start()
    {
        Shape1Reset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[6], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void Shape1Reset()
    {
        shape1QuestNum = 0;
        shape1Order = new List<int>();
        for (int i = 0; i < 6; ++i)
        {
            shape1Order.Add(i);
        }
        Util.ShuffleList(shape1Order);
        Shape1SelectBtn(-1);
    }
    public void Shape1SoundPlay()
    {
        mySound.clip = shape1Audio[shape1Order[shape1QuestNum]];
        mySound.Play();
    }
    public void Shape1NextLevel()
    {
        if (shape1Order[shape1QuestNum] == shape1SelectNum)
            Score++;
        shape1QuestNum++;
        if (shape1QuestNum == 3)
            Shape2Start();
        Shape1SelectBtn(-1);
    }
    public void Shape1SelectBtn(int num)
    {
        shape1SelectNum = num;
        for (int i = 0; i < 6; ++i)
        {
            for (int j = 0; j < 6; ++j)
                shape1Select.GetChild(j).gameObject.SetActive(false);            
        }
        if (num < 0)
            return;
        for (int i = 0; i < 6; ++i)
            shape1Select.GetChild(num).gameObject.SetActive(true);
    }
    #endregion
    #region 도형2
    [Header("Shape2")]
    public GameObject shape2Question;
    public Transform shape2Select;
    public AudioClip[] shape2Audio;
    public int shape2QuestNum = 0;
    public int shape2SelectNum = -1;
    List<int> shape2Order;
    public void Shape2Start()
    {
        Shape2Reset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[7], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void Shape2Reset()
    {
        shape2QuestNum = 0;
        shape2Order = new List<int>();
        for (int i = 0; i < 6; ++i)
        {
            shape2Order.Add(i);
        }
        Util.ShuffleList(shape2Order);
        Shape2SelectBtn(-1);
    }
    public void Shape2SoundPlay()
    {
        mySound.clip = shape1Audio[shape1Order[shape2QuestNum]];
        mySound.Play();
    }
    public void Shape2NextLevel()
    {
        if (shape2Order[shape2QuestNum] == shape2SelectNum)
            Score++;
        shape2QuestNum++;
        if (shape2QuestNum == 3)
            SentenceStart();
        Shape2SelectBtn(-1);
    }
    public void Shape2SelectBtn(int num)
    {
        shape2SelectNum = num;
        for (int i = 0; i < 6; ++i)
        {
            for (int j = 0; j < 6; ++j)
                shape2Select.GetChild(j).gameObject.SetActive(false);
        }
        if (num < 0)
            return;
        for (int i = 0; i < 6; ++i)
            shape2Select.GetChild(num).gameObject.SetActive(true);
    }
    #endregion
    #region 문장
    [Header("Sentence")]
    public Transform[] sentenceQuestion;
    public Transform[] sentenceSelect;
    private List<int> sentenceOrder;
    private int sentenceAnswer = 0;
    private int sentenceNum = 0;

    public void SentenceStart()
    {
        SentenceReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[8], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void SentenceReset()
    {
        sentenceOrder = new List<int>();
        for (int i = 0; i < 3; ++i)
        {
            sentenceOrder.Add(Random.Range(0,6));
        }
        sentenceAnswer = 0;
        sentenceNum = 0;
        SentenceQuestOn();
        SentenceSelect(0);
    }
    public void SentenceQuestOn()
    {
        for(int i = 0; i< sentenceQuestion.Length;++i)
        {
            sentenceQuestion[i].parent.gameObject.SetActive(false);
            for (int j = 0; j < 6; ++j)
                sentenceQuestion[i].GetChild(j).gameObject.SetActive(false);
        }
        sentenceQuestion[sentenceNum].parent.gameObject.SetActive(true);
        sentenceQuestion[sentenceNum].GetChild(sentenceOrder[sentenceNum]).gameObject.SetActive(true);
    }
    public void SentenceSelect(int num)
    {
        sentenceAnswer += num;
        if (sentenceAnswer < 0)
            sentenceAnswer = 5;
        if (sentenceAnswer > 5)
            sentenceAnswer = 0;
        for(int i = 0; i< sentenceSelect.Length;++i)
        {
            for (int j = 0; j < 6; ++j)
                sentenceSelect[i].GetChild(j).gameObject.SetActive(false);

            sentenceSelect[i].GetChild(sentenceAnswer).gameObject.SetActive(true);
        }
    }
    public void SentenceNextLevel()
    {
        if (sentenceAnswer == sentenceOrder[sentenceNum])
            Score++;
        sentenceNum++;
        if (sentenceNum >= 3)
        {
            PatternStart();
            return;
        }
        sentenceAnswer = 0;
        SentenceSelect(0);
        SentenceQuestOn();
    }

    #endregion
    #region 패턴
    [Header("Pattern")]
    public GameObject[] patternPanel;
    public Transform[] patternQuestion;
    public TextMeshProUGUI[] patternText;
    public Transform patternColor;
    private int patternNum = 20;
    private List<int> patternOrder;
    private int patternLevel= 0;

    public void PatternStart()
    {
        PatternReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[9], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void PatternReset()
    {
        patternLevel = 0;
        patternNum = 20;
        patternOrder = new List<int>();
        for (int i = 0; i < 6; ++i)
        {
            patternOrder.Add(Random.Range(0, 4));
        }
        PatternMoveNum(0);
        for (int i = 0; i < patternPanel.Length; ++i)
            patternPanel[i].SetActive(false);
        patternPanel[patternLevel].SetActive(true);
        for (int i = 0; i < patternQuestion.Length; ++i)
        {
            for (int j = 0; j < patternQuestion[i].childCount; ++j)
                patternQuestion[i].GetChild(j).gameObject.SetActive(false);
            patternQuestion[i].GetChild(patternOrder[patternLevel]).gameObject.SetActive(true);
        }
    }
    public void PatternMoveNum(int num)
    {
        patternNum += num;
        if (patternNum < 0)
            patternNum = 0;
        if (patternNum > 99)
            patternNum = 0;
        for (int i = 0; i < patternText.Length; ++i)
            patternText[i].text = patternNum.ToString();
    }
    public void PatternMoveColor (int num)
    {
        patternNum += num;
        if (patternNum < 0)
            patternNum =  8;
        if (patternNum > 8)
            patternNum = 0;
        for (int i = 0; i < patternColor.childCount; ++i)
            patternColor.GetChild(i).gameObject.SetActive(false);
        patternColor.GetChild(patternNum).gameObject.SetActive(true);
    }
    public void PatternLevelUp()
    {
        if (patternLevel == 0)
        {
            switch (patternOrder[patternLevel])
            {
                case 0:
                    if (patternNum == 24)
                        Score++;
                    break;
                case 1:
                    if (patternNum == 17)
                        Score++;
                    break;
                case 2:
                    if (patternNum == 32)
                        Score++;
                    break;
                case 3:
                    if (patternNum == 40)
                        Score++;
                    break;
            }
        }
        if (patternLevel == 1)
        {
            switch (patternOrder[patternLevel])
            {
                case 0:
                    if (patternNum == 13)
                        Score++;
                    break;
                case 1:
                    if (patternNum == 9)
                        Score++;
                    break;
                case 2:
                    if (patternNum == 12)
                        Score++;
                    break;
                case 3:
                    if (patternNum == 15)
                        Score++;
                    break;
            }
        }
        if (patternLevel == 2)
        /*빨원         0
         * 파원        1
         * 노원        2
         * 빨네모     3
         * 파네모     4
         * 노네모     5
         * 빨세모     6
         * 파세모     7
         * 노세모     8
        */
        {
            switch (patternOrder[patternLevel])
            {
                case 0:
                    if (patternNum == 4)
                        Score++;
                    break;
                case 1:
                    if (patternNum == 2)
                        Score++;
                    break;
                case 2:
                    if (patternNum == 4)
                        Score++;
                    break;
                case 3:
                    if (patternNum == 2)
                        Score++;
                    break;
            }
        }

        patternLevel++;
        if (patternLevel == 3)
        {
            print("Next");
            return;
        }

        if (patternLevel == 2)
        {
            patternNum = 0;
            PatternMoveColor(0);
        }
        else
        {
            patternNum = 20;
            PatternMoveNum(0);
        }
        for (int i = 0; i < patternPanel.Length; ++i)
            patternPanel[i].SetActive(false);
        patternPanel[patternLevel].SetActive(true);
        for (int i = 0; i < patternQuestion.Length; ++i)
        {
            for (int j = 0; j < patternQuestion[i].childCount; ++j)
                patternQuestion[i].GetChild(j).gameObject.SetActive(false);
            patternQuestion[i].GetChild(patternOrder[patternLevel]).gameObject.SetActive(true);
        }
    }

    #endregion
}



