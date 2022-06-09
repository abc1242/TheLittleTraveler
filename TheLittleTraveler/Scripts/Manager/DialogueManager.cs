using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    Dialogue[] dialogues;

    public static bool isDialogue = false;    // 대화중일 경우 true
    bool isNext = false;    // 특정 키 입력 대기.

    [Header("텍스트 출력 딜레이")]
    [SerializeField] float textDelay;

    int lineCount = 0; // 대화 카운트.
    int contextCount = 0; // 대사 카운트.

    B612Animation B612;
    PlayerQuest_Forest Forest;
    PlayerQuest_Desert Desert;

    void Start(){
        B612 = FindObjectOfType<B612Animation>();
        Forest = FindObjectOfType<PlayerQuest_Forest>();
        Desert = FindObjectOfType<PlayerQuest_Desert>();
    }

void Update(){
        if(isDialogue){
            if(isNext){
                if(Input.GetMouseButtonUp(0)){
                    isNext = false;
                    txt_Dialogue.text = "";
                    if(++contextCount < dialogues[lineCount].contexts.Length){
                        StartCoroutine(TypeWriter());
                    }else{
                        contextCount = 0;
                        if(++lineCount < dialogues.Length){
                            StartCoroutine(TypeWriter());
                        }else{
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }

    public void ShowDialogue(Dialogue[] p_dialogues){
        StopAllCoroutines();
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = p_dialogues;
        GameManager.canPlayerMove = false;
        GameManager.cameraMove = false;
        StartCoroutine(TypeWriter());
    }

    void EndDialogue(){
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;
        GameManager.canPlayerMove = true;
        GameManager.cameraMove = true;
        SettingUI(false);

        if(InteractionEvent.roseStart && !B612back.B612_back){
            // GameObject.Find("Players").GetComponent<B612Animation>().RoseQuest1();
            InteractionEvent.roseStart = false;
            B612.RoseQuest1();
        }
        if (InteractionEvent.roseEnd && !B612back.B612_back){
            InteractionEvent.roseEnd = false;
            GameObject.Find("Players").GetComponent<B612Animation>().RoseQuest3();
        }
        if (InteractionEvent.foxStart && !PlayerQuest_Forest_Back.Forest_back){
            InteractionEvent.foxStart = false;
            Forest.touchQuest();
        }
        if (InteractionEvent.foxEnd && !PlayerQuest_Forest_Back.Forest_back){
            InteractionEvent.foxEnd = false;
            Forest.EndForestQuest();
        }
        if (InteractionEvent.desertStart && !PlayerQuest_Desert_Back.Desert_back){
            InteractionEvent.desertStart = false;
            Desert.FindToolQuest();
        }
        if (InteractionEvent.desertEnd && !PlayerQuest_Desert_Back.Desert_back){
            InteractionEvent.desertEnd = false;
            Desert.FinalText();
        }
        if (InteractionEvent.wellStart){
            InteractionEvent.wellStart = false;
            Desert.WellTalkQuest();
        }

    }

    IEnumerator TypeWriter(){
        SettingUI(true);

        // `를 ,로 바꾸는 부분
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("`", ",");
        
        txt_Name.text = dialogues[lineCount].name;
        for (int i = 0; i < t_ReplaceText.Length; i++){
            txt_Dialogue.text += t_ReplaceText[i];
            yield return new WaitForSeconds(textDelay);
        }
        isNext = true;
    }

    void SettingUI(bool p_flag){
        go_DialogueBar.SetActive(p_flag);
        go_DialogueNameBar.SetActive(p_flag);
    }
}
