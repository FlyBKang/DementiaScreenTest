using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using UnityEngine.SceneManagement;
public class ScreenTestController : MonoBehaviour
{
    public int difficult = 0;
    public bool isKorean = true;
    public GameObject[] panelList;
    public PillarBoxCanvas PillarBox;
    public int Score = 0;
    private AudioSource mySound;
    private Stopwatch watch;
    public GameObject successPanel;
    public GameObject failPanel;
    public float resultTime = 0.2f;
    public GameObject levelPanel;
    private int panelCnt = 1;
    private void Awake()
    {
        mySound = GetComponent<AudioSource>();
        foreach (GameObject g in panelList)
            g.SetActive(false);
        panelList[0].SetActive(true);
        levelPanel.SetActive(false);
    }
    public void Exit()
    {
        Exit();
    }
    IEnumerator Success()
    {
        successPanel.SetActive(true);
        yield return new WaitForSeconds(resultTime);
        successPanel.SetActive(false);
    }
    IEnumerator Fail()
    {
        failPanel.SetActive(true);
        yield return new WaitForSeconds(resultTime);
        failPanel.SetActive(false);
    }
    #region 생년월일  
    [Header("Birth")]
    public int year, month, day;
    public TextMeshProUGUI yearTMP, monthTMP, dayTMP;
    public void StartBirthPanel(int n)
    {
        difficult = n;
        BirthReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
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
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
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

        if (!isKorean)
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
        //print(currentDay);
        StartStuffPanel();
    }
    #endregion

    #region 물건
    [Header("Stuff")]
    public GameObject[] stuffPicture;
    public float stuffShowTime = 3.0f;
    public GameObject stuffStartBtn;
    public List<int> stuffimgArr;
    public GameObject stuffAnswerPanel;
    public int[] stuffAnswer;
    public Transform stuffAnswerObj0, stuffAnswerObj1, stuffAnswerObj2;
    public TextMeshProUGUI stuffOrderText1, stuffOrderText2, stuffOrderText3;

