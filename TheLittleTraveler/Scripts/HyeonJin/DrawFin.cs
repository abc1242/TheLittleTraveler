using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawFin : MonoBehaviour
{
    [SerializeField]
    private GameObject paper;
    [SerializeField]
    private GameObject pen;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private Button btn;

    private void Start()
    {
        btn.onClick.AddListener(OnClickDrawFinBtn);
    }
    public void OnClickDrawFinBtn() //??? ????? ??? ???
    {
        paper.SetActive(false);
        pen.SetActive(false);
        cam.SetActive(false);
        btn.gameObject.SetActive(false);
    }
}
