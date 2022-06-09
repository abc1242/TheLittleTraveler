using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "New Item/AirportItem")]
public class AirportItem : ScriptableObject //게임 오브젝트에 붙일 필요 없음
{
    public string itemName; //아이템의 이름
    public ItemType itemType; //아이템의 유형
    public Sprite itemImage; //아이템의 이미지(이미지는 캔버스에서만 띄울 수 있지만, Sprite는 캔버스 필요없이 월드 상에서 띄울 수 있음)
    public GameObject itemPrefab; //아이템의 프리팹

    //public string weaponType; // 도구 유형

    public enum ItemType
    {
        Equipment, //장비 아이템
        Used, //소모품
        Ingredient, //재료
        ETC //기타
    }
}
