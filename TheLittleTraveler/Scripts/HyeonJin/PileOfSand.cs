using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileOfSand : MonoBehaviour
{
    [SerializeField]
    private int hp; //�𷡴����� ü��(0�� �Ǹ� �ı�)
    [SerializeField]
    private float destroyTime; //�� ���� �ð�
    [SerializeField]
    private SphereCollider col; //��ü �ö��̴�(�ı��� �Ŀ��� ��Ȱ��ȭ���Ѽ� ����)

    //�ʿ��� ���� ������Ʈ
    [SerializeField]
    private GameObject pile_of_sand; //�� ����
    [SerializeField]
    private GameObject go_sand_item_prefab; //�� ���̿� ������ ������
    [SerializeField]
    private GameObject item_effect; //�� ���� ����ų ȿ��
    [SerializeField]
    private GameObject dig_effect; //�� ���� �� �� ȿ��

    public void Digging() //�ı�
    {
        hp--;
        dig_effect.transform.gameObject.SetActive(true);
        Invoke("DisabledDigEffect", 0.3f);
        if (hp <= 0)
        {
            Destruction();
        }
    }

    public void Destruction() //�� ���� �ı�
    {
        col.enabled = false; //�ݶ��̴� ��Ȱ��ȭ
        Destroy(item_effect); //���� ��ġ ��Ÿ���� ȿ�� ����

        //ä���Ǹ鼭 �������� �����ȴ�! �� �ڵ带 ������ �ۼ� �� �� ������ŭ �������� ���´�(�츮�� 1���� �� �� �ϴ�.)
        //Instantiate(go_sand_item_prefab, pile_of_sand.transform.position, Quaternion.identity);
        go_sand_item_prefab.transform.gameObject.SetActive(true);
        Destroy(pile_of_sand, destroyTime); //�� ���� ����
    }

    private void DisabledDigEffect()
    {
        dig_effect.transform.gameObject.SetActive(false);
    }


}
