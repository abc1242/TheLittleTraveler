using UnityEngine;
using UnityEngine.UI;

public class ShowRidingTxT : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float range;
    [SerializeField]
    private Text actionText;
    [SerializeField]
    private KeyCode keyCode; // keycode ��ȣ
    Animator animator;

    bool getKeyDown2 = false;

    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, target.transform.position);
        if (distance < range)
        {
            bool mount = animator.GetBool("Mount");
            actionText.gameObject.SetActive(true);
            if(!mount)
            {
                actionText.text = "�� Ÿ�� <color=green>(F)</color>";
                getKeyDown2 = false;
            }
            else
            {
                if(!getKeyDown2)
                {
                    actionText.text = "������ <color=green>(F �� ������)</color>, �ӵ� �ø���<color=green>(2�� Ű)</color>";
                }
                if(Input.GetKeyDown(KeyCode.Alpha2))
                {
                    getKeyDown2 = true;
                    actionText.text = "������ <color=green>(F �� ������)</color>, �ӵ� ���̱�<color=green>(1�� Ű)</color>";
                }
                else if(Input.GetKeyDown(KeyCode.Alpha1)) {
                    getKeyDown2 = false;
                }
            }
        }
        else
        {
            actionText.gameObject.SetActive(false);
        }
    }
}
