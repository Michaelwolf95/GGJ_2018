using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;

public class ExampleStateAction : FsmStateAction
{
    public FsmInt MyInt;

    public override void OnEnter()
    {
        Debug.Log("ENTERED STATE");
        Debug.Log("MyInt= " + MyInt.Value);
    }

    public override void OnExit()
    {
        Debug.Log("EXITED STATE");
    }
}
