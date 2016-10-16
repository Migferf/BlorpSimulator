using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blorp : MonoBehaviour {

    [SerializeField]
    private int age { get; set; }
    private int time;
    public int lovetime { get; set; }

    private IDictionary<int, State> states;
    public State actualState { get; set; }

    [SerializeField]
    private GameObject blorpson;
    [SerializeField]
    private GameObject blorplove;

    public bool loving  {get; set;}

    public Manager manager { get; set; }

    // Use this for initialization
    void Start () {

        manager = (GameObject.Find("Manager") as GameObject).GetComponent<Manager>();
        manager.NewBlorp(this);

        age = 0;
        time = 0;
        loving = false;

        actualState = new WalkState(this);
    }
	
	// Update is called once per frame
	void Update () {

        time++;
        if(time > 60)
        {
            age++;
            time = 0;
        }
        if (lovetime > 0) lovetime--;
        if (age > 100) actualState = new DeathState(this);

        actualState.Do();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Blorp blorp = other.GetComponent<Blorp>();
            if (age > 18 && lovetime <= 0 && !loving
                && blorp.age > 18 && blorp.lovetime <= 0 && !blorp.loving)
            {
                actualState = new LoveState(this);
            }
        }
    }

    public GameObject getBlorpson()
    {
        return blorpson;
    }

    public GameObject getBlorplove()
    {
        return blorplove;
    }


}