    public void StartStuffPanel()
    {
        StuffReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
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

        if (isKorean)
        {
            if (0 == difficult)
            {
                stuffOrderText1.text = "2번째";
                stuffOrderText2.text = "4번째";
                stuffOrderText3.text = "6번째";

            }
            if (1 == difficult)
            {
                stuffOrderText1.text = "1번째";
                stuffOrderText2.text = "3번째";
                stuffOrderText3.text = "4번째";
            }
            if (2 == difficult)
            {
                stuffOrderText1.text = "1번째";
                stuffOrderText2.text = "2번째";
                stuffOrderText3.text = "3번째";
            }
        }
        else
        {

            if (0 == difficult)
            {
                stuffOrderText1.text = "2nd";
                stuffOrderText2.text = "4th";
                stuffOrderText3.text = "6th";

            }
            if (1 == difficult)
            {
                stuffOrderText1.text = "1st";
                stuffOrderText2.text = "3rd";
                stuffOrderText3.text = "4th";
            }
            if (2 == difficult)
            {
                stuffOrderText1.text = "1st";
                stuffOrderText2.text = "2nd";
                stuffOrderText3.text = "3rd";
            }
        }
    }
    public void ShowImage()
    {
        stuffStartBtn.SetActive(false);
        StartCoroutine(ShowIMG());
        IEnumerator ShowIMG()
        {
            int level = 6;
            if (0 == difficult)
                level = 6;
            if (1 == difficult)
                level = 4;
            if (2 == difficult)
                level = 3;
            WaitForSeconds wfs = new WaitForSeconds(stuffShowTime);
            for (int j = 0; j < level; ++j)
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
        if (difficult == 2)//0,1,2
        {
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
        }
        if(difficult == 1)//0,2,3
        {
            for (int i = 0; i < 3; ++i)
            {
                if (stuffAnswer[i] == stuffimgArr[0])
                    check0 = true;
                if (stuffAnswer[i] == stuffimgArr[2])
                    check1 = true;
                if (stuffAnswer[i] == stuffimgArr[3])
                    check2 = true;
            }
            if (stuffAnswer[0] == stuffimgArr[0])
                if (stuffAnswer[1] == stuffimgArr[2])
                    if (stuffAnswer[2] == stuffimgArr[3])
                        order = true;
        }
        if (difficult == 0)//1,3,5
        {
            for (int i = 0; i < 3; ++i)
            {
                if (stuffAnswer[i] == stuffimgArr[1])
                    check0 = true;
                if (stuffAnswer[i] == stuffimgArr[3])
                    check1 = true;
                if (stuffAnswer[i] == stuffimgArr[5])
                    check2 = true;
            }
            if (stuffAnswer[0] == stuffimgArr[1])
                if (stuffAnswer[1] == stuffimgArr[3])
                    if (stuffAnswer[2] == stuffimgArr[5])
                        order = true;
        }
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
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void CalcReset()
    {
        calcNumber = 100;
        if (difficult == 0)
        {
            calcAnswer1 = 90;
            calcAnswer2 = 60;
            calcAnswer3 = 70;
            calcAnswer4 = 90;
            random1 = Random.Range(5, 9);
            random2 = Random.Range(26, 29);
            random3 = Random.Range(5, 9);
            random4 = Random.Range(26, 29);
        }
        if(difficult == 1)
        {
            calcAnswer1 = 90;
            calcAnswer2 = 70;
            calcAnswer3 = 80;
            calcAnswer4 = 90;
            random1 = Random.Range(5, 9);
            random2 = Random.Range(16, 19);
            random3 = Random.Range(5, 9);
            random4 = Random.Range(16, 19);
        }
        if(difficult == 2)
        {
            calcAnswer1 = 90;
            calcAnswer2 = 90;
            calcAnswer3 = 90;
            calcAnswer4 = 90;
            random1 = Random.Range(5, 9);
            random2 = Random.Range(6, 9);
            random3 = Random.Range(5, 9);
            random4 = Random.Range(6, 9);
        }

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
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
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
        {
            Score++;
            StartCoroutine(Success());
        }
        else
        {
            StartCoroutine(Fail());
        }
        cubeQuestionCnt++;
        cubeBtnSelect = -1;
        CubeSelectCube(-1);

        if (cubeQuestionCnt == 1)
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
    private int shape1SoundCnt = 0;
    public Button shape1PlatBtn;
    public void Shape1Start()
    {
        Shape1Reset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void Shape1Reset()
    {
        shape1PlatBtn.interactable = true;
        shape1SoundCnt = 0;
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
            shape1SoundCnt++;
            mySound.clip = shape1Audio[shape1Order[shape1QuestNum]];
            mySound.Play();

        if (difficult == 0)
        {
            if (shape1SoundCnt > 0)
                shape1PlatBtn.interactable = false;
        }
        else
        {
            if (shape1SoundCnt > 1)
                shape1PlatBtn.interactable = false;
        }
    }
    public void Shape1NextLevel()
    {
        if (shape1Order[shape1QuestNum] == shape1SelectNum)
        {
            StartCoroutine(Success());
            Score++;
        }
        else
            StartCoroutine(Fail());
        shape1QuestNum++;
        if (shape1QuestNum == 1)
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
    private int shape2SoundCnt = 0;
    public Button shape2PlatBtn;
    public void Shape2Start()
    {
        Shape2Reset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void Shape2Reset()
    {
        shape2PlatBtn.interactable = true;
        shape2SoundCnt = 0;
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
        shape2SoundCnt++;
        mySound.clip = shape2Audio[shape2Order[shape2QuestNum]];
        mySound.Play();

        if (difficult == 0)
        {
            if (shape2SoundCnt > 0)
                shape2PlatBtn.interactable = false;
        }
        else
        {
            if (shape2SoundCnt > 1)
                shape2PlatBtn.interactable = false;
        }
    }
    public void Shape2NextLevel()
    {
        if (shape2Order[shape2QuestNum] == shape2SelectNum)
        {
            Score++;
            StartCoroutine(Success());
        }
        else
        {
            StartCoroutine(Fail());
        }
        shape2QuestNum++;
        if (shape2QuestNum == 1)
        {
            StartStuff2Panel();
        }
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


    #region 물건2
    [Header("Stuff2")]
    public GameObject[] stuff2Picture;    
    //public float stuff2ShowTime = 3.0f;
    public GameObject stuff2StartBtn;
    public List<int> stuff2imgArr;
    public GameObject stuff2AnswerPanel;
    public int[] stuff2Answer;
    public Transform stuff2AnswerObj0, stuff2AnswerObj1, stuff2AnswerObj2;
    public TextMeshProUGUI stuff2OrderText1, stuff2OrderText2, stuff2OrderText3;

    public void StartStuff2Panel()
    {
        Stuff2Reset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void Stuff2Reset()
    {
        stuff2imgArr = new List<int>();
        for (int i = 0; i < 10; ++i)
        {
            stuff2imgArr.Add(i);
            stuff2Picture[i].SetActive(false);
        }
        Util.ShuffleList(stuff2imgArr);
        stuff2Answer = new int[] { 0, 1, 2 };
        stuff2AnswerPanel.SetActive(false);
        Stuff2ImageChage(0);
        stuff2StartBtn.SetActive(true);

        if (isKorean)
        {
            if (0 == difficult)
            {
                stuff2OrderText1.text = "2번째";
                stuff2OrderText2.text = "4번째";
                stuff2OrderText3.text = "6번째";

            }
            if (1 == difficult)
            {
                stuff2OrderText1.text = "1번째";
                stuff2OrderText2.text = "3번째";
                stuff2OrderText3.text = "4번째";
            }
            if (2 == difficult)
            {
                stuff2OrderText1.text = "1번째";
                stuff2OrderText2.text = "2번째";
                stuff2OrderText3.text = "3번째";
            }
        }
        else
        {

            if (0 == difficult)
            {
                stuff2OrderText1.text = "1st";
                stuff2OrderText2.text = "3rd";
                stuff2OrderText3.text = "6th";

            }
            if (1 == difficult)
            {
                stuff2OrderText1.text = "1st";
                stuff2OrderText2.text = "2nd";
                stuff2OrderText3.text = "4th";
            }
            if (2 == difficult)
            {
                stuff2OrderText1.text = "1st";
                stuff2OrderText2.text = "2nd";
                stuff2OrderText3.text = "3rd";
            }
        }
    }
    public void ShowImage2()
    {
        stuff2StartBtn.SetActive(false);
        StartCoroutine(ShowIMG());
        IEnumerator ShowIMG()
        {
            int level = 6;
            if (0 == difficult)
                level = 6;
            if (1 == difficult)
                level = 4;
            if (2 == difficult)
                level = 3;
            WaitForSeconds wfs = new WaitForSeconds(stuffShowTime);
            for (int j = 0; j < level; ++j)
            {
                for (int i = 0; i < 10; ++i)
                    stuff2Picture[i].SetActive(false);
                stuff2Picture[stuff2imgArr[j]].SetActive(true);

                yield return wfs;
            }
            stuff2AnswerPanel.SetActive(true);
        }
    }
    public void Stuff2ImageChage(int n) //{1,2,3,-1,-2,-3}
    {
        switch (n)
        {
            case 1:
                stuff2Answer[0]++;
                if (stuff2Answer[0] > 9)
                    stuff2Answer[0] = 0;
                break;
            case -1:
                stuff2Answer[0]--;
                if (stuff2Answer[0] < 0)
                    stuff2Answer[0] = 9;
                break;
            case 2:
                stuff2Answer[1]++;
                if (stuff2Answer[1] > 9)
                    stuff2Answer[1] = 0;
                break;
            case -2:
                stuff2Answer[1]--;
                if (stuff2Answer[1] < 0)
                    stuff2Answer[1] = 9;
                break;
            case 3:
                stuff2Answer[2]++;
                if (stuff2Answer[2] > 9)
                    stuff2Answer[2] = 0;
                break;
            case -3:
                stuff2Answer[2]--;
                if (stuff2Answer[2] < 0)
                    stuff2Answer[2] = 9;
                break;
            default:
                break;
        }
        for (int i = 0; i < stuff2AnswerObj0.childCount; ++i)
        {
            stuff2AnswerObj0.GetChild(i).gameObject.SetActive(false);
            stuff2AnswerObj1.GetChild(i).gameObject.SetActive(false);
            stuff2AnswerObj2.GetChild(i).gameObject.SetActive(false);
        }
        stuff2AnswerObj0.GetChild(stuff2Answer[0]).gameObject.SetActive(true);
        stuff2AnswerObj1.GetChild(stuff2Answer[1]).gameObject.SetActive(true);
        stuff2AnswerObj2.GetChild(stuff2Answer[2]).gameObject.SetActive(true);
    }
    public void Stuff2Check()
    {
        bool check0, check1, check2, order;
        check0 = check1 = check2 = order = false;
        if (difficult == 2)//0,1,2
        {
            for (int i = 0; i < 3; ++i)
            {
                if (stuff2Answer[i] == stuff2imgArr[0])
                    check0 = true;
                if (stuff2Answer[i] == stuff2imgArr[1])
                    check1 = true;
                if (stuff2Answer[i] == stuff2imgArr[2])
                    check2 = true;
            }
            if (stuff2Answer[0] == stuff2imgArr[0])
                if (stuff2Answer[1] == stuff2imgArr[1])
                    if (stuff2Answer[2] == stuff2imgArr[2])
                        order = true;
        }
        if (difficult == 1)//0,1,3
        {
            for (int i = 0; i < 3; ++i)
            {
                if (stuff2Answer[i] == stuff2imgArr[0])
                    check0 = true;
                if (stuff2Answer[i] == stuff2imgArr[1])
                    check1 = true;
                if (stuff2Answer[i] == stuff2imgArr[3])
                    check2 = true;
            }
            if (stuff2Answer[0] == stuff2imgArr[0])
                if (stuff2Answer[1] == stuff2imgArr[1])
                    if (stuff2Answer[2] == stuff2imgArr[3])
                        order = true;
        }
        if (difficult == 0)//0,2,5
        {
            for (int i = 0; i < 3; ++i)
            {
                if (stuff2Answer[i] == stuff2imgArr[0])
                    check0 = true;
                if (stuff2Answer[i] == stuff2imgArr[2])
                    check1 = true;
                if (stuff2Answer[i] == stuff2imgArr[5])
                    check2 = true;
            }
            if (stuff2Answer[0] == stuff2imgArr[0])
                if (stuff2Answer[1] == stuff2imgArr[2])
                    if (stuff2Answer[2] == stuff2imgArr[5])
                        order = true;
        }
        if (check0)
            Score++;
        if (check1)
            Score++;
        if (check2)
            Score++;
        if (order)
            Score++;
        SentenceStart();
    }

    #endregion


    #region 문장
    [Header("Sentence")]
    public Transform[] sentenceQuestion;
    public Transform[] sentenceSelect;
    private List<int> sentenceOrder;
    private int sentenceAnswer = 0;
    private int sentenceNum = 0;
    public Button sentenceSoundBtn1, sentenceSoundBtn2;
    private int sentenceSoundCnt1, sentenceSoundCnt2;
    public AudioClip[] sentenceSound1, sentenceSound2;

    public void SentenceStart()
    {
        SentenceReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void SentenceReset()
    {
        sentenceSoundCnt1 = sentenceSoundCnt2 = 0;
        sentenceSoundBtn1.interactable = true;
        sentenceSoundBtn2.interactable = true;
        sentenceOrder = new List<int>();
        for (int i = 0; i < 3; ++i)
        {
            sentenceOrder.Add(Random.Range(0, 6));
        }
        sentenceAnswer = 0;
        sentenceNum = 0;
        SentenceQuestOn();
        SentenceSelectOri(0);
        SentenceSelectNew(-1);
    }
    public void SentenceQuestOn()
    {
        for (int i = 0; i < sentenceQuestion.Length; ++i)
        {
            sentenceQuestion[i].gameObject.SetActive(false);
        }
        sentenceQuestion[sentenceNum].gameObject.SetActive(true);
         if (sentenceNum > 1)
        {
            sentenceAnswer = 0;
            SentenceSelectOri(0);
            sentenceQuestion[sentenceNum].GetChild(0).GetChild(0).GetChild(sentenceOrder[sentenceNum]).gameObject.SetActive(true);
        }
    }
    public void SentenceSelectOri(int num)
    {
        sentenceAnswer += num;
        if (sentenceAnswer > 5)
            sentenceAnswer = 0;
        if (sentenceAnswer < 0)
            sentenceAnswer = 5;

        for (int i = 0; i < sentenceSelect.Length; ++i)
        {
            for (int j = 0; j < 6; ++j)
                sentenceSelect[i].GetChild(j).gameObject.SetActive(false);

            sentenceSelect[i].GetChild(sentenceAnswer).gameObject.SetActive(true);
        }
    }
    public void SentenceSelectNew(int num)
    {
        sentenceAnswer = num;        
        for (int i = 0; i < sentenceSelect.Length; ++i)
        {
            for (int j = 0; j < 6; ++j)
                sentenceSelect[i].GetChild(j).gameObject.SetActive(false);

            if (sentenceAnswer != -1)
                sentenceSelect[i].GetChild(sentenceAnswer).gameObject.SetActive(true);
        }
    }
    public void SentenceNextLevel()
    {
        if (sentenceAnswer == sentenceOrder[sentenceNum])
        {
            Score++;
            StartCoroutine(Success());
        }
        else
        {
            StartCoroutine(Fail());
        }
        sentenceNum++;
        if (sentenceNum >= 3)
        {
            PatternStart();
            return;
        }
        sentenceAnswer = 0;
        SentenceSelectOri(0);
        SentenceSelectNew(-1);
        SentenceQuestOn();
    }
    public void SentencePlaySound(int num)
    {
        if(num == 0)
        {
            mySound.clip = sentenceSound1[sentenceOrder[sentenceNum]];
            mySound.Play();
            sentenceSoundCnt1++;
            if (difficult == 0)
            {
                if (sentenceSoundCnt1 > 0)
                    sentenceSoundBtn1.interactable = false;
            }
            else
            {
                if (sentenceSoundCnt1 > 1)
                    sentenceSoundBtn1.interactable = false;
            }
        }
        if(num == 1)
        {
            mySound.clip = sentenceSound2[sentenceOrder[sentenceNum]];
            mySound.Play();
            sentenceSoundCnt2++;
            if (difficult == 0)
            {
                if (sentenceSoundCnt2 > 0)
                    sentenceSoundBtn2.interactable = false;
            }
            else
            {
                if (sentenceSoundCnt2 > 1)
                    sentenceSoundBtn2.interactable = false;
            }
        }
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
    private int patternLevel = 0;

    public void PatternStart()
    {
        PatternReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
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
            if(difficult == 0)
                patternQuestion[i].GetChild(patternOrder[patternLevel]).gameObject.SetActive(true);
            else if(difficult == 1)
                patternQuestion[i].GetChild(patternOrder[patternLevel]+4).gameObject.SetActive(true);
            else
                patternQuestion[i].GetChild(patternOrder[patternLevel] + 8).gameObject.SetActive(true);
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
    public void PatternMoveColor(int num)
    {
        patternNum += num;
        if (patternNum < 0)
            patternNum = 8;
        if (patternNum > 8)
            patternNum = 0;
        for (int i = 0; i < patternColor.childCount; ++i)
            patternColor.GetChild(i).gameObject.SetActive(false);
        patternColor.GetChild(patternNum).gameObject.SetActive(true);
    }
    public void PatternLevelUp()
    {
        int tempScore = Score;
        if (patternLevel == 0)
        {
            if (difficult == 0)
            {
                switch (patternOrder[patternLevel])
                {
                    case 0:
                        if (patternNum == 18)
                            Score++;
                        break;
                    case 1:
                        if (patternNum == 12)
                            Score++;
                        break;
                    case 2:
                        if (patternNum == 34)
                            Score++;
                        break;
                    case 3:
                        if (patternNum == 14)
                            Score++;
                        break;
                }
            }
            if(difficult == 1 || difficult == 2)
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
        }
        if (patternLevel == 1)
        {
            if (difficult == 0)
            {
                switch (patternOrder[patternLevel])
                {
                    case 0:
                        if (patternNum == 92)
                            Score++;
                        break;
                    case 1:
                        if (patternNum == 27)
                            Score++;
                        break;
                    case 2:
                        if (patternNum == 77)
                            Score++;
                        break;
                    case 3:
                        if (patternNum == 23)
                            Score++;
                        break;
                }
            }
            else
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
            if (difficult != 2)
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
            else
            {
                switch (patternOrder[patternLevel])
                {

                    case 0:
                        if (patternNum == 2)
                            Score++;
                        break;
                    case 1:
                        if (patternNum == 4)
                            Score++;
                        break;
                    case 2:
                        if (patternNum == 2)
                            Score++;
                        break;
                    case 3:
                        if (patternNum == 3)
                            Score++;
                        break;
                }
            }
        }

        if (tempScore == Score)
            StartCoroutine(Fail());
        else
            StartCoroutine(Success());

        patternLevel++;
        if (patternLevel == 3)
        {
            StroopInit();
            StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
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

            if (difficult == 0)
                patternQuestion[i].GetChild(patternOrder[patternLevel]).gameObject.SetActive(true);
            else if (difficult == 1)
                patternQuestion[i].GetChild(patternOrder[patternLevel] + 4).gameObject.SetActive(true);
            else
                patternQuestion[i].GetChild(patternOrder[patternLevel] + 8).gameObject.SetActive(true);
        }
    }

    #endregion

    #region 스트룹 검사
    [Header("Stroop")]
    public GameObject stroopFisrtPanel;
    public GameObject stroopPanel;
    public GameObject stroopResultPanel;
    public TextMeshProUGUI stroopResultText;
    private string[] stroopWord;
    private Color[] stroopColor = new Color[]{
        Color.red,
        Color.blue,
        Color.black,
        Color.green
    };

    private List<int> stroopWroongOrder1;
    private List<int> stroopWroongOrder2;
    private List<int> stroopWroongOrder3;
    private List<int> stroopOrder;
    public TextMeshProUGUI stroopText;
    public Button stroopButtonL;
    public Button stroopButtonR;
    public GameObject stroopSelectL;
    public GameObject stroopSelectR;
    private int stroopSelect = 0;
    public int stroopScore = 0;
    public float stroopTime;
    public void StroopInit()
    {
        if(isKorean)
        {
            stroopWord = new string[]{
            "빨간색",
            "파란색",
            "검정색",
            "초록색"
            };
        }
        else
        {
            stroopWord = new string[]{
            "Red",
            "Blue",
            "Black",
            "Green"
            };
        }
        StroopReset();
    }
    public void StroopReset()
    {
        stroopScore = 0;
        stroopFisrtPanel.SetActive(true);
        stroopPanel.SetActive(false);
        stroopResultPanel.SetActive(false);
        StroopButton(0);
        stroopOrder = new List<int>();
        stroopWroongOrder1 = new List<int>();
        stroopWroongOrder2 = new List<int>();
        stroopWroongOrder3 = new List<int>();
        for (int i = 0; i < 30; ++i)
        {
            stroopOrder.Add(Random.Range(0, 4));
        }
        for (int i = 0; i < 10; ++i)
        {
            stroopWroongOrder1.Add(i);
            stroopWroongOrder2.Add(i + 10);
            stroopWroongOrder3.Add(i + 20);
        }
        Util.ShuffleList(stroopWroongOrder1);
        Util.ShuffleList(stroopWroongOrder2);
        stroopOrder[stroopWroongOrder1[0]] = 4;
        stroopOrder[stroopWroongOrder1[1]] = 4;

        stroopOrder[stroopWroongOrder2[0]] = 4;
        stroopOrder[stroopWroongOrder2[1]] = 4;
        stroopOrder[stroopWroongOrder2[2]] = 4;
        stroopOrder[stroopWroongOrder2[3]] = 4;

        stroopOrder[stroopWroongOrder3[0]] = 4;
        stroopOrder[stroopWroongOrder3[1]] = 4;
        stroopOrder[stroopWroongOrder3[2]] = 4;
        stroopOrder[stroopWroongOrder3[3]] = 4;

        watch = new Stopwatch();
    }
    public void StroopButton(int num)
    {
        stroopSelectL.gameObject.SetActive(false);
        stroopSelectR.gameObject.SetActive(false);
        stroopSelect = num;
        if (num == 0)
            return;
        if (num == 1)
            stroopSelectL.gameObject.SetActive(true);
        else
            stroopSelectR.gameObject.SetActive(true);
    }
    public void StroopGameStart()
    {
        //StroopReset();
        watch.Start();
        stroopPanel.SetActive(true);
        StartCoroutine(StroopGame());

        IEnumerator StroopGame()
        {
            WaitForSeconds clickBlock = new WaitForSeconds(resultTime);
            successPanel.SetActive(false);
            failPanel.SetActive(false);
            stroopButtonL.interactable = false;
            stroopButtonR.interactable = false;

            for (int cnt = 0; cnt < 30; ++cnt)
            {
                StroopButton(0);
                if (stroopOrder[cnt] != 4)
                {
                    stroopText.text = stroopWord[stroopOrder[cnt]];
                    stroopText.color = stroopColor[stroopOrder[cnt]];
                }
                else
                {
                    int tempNum1;
                    int tempNum2;
                    while (true)
                    {
                        tempNum1 = Random.Range(0, 4);
                        tempNum2 = Random.Range(0, 4);
                        if (tempNum1 != tempNum2)
                        {
                            stroopText.text = stroopWord[tempNum1];
                            stroopText.color = stroopColor[tempNum2];
                            break;
                        }
                    }

                }
                yield return clickBlock;
                stroopButtonL.interactable = true;
                stroopButtonR.interactable = true;
                if (difficult == 0)
                {
                    for (int i = 0; i < 50 - cnt; ++i)
                    {
                        if (stroopSelect != 0)
                            break;
                        yield return new WaitForSeconds(0.05f);
                    }
                }
                else if (difficult == 1)
                {
                    for (int i = 0; i < 60 - cnt; ++i)
                    {
                        if (stroopSelect != 0)
                            break;
                        yield return new WaitForSeconds(0.05f);
                    }
                }
                else if (difficult == 2)
                {
                    for (int i = 0; i < 70 - cnt; ++i)
                    {
                        if (stroopSelect != 0)
                            break;
                        yield return new WaitForSeconds(0.05f);
                    }
                }
                stroopButtonL.interactable = false;
                stroopButtonR.interactable = false;

                if (stroopOrder[cnt] == 4)
                {
                    if (2 == stroopSelect)
                    {
                        stroopScore++;
                        StartCoroutine(Success());
                    }
                    else
                        StartCoroutine(Fail());
                }
                else
                {
                    if (1 == stroopSelect)
                    {
                        stroopScore++;
                        StartCoroutine(Success());
                    }
                    else
                        StartCoroutine(Fail());
                }
            }
            watch.Stop();
            stroopTime = watch.ElapsedMilliseconds;
            stroopTime = stroopTime / 1000;
            stroopResultPanel.SetActive(true);
            stroopResultText.text = stroopScore.ToString() + " / 30";
        }
    }
    public void StroopEnd()
    {
        WitInit();
    }
    #endregion

    #region 순발력
    [Header("Wit")]
    public GameObject witStartPanel;
    public GameObject witGamePanel;
    public RectTransform witBall;
    public Image witButton;
    public GameObject witNextBtn;
    private Vector3 witOriPos;
    private int witCnt = 0;
    public bool witBallMove = false;
    private float[] witTime = new float[]{
        0.0f,
        0.0f,
        0.0f,
        0.0f,
        0.0f
    };

    public void WitInit()
    {
        witStartPanel.SetActive(true);
        witGamePanel.SetActive(false);
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void WitStart()
    {
        witReset();
        witButton.raycastTarget = false;
        witGamePanel.SetActive(true);
        WitBallReset();
        WitBallMove();
    }
    public void witReset()
    {
        witBallMove = false;
        witCnt = 0;
        witNextBtn.SetActive(false);
    }
    public void WitBallReset()
    {
        witButton.raycastTarget = false;
        witBall.GetComponent<Image>().color = Color.black;
        watch = new Stopwatch();
        witOriPos = new Vector3(0, -100, 0);
        witBall.localPosition = witOriPos;
        watch.Start();
    }
    private Vector3[] WitPosR = new Vector3[]
    {
        new Vector3(600,125,0),
        new Vector3(500,75,0),
        new Vector3(600,-100,0),
        new Vector3(500,-275,0),
        new Vector3(600,-325,0)

    };
    private Vector3[] WitPosL = new Vector3[]
    {
        new Vector3(-600,125,0),
        new Vector3(-500,75,0),
        new Vector3(-600,-100,0),
        new Vector3(-500,-275,0),
        new Vector3(-600,-325,0)
    };
    public void WitBallMove()
    {        
        witBallMove = true;
        StartCoroutine(WitBallMove());
        StartCoroutine(WitColorChange());
        IEnumerator WitBallMove()//-650,650,150,-350
        {
            WaitForSeconds witTime = new WaitForSeconds(0.03f);
            int tempWitTime = 40 + ((difficult) * 10)  - ((witCnt+1)*4);

            Vector3 randomPos = WitPosR[Random.Range(0, 5)];
            Vector3 tempDir = (randomPos - witOriPos) / tempWitTime;
            int cnt = 0;
            int cnt2 = 0;
            while (witBallMove)
            {
                witBall.transform.localPosition += tempDir;
                yield return witTime;
                cnt++;
                if (cnt == tempWitTime)
                {
                    cnt2++;
                    cnt2 = cnt2 % 2;
                    tempWitTime = 40 + ((difficult) * 10) - ((witCnt + 1) * 4);
                    if (cnt2 == 0)
                        randomPos = WitPosR[Random.Range(0, 5)];
                    else
                        randomPos = WitPosL[Random.Range(0, 5)];
                    tempDir = (randomPos - witBall.transform.localPosition) / tempWitTime;
                    cnt = 0;
                }
            }
        }
        IEnumerator WitColorChange()
        {
            int tempWitTime = Random.Range(15, 30);
            int cnt = 0;
            WaitForSeconds witTime = new WaitForSeconds(0.2f);
            while (witBallMove)
            {
                yield return witTime;
                cnt++;
                if (cnt == tempWitTime)
                {
                    if (witCnt == 0)
                        witBall.GetComponent<Image>().color = Color.red;
                    if (witCnt == 1)
                        witBall.GetComponent<Image>().color = Color.blue;
                    if (witCnt == 2)
                        witBall.GetComponent<Image>().color = Color.green;
                    if (witCnt == 3)
                        witBall.GetComponent<Image>().color = Color.red;
                    if (witCnt == 4)
                        witBall.GetComponent<Image>().color = Color.blue;

                    witButton.raycastTarget = true;
                    break;
                }
            }
        }
    }
    public void WitBallClick()
    {
        witBallMove = false;
        watch.Stop();
        witTime[witCnt] = watch.ElapsedMilliseconds;
        witCnt++;
        witNextBtn.SetActive(true);
    }
    public void WitNextLevel()
    {
        if (witCnt > 4)
        {
            JyroInit();
            return;
        }
        WitBallReset();
        WitBallMove();
        witNextBtn.SetActive(false);
    }

    #endregion

    #region 자이로센서

    [Header("JyroSensor")]
    public GameObject jyroStartPanel;
    public GameObject jyroGamePanel;
    public GameObject jyroHolder;
    public GameObject[] jyroGround;
    public JyroBall jyroBall;
    private int jyroCnt = 0;
    private bool jyroDoubleCheck = false;
    private float[] jyroTime = new float[]{
        0.0f,
        0.0f,
        0.0f,
        0.0f,
        0.0f
    };
    public void JyroInit()
    {
        jyroStartPanel.SetActive(true);
        jyroGamePanel.SetActive(false);
        JyroHolderOn(true);
        jyroBall.isPlaying = false;
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void JyroReset()
    {
        jyroBall.isPlaying = false;
        jyroBall.ResetPos();
        JyroHolderOn(true);
    }
    public void JyroStart()
    {
        jyroBall.isPlaying = true;
        jyroBall.ResetPos();
        jyroGamePanel.SetActive(true);
        for (int i = 0; i < 5; ++i)
            jyroGround[i].SetActive(false);
        jyroGround[jyroCnt].SetActive(true);
    }
    public void JyroHolderOn(bool check)
    {
        jyroHolder.SetActive(check);
        if (!check)
            jyroDoubleCheck = false;
    }
    public void JyroGameStart()
    {
        watch = new Stopwatch();
        watch.Start();
        JyroHolderOn(false);
    }
    public void JyroEnd()
    {
        if (jyroDoubleCheck)
            return;
        watch.Stop();
        jyroTime[jyroCnt] = watch.ElapsedMilliseconds;
        JyroReset();
        jyroCnt++;
        if (jyroCnt > 4)
        {
            jyroStartPanel.SetActive(false);
            jyroGamePanel.SetActive(false);
            PianoStart();
            return;
        }
            
        JyroStart();
        jyroDoubleCheck = true;
    }
    #endregion

    #region 피아노
    [Header("Piano")]
    public AudioClip[] pianoSound;
    private List<int> pianoOrder;
    private List<int> pianoUpdown;
    private int pianoCnt = 0;
    private int pianoScore = 0;
    public int pianoSelect = 3; //0 낮은음 1같은음 2높은음
    public GameObject[] pianoSelectImage;
    public GameObject pianoResult;
    public TextMeshProUGUI pianoResultText;
    private int pianoHint1, pianoHint2;
    public Button pianoPlayBtn1, pianoPlayBtn2;
    public void PianoStart()
    {
        PianoReset();
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void PianoReset()
    {
        pianoHint1 = pianoHint2 = 0;
        pianoPlayBtn1.interactable = true;
        pianoPlayBtn2.interactable = true;
        pianoResult.SetActive(false);
        pianoCnt = 0;
        pianoScore = 0;
        PianoSelect(3);
        pianoOrder = new List<int>();
        pianoUpdown = new List<int>();

        pianoOrder.Add(3);
        pianoUpdown.Add(2);//높 3

        pianoOrder.Add(4);
        pianoUpdown.Add(0);//낮 3

        pianoOrder.Add(6);
        pianoUpdown.Add(0);//낮 2

        pianoOrder.Add(1);
        pianoUpdown.Add(2);//높 2

        pianoOrder.Add(2);
        pianoUpdown.Add(0);//낮 1

        pianoOrder.Add(7);
        pianoUpdown.Add(1);//같

        pianoOrder.Add(5);
        pianoUpdown.Add(2);//높 1


        //Util.ShuffleList(pianoOrder);
        //Util.ShuffleList(pianoUpdown);
    }
    public void PianoSelect(int num)
    {
        pianoSelect = num;
        for (int i = 0; i < pianoSelectImage.Length; ++i)
            pianoSelectImage[i].SetActive(false);
        if (num > 2)
            return;
        pianoSelectImage[num].SetActive(true);
    }
    public void PianoPlayFirst()
    {
        pianoHint1++;        
        if (pianoHint1 > difficult)
        {
            pianoPlayBtn1.interactable = false;
        }
        mySound.clip = pianoSound[pianoOrder[pianoCnt]];
        mySound.volume = 0.7f;
        mySound.Play();
    }
    public void PianoPlayQuest()
    {
        pianoHint2++;
        if (pianoHint2 > 0)
        {
            pianoPlayBtn2.interactable = false;
        }
        if (pianoCnt < 2)
        {
            if (pianoUpdown[pianoCnt] == 0)
                mySound.clip = pianoSound[pianoOrder[pianoCnt] - 3];
            if (pianoUpdown[pianoCnt] == 1)
                mySound.clip = pianoSound[pianoOrder[pianoCnt]];
            if (pianoUpdown[pianoCnt] == 2)
                mySound.clip = pianoSound[pianoOrder[pianoCnt] + 3];
        }
        else if (pianoCnt < 4)
        {
            if (pianoUpdown[pianoCnt] == 0)
                mySound.clip = pianoSound[pianoOrder[pianoCnt] - 2];
            if (pianoUpdown[pianoCnt] == 1)
                mySound.clip = pianoSound[pianoOrder[pianoCnt]];
            if (pianoUpdown[pianoCnt] == 2)
                mySound.clip = pianoSound[pianoOrder[pianoCnt] + 2];
        }
        else
        {
            if (pianoUpdown[pianoCnt] == 0)
                mySound.clip = pianoSound[pianoOrder[pianoCnt] - 1];
            if (pianoUpdown[pianoCnt] == 1)
                mySound.clip = pianoSound[pianoOrder[pianoCnt]];
            if (pianoUpdown[pianoCnt] == 2)
                mySound.clip = pianoSound[pianoOrder[pianoCnt] + 1];
        }

        mySound.volume = 0.7f;
        mySound.Play();
    }
    public void PianoCheck()
    {
        pianoHint1 = pianoHint2 = 0;
        pianoPlayBtn1.interactable = true;
        pianoPlayBtn2.interactable = true;
        if (pianoUpdown[pianoCnt] == pianoSelect)
        {
            StartCoroutine(Success());
            pianoScore++;
        }
        else
            StartCoroutine(Fail());

        pianoCnt++;
        PianoSelect(3);

        if (pianoCnt > 6)
        {
            pianoResult.SetActive(true);
            pianoResultText.text = pianoScore.ToString() +" / "+pianoCnt.ToString();
        }
    }
    #endregion

    #region 결과
    [Header("Result")]
    public TextMeshProUGUI resultScore;
    public TextMeshProUGUI resultText1;
    public TextMeshProUGUI resultText2;
    //public GameObject ResultPanel;
    public void OpenResult()
    {
        if (Score > 17)
        {
            resultScore.color = Color.blue;
            resultText1.color = Color.blue;
            if (isKorean)
            {
                resultText1.text = "양호";
                resultText2.text = "아직은 치매 걱정이 없습니다.";
            }
            else
            {
                resultText1.text = "Good";
                resultText2.text = "You don't have to worry about dementia yet.";
            }
        }
        else if (Score > 13)
        {
            resultScore.color = new Color(1.0f, 0.48f, 0.0f);
            resultText1.color = new Color(1.0f, 0.48f, 0.0f);

            if (isKorean)
            {
                resultText1.text = "주의";
                resultText2.text = "치매 발병에 주의하시고\n훈련을 하는 것을 권합니다.";
            }
            else
            {
                resultText1.text = "moderate";
                resultText2.text = "You are advised to watch out\nfor developing dementia and train.";
            }

        }
        else
        {
            resultScore.color = Color.red;
            resultText1.color = Color.red;

            if (isKorean)
            {
                resultText1.text = "의심";
                resultText2.text = "치매검사를 받아보시기를 권합니다.";
            }
            else
            {
                resultText1.text = "Serious";
                resultText2.text = "We think you need a professional dementia test.";
            }
        }

        resultScore.text = (Score).ToString() +" / 25";
        StartCoroutine(PillarBox.PanelAnimationCoroutine(panelList[panelCnt++], PillarBox.PanelBottomPosition, PillarBox.PanelCenterPosition));
    }
    public void CloseResult()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}






