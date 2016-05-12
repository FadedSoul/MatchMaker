using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {

    //list of event objects
    [SerializeField]
    private GameObject animationObject_1;

    //animations from the objects
    private Animator animation_1;


    private bool intersectionEvent = false;

    private float up = 0.2f;
	// Use this for initialization
	void Start () {
        animation_1 = animationObject_1.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Animation_1();
	}

    private void Animation_1()
    {
        animation_1.SetBool("Play", true);
    }
}

