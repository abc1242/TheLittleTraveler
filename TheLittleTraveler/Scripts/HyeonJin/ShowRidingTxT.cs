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
    private KeyCode keyCode; // keycode 번호
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
                actionText.text = "말 타기 <color=green>(F)</color>";
                getKeyDown2 = false;
            }
            else
            {
                if(!getKeyDown2)
                {
                    actionText.text = "내리기 <color=green>(F 꾹 누르기)</color>, 속도 올리기<color=green>(2번 키)</color>";
                }
                if(Input.GetKeyDown(KeyCode.Alpha2))
                {
                    getKeyDown2 = true;
                    actionText.text = "내리기 <color=green>(F 꾹 누르기)</color>, 속도 줄이기<color=green>(1번 키)</color>";
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
