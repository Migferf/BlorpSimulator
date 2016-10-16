using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {


    [SerializeField]
    private float done = 0;

    private Animator anim;
    private int count;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        count++;
        if (count > 5)
        {
            count = 0;
            done += 0.01f;
        }
        anim.SetFloat("done", done);
	}
}
