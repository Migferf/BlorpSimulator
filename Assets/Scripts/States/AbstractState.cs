using UnityEngine;
using System.Collections;

public abstract class AbstractState : State {

    protected Blorp player;
    protected Rigidbody2D rgbd;

    public AbstractState(Blorp blorp)
    {
        player = blorp;
        rgbd = blorp.GetComponent<Rigidbody2D>();
    }
    public abstract void Do();
}
