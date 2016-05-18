using UnityEngine;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    private List<Transform> Points = new List<Transform>();
    private GameObject[] obj;
    [SerializeField]
    private Transform CurrentWaypoint;
    [SerializeField]
    private float MoveSpeed = 10f;
    [SerializeField]
    private float Damping = 0.5f;
    [SerializeField]
    private Transform MyTransform;
    [SerializeField]
    private int index = 0;
    // Use this for initialization
    void Awake()
    {

        obj = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject oob in obj)
        {
            Points.Add(oob.transform);
        }
        Points.Sort(CompareListByName);


        CurrentWaypoint = Points[index];
    }

    void Start()
    {

        // CurrentWaypoint = Points.

    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards();
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.LookRotation(CurrentWaypoint.position - MyTransform.position);
        MyTransform.rotation = Quaternion.Slerp(MyTransform.rotation, rotation, Time.deltaTime * Damping);
    }

    void MoveTowards()
    {
        float step = MoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.position, step);

    }
    void OnTriggerEnter(Collider coll)
    {
        //Debug.Log("Hallo");
        if (coll.gameObject.tag == "Waypoint")
        {
            index++;
            if (index == obj.Length)
            {
                index = 0;
            }
            CurrentWaypoint = Points[index].transform;
        }
    }

    private static int CompareListByName(Transform i1, Transform i2)
    {
        return i1.name.CompareTo(i2.name);
    }
}