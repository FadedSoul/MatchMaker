using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {
    [SerializeField]
    private Transform[] Points;
    [SerializeField]
    private Transform CurrentWaypoint;
    [SerializeField]
    private float MoveSpeed = 10f;
    [SerializeField]
    private float Damping = 3f;
    [SerializeField]
    private Transform MyTransform;
    [SerializeField]
    private int index = 0;
    // Use this for initialization
    void Start() {
        CurrentWaypoint = Points[0];
    }

    // Update is called once per frame
    void Update() {
        MoveTowards();
    }

    void LateUpdate()
    {
        //Quaternion rotation = Quaternion.LookRotation(CurrentWaypoint.position - MyTransform.position);
        //MyTransform.rotation = Quaternion.Slerp(MyTransform.rotation, rotation, Time.deltaTime * Damping);
    }

    void MoveTowards()
    {
        float step = MoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.position, step);
        if (transform.position == CurrentWaypoint.position)
        {
            if (index == Points.Length)
            {
                index = 0;
            }            
            CurrentWaypoint = Points[index];
            index++;
        }
    }
}
