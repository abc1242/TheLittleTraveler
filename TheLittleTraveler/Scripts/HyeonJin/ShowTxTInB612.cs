using UnityEngine;
using UnityEngine.UI;

public class ShowTxTInB612 : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float range;
    [SerializeField]
    private string text;
    [SerializeField]
    private Text actionText;
    [SerializeField]
    private bool status;
    [SerializeField]
    private GameObject roseText;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, target.transform.position);
        if (distance < range
            && ((B612Animation.RoseQuest && !target.transform.gameObject.name.Equals("rose"))
            || (target.transform.gameObject.name.Equals("rose") && roseText.gameObject.activeSelf)) )
        {
            if (!status)
            {
                actionText.gameObject.SetActive(true);
                actionText.text = text;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                status = true;
                actionText.gameObject.SetActive(false);
            }
        }
        else
        {
            actionText.gameObject.SetActive(false);
        }
    }

}
