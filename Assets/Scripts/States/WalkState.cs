using UnityEngine;
using System.Collections;


public class WalkState : AbstractState
{
    private float speed = 1.2f;

    private double bored;
    private int x;
    private int y;

    private int minX = -9;
    private int maxX = 9;
    private float minY = -4f;
    private float maxY = 4f;

    public WalkState(Blorp blorp) : base(blorp)
    {
        bored = Time.time + Random.Range(1, 2); ;
    }
    public override void Do()
    {
        if (Time.time >= bored)
        {
            x = Random.Range(-2, 2);
            y = Random.Range(-2, 2);
            bored = Time.time + Random.Range(1, 2); ;
        }
        if (player.transform.position.x >= maxX || player.transform.position.x <= minX)
        {
            x = -x;
            bored = bored + 0.25;
        }
        if (player.transform.position.y >= maxY || player.transform.position.y <= minY)
        {
            y = -y;
            bored = bored + 0.25;
        }
        rgbd.velocity = new Vector2(x, y) * speed;
        player.transform.position = new Vector2(Mathf.Clamp(player.transform.position.x, minX, maxX),
                                        Mathf.Clamp(player.transform.position.y, minY, maxY));
    }

}
