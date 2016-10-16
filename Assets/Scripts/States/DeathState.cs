using UnityEngine;
using System.Collections;

public class DeathState : AbstractState {

    private Animator anim;
    public DeathState(Blorp blorp) : base(blorp)
    {
        anim = player.GetComponent<Animator>();
        anim.SetBool("dead", true);
    }
	public override void Do ()
    {
        player.manager.deadBlorp(player);
        GameObject.Destroy(player.gameObject, 1.3f);
	}

}
