using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyDrawing : MonoBehaviour
{
    LineRenderer lr;
    public float vertexInterval;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }
    void createNewVert(Vector3 pos)
    {
        lr.positionCount = lr.positionCount + 1;
        lr.SetPosition(lr.positionCount - 1, pos);

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > vertexInterval)
        {
            timer = 0;
            createNewVert(transform.position);
        }
    }
}
