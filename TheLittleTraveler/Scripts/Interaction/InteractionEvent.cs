using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogueEvent;

    public static bool roseStart = false;
    public static bool roseEnd = false;
    public static bool foxStart = false;
    public static bool foxEnd = false;
    public static bool desertStart = false;
    public static bool desertEnd = false;
    public static bool wellStart = false;

    void Start(){
        bool t_Flag = CheckEvent();

        gameObject.SetActive(t_Flag);
    }

    bool CheckEvent(){
        bool t_Flag = true;

        // 등장 조건과 일치하지 않을 경우, 등장시키지 않음.
        for (int i = 0; i < dialogueEvent.eventTiming.eventConditions.Length; i++){
            if(DatabaseManager.instance.eventFlags[dialogueEvent.eventTiming.eventConditions[i]] != dialogueEvent.eventTiming.conditionFlag){
                t_Flag = false;
                break;
            }
        }

        // 등장 조건과 관계없이, 퇴장 조건과 일치할 경우, 무조건 등장시키지 않음
        if(DatabaseManager.instance.eventFlags[dialogueEvent.eventTiming.eventEndNum]){
            t_Flag = false;
        }
        return t_Flag;
    }

    public Dialogue[] GetDialogue(){
        // 상호작용 전 대화
        if (!DatabaseManager.instance.eventFlags[dialogueEvent.eventTiming.eventNum]) {
            DatabaseManager.instance.eventFlags[dialogueEvent.eventTiming.eventNum] = true;
            dialogueEvent.dialogues = SettingDialogue(dialogueEvent.dialogues, (int)dialogueEvent.line.x, (int)dialogueEvent.line.y);
            if (ActionController.target == "rose") {
                roseStart = true;
            }
            if (ActionController.target == "Fox_1")
            {
                foxStart = true;
            }
            if (ActionController.target == "Engineer")
            {
                desertStart = true;
            }
            if (ActionController.target == "Well")
            {
                wellStart = true;
            }
            return dialogueEvent.dialogues;
        }
        // 상호작용 후 대화

        // 퀘스트를 완료하지 않았을때 반복
        else if (B612Animation.B612 && !B612Animation.RoseQuest2) {
            dialogueEvent.dialogues = SettingDialogue(dialogueEvent.dialogues, (int)dialogueEvent.line.y, (int)dialogueEvent.line.y);
            return dialogueEvent.dialogues;
        }

        // 장미에게 물주고 나서 작동하는곳
        else if (B612Animation.B612 && B612Animation.RoseQuest2)
        {
            dialogueEvent.dialoguesB = SettingDialogue(dialogueEvent.dialoguesB, (int)dialogueEvent.lineB.x, (int)dialogueEvent.lineB.y);
            if (ActionController.target == "rose")
            {
                roseEnd = true;
            }
            return dialogueEvent.dialoguesB;
        }
        // 여우 대화하고 쓰다듬기 전
        else if (PlayerQuest_Forest.Forest && !PlayerQuest_Forest.isTouched)
        {
            dialogueEvent.dialogues = SettingDialogue(dialogueEvent.dialogues, (int)dialogueEvent.line.y, (int)dialogueEvent.line.y);
            return dialogueEvent.dialogues;
        }
        else if (PlayerQuest_Desert.Desert && !PlayerQuest_Desert.EndDesertQuest)
        {
            dialogueEvent.dialogues = SettingDialogue(dialogueEvent.dialogues, (int)dialogueEvent.line.y, (int)dialogueEvent.line.y);
            return dialogueEvent.dialogues;
        }
        else
        {
            dialogueEvent.dialoguesB = SettingDialogue(dialogueEvent.dialoguesB, (int)dialogueEvent.lineB.x, (int)dialogueEvent.lineB.y);
            if(ActionController.target == "Fox_1")
            {
                foxEnd = true;
            }
            if(ActionController.target == "Engineer")
            {
                desertEnd = true;
            }
            if (ActionController.target == "Well")
            {
                wellStart = true;
            }
            return dialogueEvent.dialoguesB;
        }
    }

    Dialogue[] SettingDialogue(Dialogue[] p_Dialogue, int p_lineX, int p_lineY){
        Dialogue[] t_Dialogues = DatabaseManager.instance.GetDialogue(p_lineX, p_lineY);
        return t_Dialogues;
    }
}
