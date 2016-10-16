using UnityEngine;
using System.Collections;

public class ConstructorState : AbstractState
{
    private House house;

    float houseX;
    float houseY;
    float playerX;
    float playerY;

    public ConstructorState(Blorp blorp, House house) : base(blorp)
    {
        this.house = house;

        houseX = house.transform.position.x;
        houseY = house.transform.position.y;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
    }
    public override void Do()
    {
        if (Building())
        {
            rgbd.velocity = new Vector2(0, 0);
            return;
        }

        player.transform.position = Vector2.Lerp(player.transform.position,
                house.transform.position, Time.deltaTime); 
    }

    public bool Building()
    {       
        if (houseX + 2 > playerX && houseX - 2 < playerX) return false;
        if (houseY + 2 > playerY && houseY - 2 < playerY) return false;
        return true;

    }

}
