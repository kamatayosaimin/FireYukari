using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene : SceneBehaviour
{
    private PlayState _state;
    [SerializeField] private AudioSource[] _sounds;
    [SerializeField] private Generator _generator;
    [SerializeField] private PlayerController _playerController;

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

        switch (_state)
        {
            case PlayState.Start:
                break;
            case PlayState.Playing:
                break;
            case PlayState.Dead:
                break;
            case PlayState.GameOver:
                break;
            case PlayState.Menu:
                break;
        }
    }

    public void GameStart()
    {
        _state = PlayState.Playing;

        _generator.enabled = true;

        _playerController.GameStart();
    }

    public void PlaySound(int index)
    {
        try
        {
            _sounds[index].Play();
        }
        catch (System.IndexOutOfRangeException e)
        {
        }
    }
}
