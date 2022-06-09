using UnityEngine;
using UnityEngine.UI;

public class ShowPaper : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject paper;
    [SerializeField]
    private GameObject pen;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private float range; //종이 나올 수 있는 거리

    [SerializeField]
    private Text drawText; //이동할 메시지 띄울 오브젝트

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, target.transform.position);
        if (distance < range)
        {
            drawText.gameObject.SetActive(true);
            if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 클릭
            {
                drawText.gameObject.SetActive(false);
                if (paper.activeInHierarchy == false)
                {

                    paper.SetActive(true);
                    pen.SetActive(true);
                    cam.SetActive(true);
                    button.SetActive(true);
                }
                else
                {
                    paper.SetActive(false);
                    pen.SetActive(false);
                    cam.SetActive(false);
                    button.SetActive(false);
                }
            }
        }
        else
        {
            drawText.gameObject.SetActive(false);
        }
    }

   
}
