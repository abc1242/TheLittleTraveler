using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountingStar : MonoBehaviour
{
    public GameObject star_count_obj;
    public int star_cnt = 0;
    public Text countText;
    public static int star_cnt_b612 = 0;
    public static int star_cnt_forest = 0;
    public static int star_cnt_desert = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (!EndScene.EndGame)
        {
            star_count_obj = GameObject.Find("star_count_obj");

            if (star_cnt == 0)
            {
                DontDestroyOnLoad(star_count_obj);
            }
            countText.text = "<color=#FFFE77>" + "x  " + star_cnt.ToString() + "</color>";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!EndScene.EndGame)
        {
            if (star_cnt == 0)
            {
                countText.text = "<color=#FFFE77>" + "별을 모아보세요!" + "</color>";
            }
            else
            {
                if (GameObject.Find("Canvas").transform.Find("Star_img") != null)
                {
                    GameObject.Find("Canvas").transform.Find("Star_img").GetComponent<Image>().SetEnable(true);
                }

                // GameObject.Find("Canvas").transform.Find("Star_img").GetComponent<Image>().SetEnable(true);
                if (GameObject.Find("Canvas").transform.Find("Text") != null)
                {
                    countText = GameObject.Find("Canvas").transform.Find("Text").GetComponent<Text>();
                }

                countText.text = "<color=#FFFE77>" + "x  " + star_cnt.ToString() + "</color>";
                //countText = GameObject.Find("Canvas").transform.Find("Text").GetComponent<Text>();
            }
        }
    }
}
