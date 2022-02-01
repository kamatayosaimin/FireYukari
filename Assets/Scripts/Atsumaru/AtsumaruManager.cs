using RpgAtsumaruApiForUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtsumaruManager : MonoBehaviour
{
    private AtsumaruComment _comment;
    private AtsumaruPad _pad;

    public AtsumaruComment Comment
    {
        get
        {
            return _comment;
        }
    }

    public AtsumaruPad Pad
    {
        get
        {
            return _pad;
        }
    }

    void Awake()
    {
        _comment = new AtsumaruComment();
        _pad = new AtsumaruPad();

        if (RpgAtsumaruApi.Initialized)
        {
            _pad.Initialize();

            _comment.Initialize();

            return;
        }

        RpgAtsumaruApi.Initialize();

        _pad.StartControllerListen();

        _comment.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
