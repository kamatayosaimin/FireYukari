using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene : SceneBehaviour
{
    private PlayState _state;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _state = PlayState.Start;

        AtsumaruManager.Comment.SetContext("Play");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
