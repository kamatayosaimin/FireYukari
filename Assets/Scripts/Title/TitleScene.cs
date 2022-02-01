using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : SceneBehaviour
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        AtsumaruManager.Comment.SetContext("Title");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
