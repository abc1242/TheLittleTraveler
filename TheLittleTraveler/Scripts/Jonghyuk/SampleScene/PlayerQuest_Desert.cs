using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerQuest_Desert : MonoBehaviour
{
    public static bool Desert = false;

    [SerializeField]
    public Text talkTxt;
    [SerializeField]
    public Text toolTxt;
    [SerializeField]
    public Text findTxt;
    [SerializeField]
    public Text wellTxt;
    [SerializeField]
    public Text finalTxt;
    [SerializeField]
    public Text starHint_desert;

    [SerializeField]
    private GameObject starwalk1;
    [SerializeField]
    private GameObject starwalk2;
    [SerializeField]
    private GameObject starwalk3;
    [SerializeField]
    private GameObject starwalk4;
    [SerializeField]
    private GameObject starwalk5;
    [SerializeField]
    private GameObject starwalk6;
    [SerializeField]
    private GameObject starwalk7;
    [SerializeField]
    private GameObject starwalk8;
    [SerializeField]
    private GameObject starwalk9;

    [SerializeField]
    private GameObject star1;
    [SerializeField]
    private GameObject star2;
    [SerializeField]
    private GameObject star3;
    [SerializeField]
    private GameObject star4;
    [SerializeField]
    private GameObject explode;
    public static bool EndDesertQuest = false;
    public static bool DesertQuestEnd = false;

    public bool OasisMeet;

    void Start()
    {
        B612Animation.B612 = false;
        B612back.B612_back = false;
        PlayerQuest_Forest.Forest = false;
        PlayerQuest_Forest_Back.Forest_back = false;
        Desert = true;
        PlayerQuest_Desert_Back.Desert_back = false;
        SsafyPlanet.ssafyStar = false;
        SsafyPlanet_back.ssafyStar_back = false;

        OasisMeet = true;
        talkTxt.gameObject.SetActive(true);
        starHint_desert.text = "<color=#FFFE77>" + "사막 " +  "0/10" + "</color>";
    }

    void Update()
    {
        WriteText();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OasisCheck" && OasisMeet){
            OasisMeet = !OasisMeet;
            OasisQuestColor();
        }
        else{
            return;
        }
    }

    public void FindToolQuest()
    {
        talkTxt.gameObject.SetActive(false);
        toolTxt.gameObject.SetActive(true);
        starwalk1.gameObject.SetActive(true);
        starwalk2.gameObject.SetActive(true);
        starwalk3.gameObject.SetActive(true);
        starwalk4.gameObject.SetActive(true);
        starwalk5.gameObject.SetActive(true);
        starwalk6.gameObject.SetActive(true);
        starwalk7.gameObject.SetActive(true);
        starwalk8.gameObject.SetActive(true);
        starwalk9.gameObject.SetActive(true);
        WriteText();
    }
    public void WellTalkQuest()
    {
        wellTxt.gameObject.SetActive(false);
        finalTxt.gameObject.SetActive(true);
        star1.gameObject.SetActive(true);
        star2.gameObject.SetActive(true);
        star3.gameObject.SetActive(true);
        star4.gameObject.SetActive(true);
        explode.gameObject.SetActive(true);
        DesertQuestEnd = true;
    }
    public void OasisQuestColor()
    {
        findTxt.text = "<color=#37FF3D>" + "오아시스 찾기! (성공)" + "</color>";
        StartCoroutine(TimeDelay_Oasis());
    }

    public void WriteText()
    {
        //if (ActionController.toolCnt == 0)
        //{
            //toolTxt.text = "<color=#37FF3D>" + "부품을 다 찾았습니다! 조종사에게 돌아가세요!" + "</color>";
            //EndDesertQuest = true;
        //}
        //else 
        if (ActionController.toolCnt < 4)
        {
            toolTxt.text = "부품을 찾으세요" + ActionController.toolCnt + "/7";
        }
        else if (ActionController.toolCnt < 7)
        {
            toolTxt.text = "<color=#FFF700>" + "부품을 찾으세요" + ActionController.toolCnt + "/7" + "</color>";
        }
        else if (ActionController.toolCnt == 7)
        {
            toolTxt.text = "<color=#37FF3D>" + "부품을 다 찾았습니다! 조종사에게 돌아가세요!" + "</color>";
            EndDesertQuest = true;
        }
    }

    public void FinalText()
    {
        toolTxt.gameObject.SetActive(false);
        findTxt.gameObject.SetActive(true);
        starwalk1.gameObject.SetActive(false);
        starwalk2.gameObject.SetActive(false);
        starwalk3.gameObject.SetActive(false);
        starwalk4.gameObject.SetActive(false);
        starwalk5.gameObject.SetActive(false);
        starwalk6.gameObject.SetActive(false);
        starwalk7.gameObject.SetActive(false);
        starwalk8.gameObject.SetActive(false);
        starwalk9.gameObject.SetActive(false);
        EndDesertQuest = false;
    }
    IEnumerator TimeDelay_Oasis()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log(" ");

        wellTxt.gameObject.SetActive(true);
        findTxt.gameObject.SetActive(false);
    }
}
