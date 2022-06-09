using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerQuest_Forest_Back : MonoBehaviour
{
    public static bool Forest_back = false;
    // Start is called before the first frame update
    void Start()
    {
        B612Animation.B612 = false;
        B612back.B612_back = false;
        PlayerQuest_Forest.Forest = false;
        Forest_back = true;
        PlayerQuest_Desert.Desert = false;
        PlayerQuest_Desert_Back.Desert_back = false;
        SsafyPlanet.ssafyStar = false;
        SsafyPlanet_back.ssafyStar_back = false;
    }

    private void Update()
    {
        
    }
}
