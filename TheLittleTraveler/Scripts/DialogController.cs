using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogController : MonoBehaviour
{
    public Text dialogText;

    public UnityEvent onDialogFinished;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartDialog()
    {
        dialogText.text = "";
        string sampleText = "";
        StartCoroutine(Typing(sampleText));
    }

    // ????? 
    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.07f);
        }

        // 0.5?? ??? ?? ????
        yield return new WaitForSeconds(0.5f);
        FinishDialog();
    }

    public void FinishDialog()
    {
        gameObject.SetActive(false);

        StopAllCoroutines();
        onDialogFinished.Invoke();
    }
}
