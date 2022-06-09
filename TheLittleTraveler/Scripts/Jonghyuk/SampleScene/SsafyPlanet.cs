using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SsafyPlanet : MonoBehaviour
{
    public static bool ssafyStar = false;
    public static bool ssafyCnt = false;
    // Start is called before the first frame update
    void Start()
    {
        B612Animation.B612 = false;
        B612back.B612_back = false;
        PlayerQuest_Forest.Forest = false;
        PlayerQuest_Forest_Back.Forest_back = false;
        PlayerQuest_Desert.Desert = false;
        PlayerQuest_Desert_Back.Desert_back = false;
        ssafyStar = true;
        SsafyPlanet_back.ssafyStar_back = false;
        ssafyCnt = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
