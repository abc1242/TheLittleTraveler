using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerQuest_Forest : MonoBehaviour
{
    [SerializeField]
    private GameObject player_basic;
    [SerializeField]
    private GameObject player_touch;
    [SerializeField]
    public Text exitTxt;
    [SerializeField]
    public Text foxTxt;
    [SerializeField]
    public Text meetTxt;
    [SerializeField]
    public Text touchTxt;
    [SerializeField]
    public Text talkTxt;
    [SerializeField]
    public Text moveDesertTxt;
    public Text starHint_forest;
    [SerializeField]
    private GameObject star2;
    [SerializeField]
    private GameObject star5;
    public static bool isTouched = false;

    Animator _animator_touch;

    public bool FoxMeet = false;
    public bool ExitMeet = false;

    public static bool Forest = false;
    public static bool Cantouch = false;
    public static bool ForestQuestEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        B612Animation.B612 = false;
        B612back.B612_back = false;      
        Forest = true;
        PlayerQuest_Forest_Back.Forest_back = false;
        PlayerQuest_Desert.Desert = false;
        PlayerQuest_Desert_Back.Desert_back = false;
        SsafyPlanet.ssafyStar = false;
        SsafyPlanet_back.ssafyStar_back = false;

        exitTxt.gameObject.SetActive(true);
        FoxMeet = true;
        ExitMeet = true;
        starHint_forest = GameObject.Find("Canvas").transform.Find("StarHint_forest").GetComponent<Text>();
        starHint_forest.text = "<color=#FFFE77>" + "초원 " + "0/7" + "</color>";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Cantouch)
        {
            if (ActionController.hitInfo.transform.name == "Fox_1")
            {
                player_touch.transform.SetPositionAndRotation(player_basic.transform.position, player_basic.transform.rotation);
                player_basic.SetActive(false);
                player_touch.SetActive(true);
                _animator_touch = player_touch.GetComponent<Animator>();
                GameManager.canPlayerMove = false;
                GameManager.cameraMove = false;
                _animator_touch.Play("Petting Animal");
                touchTxt.text = "<color=#37FF3D>" + "여우 쓰다듬기 (성공)" + "</color>";
                Invoke("SetActiveStatusDisabled", 5f);
                isTouched = true;
                Cantouch = false;
            }
        }
        
    }
    private void SetActiveStatusDisabled()
    {
        player_touch.SetActive(false);
        player_basic.SetActive(true);
        touchTxt.gameObject.SetActive(false);
        talkTxt.gameObject.SetActive(true);
        GameManager.canPlayerMove = true;
        GameManager.cameraMove = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Exit" && ExitMeet)
        {
            ExitMeet = !ExitMeet;
            ExitQuestColor();
        }

        if (other.gameObject.name == "FoxMeet" && FoxMeet)
        {
            FoxMeet = !FoxMeet;
            MeetQuestColor();
        }
    }

    public void touchQuest()
    {
        meetTxt.gameObject.SetActive(false);
        touchTxt.gameObject.SetActive(true);
        Cantouch = true;
    }
    public void EndForestQuest()
    {
        ForestQuestEnd = true;
        talkTxt.gameObject.SetActive(false);
        moveDesertTxt.gameObject.SetActive(true);
        star2.gameObject.SetActive(true);
        star5.gameObject.SetActive(true);
    }
    void ExitQuestColor()
    {
        exitTxt.text = "<color=#37FF3D>" + "장미정원 미로 탈출하기 (성공)" + "</color>";
        StartCoroutine(TimeDelay_Exit());
    }

    void MeetQuestColor()
    {
        foxTxt.text = "<color=#37FF3D>" + "언덕위의 여우 만나기 (성공)" + "</color>";
        StartCoroutine(TimeDelay_Meet());
    }

    IEnumerator TimeDelay_Exit()
    {
        yield return new WaitForSeconds(2.0f);    //2초 딜레이 함.
        exitTxt.gameObject.SetActive(false);
        foxTxt.gameObject.SetActive(true);
    }
    IEnumerator TimeDelay_Meet()
    {
        yield return new WaitForSeconds(1.0f);
        foxTxt.gameObject.SetActive(false);
        meetTxt.gameObject.SetActive(true);
    }
}
