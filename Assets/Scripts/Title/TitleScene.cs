using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScene : SceneBehaviour
{

    [Serializable]
    public class HowToPlayData
    {
        [SerializeField] private string _heading;
        [Multiline] [SerializeField] private string _message;
        [SerializeField] private Sprite _sprite;

        public string Heading
        {
            get
            {
                return _heading;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
        }

        public Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }
    }

    [Serializable]
    public class HowToPlayUI
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _headingText, _messageText;

        public void SetUI(int index, int count, HowToPlayData data)
        {
            index++;

            _image.sprite = data.Sprite;

            _headingText.text = string.Format("{0}/{1} {2}", index, count, data.Heading);

            _messageText.text = data.Message;
        }
    }

    private int _howToPlayIndex;
    [SerializeField] private HowToPlayData[] _howToPlayDatas;
    [SerializeField] private HowToPlayUI _howToPlayUI;

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

    public void HowToPlayInitialize()
    {
        _howToPlayIndex = 0;

        SetHowToPlayUI();
    }

    public void HowToPlayBack()
    {
        _howToPlayIndex--;

        if (_howToPlayIndex < 0)
            _howToPlayIndex = _howToPlayDatas.Length - 1;

        SetHowToPlayUI();
    }

    public void HowToPlayNext()
    {
        _howToPlayIndex++;

        if (_howToPlayIndex >= _howToPlayDatas.Length)
            _howToPlayIndex = 0;

        SetHowToPlayUI();
    }

    void SetHowToPlayUI()
    {
        _howToPlayUI.SetUI(_howToPlayIndex, _howToPlayDatas.Length, _howToPlayDatas[_howToPlayIndex]);
    }
}
