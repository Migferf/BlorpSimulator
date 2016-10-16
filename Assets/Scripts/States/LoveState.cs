using UnityEngine;
using System.Collections;


public class LoveState : AbstractState
{

    private int loveEnough = 300;
    private int actualLove;
    public LoveState(Blorp blorp) : base(blorp)
    {
        player.loving = true;

        rgbd.velocity = new Vector2(0, 0);
        actualLove = 0;

        Vector2 lovePos = new Vector2(player.transform.position.x, player.transform.position.y + 0.5f);
        GameObject.Instantiate(player.getBlorplove(), lovePos, Quaternion.identity);
    }

    public override void Do()
    {
        actualLove++;

        if(actualLove >= loveEnough)
        {
            bool birth = 0.5 > Random.Range(0, 1) ? true : false;

            if (birth)
            {
                GameObject.Instantiate(player.getBlorpson(), player.transform.position, Quaternion.identity);

                player.lovetime = 1200;
                player.actualState = new WalkState(player);
                player.loving = false;
            }
        }
    }
}
