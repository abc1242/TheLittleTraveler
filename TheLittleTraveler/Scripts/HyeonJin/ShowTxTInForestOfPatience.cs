using UnityEngine;
using UnityEngine.UI;

public class ShowTxTInForestOfPatience : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float range;
    [SerializeField]
    private Text actionText;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(player != null)
        {
            float distance = Vector3.Distance(player.transform.position, target.transform.position);

            if (target.transform.gameObject.name.Equals("ladder-wood"))
            {
                float x = Mathf.Abs(player.transform.position.x - target.transform.position.x);
                float y = Mathf.Abs(player.transform.position.y - target.transform.position.y);
                //float z = Mathf.Abs(player.transform.position.z - target.transform.position.z);

                if (distance < range)
                {
                    actionText.gameObject.SetActive(true);
                    actionText.text = "�����Ͻ� �ǰ���? �׷��ٸ� ��ٸ��� Ÿ�� �ö󰡼���!";
                }
                else if (x < 0.5 && y > 5.4 && distance < 7.5)
                {
                    actionText.gameObject.SetActive(true);
                    actionText.text = "B612�� ���ư��� <color=yellow>(E)</color>";
                }
                else
                {
                    actionText.gameObject.SetActive(false);
                }
            }
            else
            {
                if (distance < range)
                {
                    actionText.gameObject.SetActive(true);
                }
                else
                {
                    actionText.gameObject.SetActive(false);
                }
            }
        }
    }
}
