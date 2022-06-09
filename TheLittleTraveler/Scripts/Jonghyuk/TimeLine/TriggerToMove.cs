using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToMove : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    public bool foxMove = false;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Ãæµ¹");
        foxMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
