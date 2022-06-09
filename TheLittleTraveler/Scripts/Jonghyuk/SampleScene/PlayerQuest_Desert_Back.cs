using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerQuest_Desert_Back : MonoBehaviour
{
    public static bool Desert_back = false;

    void Start()
    {
        B612Animation.B612 = false;
        B612back.B612_back = false;
        PlayerQuest_Forest.Forest = false;
        PlayerQuest_Forest_Back.Forest_back = false;
        PlayerQuest_Desert.Desert = false;
        Desert_back = true;
        SsafyPlanet.ssafyStar = false;
        SsafyPlanet_back.ssafyStar_back = false;
    }

    void Update()
    {

    }

}