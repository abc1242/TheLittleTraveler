using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class B612back : MonoBehaviour
{
    [SerializeField]
    public Text SubTxt;
    public static bool B612_back = false;
    // Start is called before the first frame update
    void Start()
    {
        B612Animation.B612 = false;
        B612_back = true;
        PlayerQuest_Forest.Forest = false;
        PlayerQuest_Forest_Back.Forest_back = false;
        PlayerQuest_Desert.Desert = false;
        PlayerQuest_Desert_Back.Desert_back = false;
        SsafyPlanet.ssafyStar = false;
        SsafyPlanet_back.ssafyStar_back = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("sheep"))
        {
            SubTxt.gameObject.SetActive(false);
        }
    }
}
