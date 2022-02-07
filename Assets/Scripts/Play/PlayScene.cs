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
    [SerializeField] private Animator _musicAnimator;
    private Animator _uiAnimator;
    [SerializeField] private AudioSource[] _sounds;
    [SerializeField] private RectTransform _menuButtonParent;
    private ButtonManager _buttonManager;
    [SerializeField] private Generator _generator;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private HpUI _hpUI;
    [SerializeField] private ScoreText _scoreText;

    protected override void Awake()
    {
        base.Awake();

        _uiAnimator = GetComponent<Animator>();
        _buttonManager = GetComponent<ButtonManager>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _score = 0;

        _scoreText.SetText(_score);

        AtsumaruManager.Comment.SetContext("Play");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void GameStart()
    {
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

    public void SetHp(int hp)
    {
        _hpUI.SetUI(hp);
    }

    public void PlayerDead()
    {
        _generator.enabled = false;
    }

    public void GameOver()
    {
        string gameOver = "GameOver";

        _musicAnimator.SetTrigger(gameOver);

        _uiAnimator.SetTrigger(gameOver);

        PlaySound(2);

        AtsumaruManager.Comment.SetContext(gameOver);
    }

    public void EnableMenu()
    {
        _buttonManager.SetParent(_menuButtonParent);
    }
}
