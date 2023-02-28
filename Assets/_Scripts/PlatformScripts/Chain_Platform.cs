using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Platform : MonoBehaviour
{
    [SerializeField] private Transform enteryPoint, exitPoint;
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0,enteryPoint.position);
        line.SetPosition(1, exitPoint.position);
    }
}
