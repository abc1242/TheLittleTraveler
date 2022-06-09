using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingTest : MonoBehaviour
{
    [SerializeField]
    private Camera cam;  //Gets Main Camera
    [SerializeField]
    private Material defaultMaterial; //Material for Line Renderer

    private LineRenderer curLine;  //Line which draws now
    private int positionCount = 2;  //Initial start and end position
    private Vector3 PrevPos = Vector3.zero; // 0,0,0 position variable

    // Update is called once per frame
    void Update()
    {
        DrawMouse();
    }

    void DrawMouse() // �� �����Ӹ��� ȣ��Ǵ� ������Ʈ �Լ��� ȣ���Ͽ� �ǽð����� �̿��ڰ� ���콺 Ŭ���� �ϴ��� ���θ� üũ
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.3f)); //mousePos ������ ���� Ŭ���ϴ� ��ġ���� ����

        if (Input.GetMouseButtonDown(0))  //ù Ŭ���� CreateLine()�Լ��� ȣ���մϴ�. GetMouseButtonDown�� Ư���� �ϳ��� ���� �׸� �� �ѹ� ȣ��
        {
            createLine(mousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            connectLine(mousePos); // ù Ŭ�� �� �巡�׸� �� �� ConnectLine()�Լ��� ȣ��
        }

    }

    void createLine(Vector3 mousePos)
    {
        positionCount = 2;
        GameObject line = new GameObject("Line");
        LineRenderer lineRend = line.AddComponent<LineRenderer>();

        line.transform.parent = cam.transform;
        line.transform.position = mousePos;

        lineRend.startWidth = 0.01f;
        lineRend.endWidth = 0.01f;
        lineRend.numCornerVertices = 5;
        lineRend.numCapVertices = 5;
        lineRend.material = defaultMaterial;
        lineRend.SetPosition(0, mousePos);
        lineRend.SetPosition(1, mousePos);

        curLine = lineRend;
    }

    void connectLine(Vector3 mousePos)
    {
        if (PrevPos != null && Mathf.Abs(Vector3.Distance(PrevPos, mousePos)) >= 0.001f)
        {
            PrevPos = mousePos;
            positionCount++;
            curLine.positionCount = positionCount;
            curLine.SetPosition(positionCount - 1, mousePos);
        }

    }
}
