using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private RectTransform _currentParent;
    [SerializeField] private InstantSound _clickedSound;
    private PadButton[] _buttons;

    void Awake()
    {
        SetButtons();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var b in _buttons)
            if (b.GetButtonDown())
                break;
    }

    public void PlayClickedSound()
    {
        GameObject obj = Instantiate(_clickedSound, Camera.main.transform.position, Quaternion.identity).gameObject;

        DontDestroyOnLoad(obj);
    }

    public void RemoveParent()
    {
        SetParent(null);
    }

    public void SetParent(RectTransform parent)
    {
        _currentParent = parent;

        SetButtons();
    }

    void SetButtons()
    {
        if (!_currentParent)
        {
            _buttons = new PadButton[0];

            return;
        }

        _buttons = _currentParent.GetComponentsInChildren<PadButton>();
    }
}
