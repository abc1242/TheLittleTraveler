using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp; //������ ü��(0�� �Ǹ� ���� �ı�)
    [SerializeField]
    private float destroyTime; //���� ���� �ð�(������ ������ ������ �ȵǹǷ�)
    [SerializeField]
    private SphereCollider col; //��ü �ö��̴�(�ı��� �Ŀ��� ��Ȱ��ȭ���Ѽ� ����)
    
    //�ʿ��� ���� ������Ʈ
    [SerializeField]
    private GameObject go_rock; //�Ϲ� ����
    [SerializeField]
    private GameObject go_debris; //���� ����
    [SerializeField]
    private GameObject go_rock_item_prefab; //���� �ӿ� ���� ������

    // [SerializeField]
    // private int count; //������ ���� ����

    [SerializeField]
    private GameObject go_effect_prefabs; //ä�� ����Ʈ

    //���� �� ȿ����(�ӽ÷� ������ �κ����� �ٸ� ���� �� �� �ڿ������� ȿ���� ���� �� ����)
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip effect_sound1;
    [SerializeField]
    private AudioClip effect_sound2;

    public void Mining() //ä��
    {
        audioSource.clip = effect_sound1;
        audioSource.Play(); //����� ����
        var clone = Instantiate(go_effect_prefabs, col.bounds.center, Quaternion.identity); //ä���� ������ ���ݾ� ������ ȿ��
        //col.bounds.center : ��ü �ö��̴� �߽�(x,y,z�� �˾Ƽ� ��), Quaternion.identity : ȸ����(�⺻������ ȸ������ ����)
        Destroy(clone, destroyTime); //�ణ ��� �Ŀ� ȿ�� �ı�

        hp--;
        if(hp <= 0)
        {
            Destruction();
        }
    }

    public void Destruction() { //���� �ı�
        audioSource.clip = effect_sound2;
        audioSource.Play(); //����� ����

        col.enabled = false; //�ݶ��̴� ��Ȱ��ȭ

        //ä���Ǹ鼭 �������� �����ȴ�! �� �ڵ带 ������ �ۼ� �� �� ������ŭ �������� ���´�(�츮�� 1���� �� �� �ϴ�.)
        Instantiate(go_rock_item_prefab, go_rock.transform.position, Quaternion.identity);

        //���� �� �� ��� �Ʒ��� for���� ����Ѵ�
        //for(int i=0; i <count; ++i)
       // {
       //     Instantiate(go_rock_item_prefab, go_rock.transform.position, Quaternion.identity);
       // }

        Destroy(go_rock); //�Ϲ� ���� ����

        go_debris.SetActive(true); //���� ���� Ȱ��ȭ
        Destroy(go_debris, destroyTime); //destoryTime ��ŭ ���� �ð� ������ �� �� ������
    }
}
