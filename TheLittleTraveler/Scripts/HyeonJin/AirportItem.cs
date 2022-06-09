using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "New Item/AirportItem")]
public class AirportItem : ScriptableObject //���� ������Ʈ�� ���� �ʿ� ����
{
    public string itemName; //�������� �̸�
    public ItemType itemType; //�������� ����
    public Sprite itemImage; //�������� �̹���(�̹����� ĵ���������� ��� �� ������, Sprite�� ĵ���� �ʿ���� ���� �󿡼� ��� �� ����)
    public GameObject itemPrefab; //�������� ������

    //public string weaponType; // ���� ����

    public enum ItemType
    {
        Equipment, //��� ������
        Used, //�Ҹ�ǰ
        Ingredient, //���
        ETC //��Ÿ
    }
}
