using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B612Animation : MonoBehaviour
{

    [SerializeField]
    private GameObject player_basic;
    [SerializeField]
    private GameObject player_volcano;
    [SerializeField]
    private GameObject player_rose;
    [SerializeField]
    private GameObject player_baobab;
    Animator _animator_volcano;
    Animator _animator_baobab;
    Animator _animator_rose;


    //장미 충돌 구현
    public GameObject rose;

    //바오밥
    public GameObject baobab;
    public GameObject baobab1;

    //화산연기
    public GameObject smoke1;
    public GameObject smoke2;

    //화산
    public GameObject volcano1;
    public GameObject volcano2;

    

    //텍스트
    [SerializeField]
    public Text treeTxt;
    [SerializeField]
    public Text volTxt;
    [SerializeField]
    public Text roseTxt;
    [SerializeField]
    public Text roseTxt2;
    [SerializeField]
    public Text waterTxt;
    [SerializeField]
    public Text scissorsTxt;
    [SerializeField]
    public Text moveTxt;
    [SerializeField]
    public Text subTxt;
    [SerializeField]
    public Text talkTxt;
    [SerializeField]
    public Text starGet;
    [SerializeField]
    public Text starHint;

    [SerializeField]
    private string text;
    [SerializeField]
    private Text actionText;

    public int treeCnt = 0;
    public int volCnt = 0;
    public static int roseCnt = 0;
    public bool roseWater = false;

    public static bool RoseQuest = false;
    public static bool RoseQuestEnd = false;
    public static bool RoseQuest2 = false;

    public static bool StarCheck = false;

    public static bool B612 = false;

    private bool a = true;
    private bool b = true;
    private bool c = true;

    // Start is called before the first frame update
    void Start()
    {
        B612 = true;
        B612back.B612_back = false;
        PlayerQuest_Forest.Forest = false;
        PlayerQuest_Forest_Back.Forest_back = false;
        PlayerQuest_Desert.Desert = false;
        PlayerQuest_Desert_Back.Desert_back = false;
        SsafyPlanet.ssafyStar = false;
        SsafyPlanet_back.ssafyStar_back = false;

        _animator_volcano = player_volcano.GetComponent<Animator>();
        _animator_baobab = player_baobab.GetComponent<Animator>();
        _animator_rose = player_rose.GetComponent<Animator>();
        rose = GameObject.Find("rose");

        smoke1 = GameObject.Find("smoke_01");
        smoke2 = GameObject.Find("smoke_02");

        volcano1 = GameObject.Find("Volcano_01");
        volcano2 = GameObject.Find("Volcano_02");

        baobab = GameObject.Find("BaobabTree");
        baobab1 = GameObject.Find("baobabTree_01");
        
        talkTxt.gameObject.SetActive(true);

        starHint.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //화산 청소
        if (Input.GetKeyDown(KeyCode.E) && GameObject.Find("Players").transform.Find("Player").GetComponent<LittlePrinceController>().volcano1_enable == true && smoke1.activeSelf == true && a && RoseQuest)
        {
            a = false;
            player_volcano.transform.SetPositionAndRotation(player_basic.transform.position, player_basic.transform.rotation);
            player_volcano.SetActive(true);
            player_basic.SetActive(false);
            _animator_volcano.Play("Cleaning_Sweeping");
            Invoke("SetActiveStatusDisabled", 5f);
            StartCoroutine(TimeDelay_smoke1());
        }

        if (Input.GetKeyDown(KeyCode.E) && GameObject.Find("Players").transform.Find("Player").GetComponent<LittlePrinceController>().volcano2_enable == true && smoke2.activeSelf == true && b && RoseQuest)
        {
            b = false;
            player_volcano.transform.SetPositionAndRotation(player_basic.transform.position, player_basic.transform.rotation);
            player_volcano.SetActive(true);
            player_basic.SetActive(false);
            _animator_volcano.Play("Cleaning_Sweeping");
            Invoke("SetActiveStatusDisabled", 5f);
            StartCoroutine(TimeDelay_smoke2());
        }

        //바오밥 제거
        if (Input.GetKeyDown(KeyCode.E) && GameObject.Find("Players").transform.Find("Player").GetComponent<LittlePrinceController>().baobab_enable == true && baobab1.activeSelf == true && c && RoseQuest)
        {
            c = false;
            player_baobab.transform.SetPositionAndRotation(player_basic.transform.position, player_basic.transform.rotation);
            player_baobab.SetActive(true);
            player_basic.SetActive(false);
            _animator_baobab.Play("Srv_FarmingStart");
            Invoke("SetActiveStatusDisabled", 5f);
            StartCoroutine(TimeDelay_baobab1());
        }

        if (treeCnt == 1 && volCnt == 2 && GameObject.Find("Player").GetComponent<ActionController>().waterCnt >= 1 & GameObject.Find("Player").GetComponent<ActionController>().scissorsCnt >= 1)
        {
            treeCnt += 1;
            roseCnt += 1;
            roseTxt.gameObject.SetActive(true);
            roseTxt.text = "<color=#FF6E79>" + "장미꽃에 물 주기 0/1" + "</color>";
        }

        //장미 물주기
        if (Input.GetKeyDown(KeyCode.E) && GameObject.Find("Players").transform.Find("Player").GetComponent<LittlePrinceController>().rose_enable == true && roseCnt == 1)
        {
            player_rose.transform.SetPositionAndRotation(player_basic.transform.position, player_basic.transform.rotation);
            player_rose.SetActive(true);
            player_basic.SetActive(false);
            _animator_rose.Play("watering");
            Invoke("SetActiveStatusDisabled", 5f);
            StartCoroutine(TimeDelay_rose());
        }

        if(roseCnt == 2 && !InteractionEvent.roseEnd)
        {
            volTxt.gameObject.SetActive(false);
            treeTxt.gameObject.SetActive(false);
            roseTxt.gameObject.SetActive(false);
            scissorsTxt.gameObject.SetActive(false);
            waterTxt.gameObject.SetActive(false);
            roseTxt2.gameObject.SetActive(true);
            //moveTxt.gameObject.SetActive(true);
        }
        if(CountingStar.star_cnt_b612 < 1)
        {
            starHint.text = "<color=#FFFE77>" + "B612 " + CountingStar.star_cnt_b612 + "/1" + "</color>";
        }
        else
        {
            StarCheck = true;
            starHint.text = "<color=#78FF79>" + "B612의 별 모으기 완료!" + "</color>";
        }
    }

    private void SetActiveStatusDisabled()
    {
        player_volcano.SetActive(false);
        player_baobab.SetActive(false);
        player_rose.SetActive(false);
        player_basic.SetActive(true);
        //Vector3 newFishPosition = new Vector3(player_basic.transform.position.x, player_basic.transform.position.y + 0.25f, player_basic.transform.position.z);
    }

    void VolTxtColor()
    {
        if (volCnt == 0)
        {
            volTxt.text = "<color=#FF6E79>" + "화산 청소 0/2" + "</color>";
        } else if(volCnt == 1)
        {
            volTxt.text = "<color=#FFF66E>" + "화산 청소 1/2" + "</color>";
        } else if(volCnt == 2)
        {
            volTxt.text = "<color=#78FF79>" + "화산 청소 2/2" + "</color>";
        } else
        {
            volTxt.gameObject.SetActive(false);
        }
    }
    void TreeTxtColor()
    {
        if (treeCnt == 0)
        {
            treeTxt.text = "<color=#FF6E79>" + "바오밥 나무 싹 뽑기 0/1" + "</color>";
        }
        else if (treeCnt == 1)
        {
            treeTxt.text = "<color=#78FF79>" + "바오밥 나무 싹 뽑기 1/1" + "</color>";
        }
        else
        {
            treeTxt.gameObject.SetActive(false);
        }
    }
    void RoseColor()
    {
        if (roseCnt == 1)
        {
            roseTxt.text = "<color=#78FF79>" + "장미꽃에 물 주기 1/1" + "</color>";
        }
        else
        {
            roseTxt.gameObject.SetActive(false);
        }
    }
    
    public void RoseQuest1(){
        VolTxtColor();
        TreeTxtColor();
        talkTxt.gameObject.SetActive(false);
        treeTxt.gameObject.SetActive(true);
        volTxt.gameObject.SetActive(true);
        RoseQuest = true;
    }
    public void RoseQuest3(){
        roseCnt += 1;
        roseTxt2.gameObject.SetActive(false);
        moveTxt.gameObject.SetActive(true);
        subTxt.gameObject.SetActive(true);
        if(GameObject.Find("star_count_obj").GetComponent<CountingStar>().star_cnt != 1)
        {
            starGet.gameObject.SetActive(true);
        }
        RoseQuestEnd = true;
    }

    IEnumerator TimeDelay_smoke1()
    {
        yield return new WaitForSeconds(5.0f);    //5초 딜레이 함.
        smoke1.SetActive(false);
        //volcano1.transform.GetChild(0).gameObject.SetActive(true);
        volCnt += 1;
        VolTxtColor();
    }

    IEnumerator TimeDelay_smoke2()
    {
        yield return new WaitForSeconds(5.0f);    //5초 딜레이 함.
        smoke2.SetActive(false);
        volcano2.transform.GetChild(0).gameObject.SetActive(true);
        waterTxt.gameObject.SetActive(true);
        volCnt += 1;
        VolTxtColor();
    }

    IEnumerator TimeDelay_baobab1()
    {
        yield return new WaitForSeconds(5.0f);    //5초 딜레이 함.
        baobab1.SetActive(false);
        baobab.transform.GetChild(1).gameObject.SetActive(true);
        scissorsTxt.gameObject.SetActive(true);
        treeCnt += 1;
        TreeTxtColor();
    }

    IEnumerator TimeDelay_rose()
    {
        yield return new WaitForSeconds(5.0f);    //5초 딜레이 함.
        rose.transform.localScale = new Vector3(rose.transform.localScale.x + 0.3f, rose.transform.localScale.y + 0.3f, rose.transform.localScale.z + 0.3f);
        RoseColor();
        roseCnt += 1;
        RoseQuest2 = true;
    }
}
