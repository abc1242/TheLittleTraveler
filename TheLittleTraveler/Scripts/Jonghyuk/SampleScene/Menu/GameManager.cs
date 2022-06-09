using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //[Header("GameManager")]
    //public Manager_SE manger_SE;

    public GameObject MenuBack;
    public GameObject Option;
    [SerializeField]
    public GameObject Help;
    public static GameManager instance;
    public static bool canPlayerMove = true;
    public static bool cameraMove = true;
    public static bool InvenOpen = false;
    public static bool HelpOpen = false;

    [SerializeField]
    public GameObject worldMap;
    [SerializeField]
    public GameObject currentMap;

    private void Awake()
    {
        if (instance != this)
            instance = this;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if(HelpOpen == false)
            {
                Help.gameObject.SetActive(true);
                HelpOpen = true;
            }
            else
            {
                Help.gameObject.SetActive(false);
                HelpOpen = false;
            }
        }

        if (Input.GetButtonDown("Cancel"))
            
            if (MenuBack.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                if (Option.activeSelf)
                {
                    Option.SetActive(false);
                }
                else 
                {
                    MenuBack.SetActive(false);
                    Time.timeScale = 1f;
                    canPlayerMove = true;
                    cameraMove = true;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                MenuBack.SetActive(true);
                Time.timeScale = 0f;
                canPlayerMove = false;
                cameraMove = false;
                if (Help.activeSelf)
                {
                    Help.gameObject.SetActive(false);
                    HelpOpen = false;
                }
                if (!Inventory.inventoryActivated)
                {
                    InvenOpen = true;
                    Inventory.inventoryActivated = !Inventory.inventoryActivated;
                }
            }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        if(Input.GetKeyDown(KeyCode.M) && worldMap != null)
        {
            if(worldMap.activeSelf)
            {
                worldMap.SetActive(false);
            }else
            {
                worldMap.SetActive(true);
            }
        }
        if(Input.GetKeyDown(KeyCode.N) && currentMap != null)
        {
            if (currentMap.activeSelf)
            {
                currentMap.SetActive(false);
            }
            else
            {
                currentMap.SetActive(true);
            }
        }
    }

    public void Continue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MenuBack.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        canPlayerMove = true;
        cameraMove = true;
    }
    public void Setting()
    {
        Option.SetActive(true);
    }
    public void SettingConfirm()
    {
        Option.SetActive(false);
    }
}