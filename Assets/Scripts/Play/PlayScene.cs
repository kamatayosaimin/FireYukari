using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScene : SceneBehaviour
{

    [Serializable]
    public class HpUI
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;

        public void SetUI(int hp)
        {
            _slider.value = hp;

            _text.text = hp.ToString();
        }
    }

    [Serializable]
    public class ScoreText
    {
        [SerializeField] private string _style = "SC {0:D8}";
        [SerializeField] private Text _text;

        public void SetText(int score)
        {
            _text.text = string.Format(_style, score);
        }
    }

    [SerializeField] private int _maxScore = 99999990;
    private int _score;
    private PlayState _state;
    [SerializeField] private AudioSource[] _sounds;
    [SerializeField] private Generator _generator;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private HpUI _hpUI;
    [SerializeField] private ScoreText _scoreText;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _score = 0;
        _state = PlayState.Start;

        _scoreText.SetText(_score);

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
        catch (IndexOutOfRangeException e)
        {
        }
    }

    public void AddScore(int add)
    {
        _score += add;
        _score = Mathf.Min(_score, _maxScore);

        _scoreText.SetText(_score);
    }
}
