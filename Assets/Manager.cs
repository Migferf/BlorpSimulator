using UnityEngine;
using System.Collections.Generic;

public class Manager : MonoBehaviour {


    private List<Blorp> blorps;
    private List<House> houses;

    private int population;
    private int numberOfHouses;

    [SerializeField]
    private House house;
    bool done = false;

    void Awake()
    {
        blorps = new List<Blorp>();
        houses = new List<House>();
        population = 0;
        numberOfHouses = 0;
    }
	
	// Update is called once per frame
	void Update () {


        if(population  > 5 && !done)
        {
            done = true;
            NewHouse();
        }
	}

    public void NewBlorp(Blorp blorp)
    {
        blorps.Add(blorp);
        population++;
    }

    public void deadBlorp(Blorp blorp)
    {
        blorps.Remove(blorp);
        population--;
    }

    public void NewHouse()
    {
        var x = Random.Range(-7, 7);
        var y = Random.Range(-3, 3);

        House newHouse = Instantiate(house, new Vector2(x, y), Quaternion.identity) as House;

        houses.Add(newHouse);

        foreach(Blorp blorp in blorps)
        {
            if (blorp.actualState.GetType() == typeof(WalkState))
            {
                Debug.Log("Soy el blorp y voy a la casa " + blorp);
                blorp.actualState = new ConstructorState(blorp, newHouse);
            }
        }
        numberOfHouses++;
    }
}
