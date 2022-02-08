using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadButton : MonoBehaviour
{
    private Button _uiButton;
    [SerializeField] private PadButtons _padButton;

    void Awake()
    {
        _uiButton = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool GetButtonDown()
    {
        switch (_padButton)
        {
            case PadButtons.A:
                return GetButtonDown(KeyCode.JoystickButton0);
            case PadButtons.B:
                return GetButtonDown(KeyCode.JoystickButton1);
            case PadButtons.X:
                return GetButtonDown(KeyCode.JoystickButton2);
            case PadButtons.Y:
                return GetButtonDown(KeyCode.JoystickButton3);
            case PadButtons.LB:
                return GetButtonDown(KeyCode.JoystickButton4);
            case PadButtons.RB:
                return GetButtonDown(KeyCode.JoystickButton5);
            case PadButtons.BACK:
                return GetButtonDown(KeyCode.JoystickButton6);
            case PadButtons.START:
                return GetButtonDown(KeyCode.JoystickButton7);
            case PadButtons.LS:
                return GetButtonDown(KeyCode.JoystickButton8);
            case PadButtons.RS:
                return GetButtonDown(KeyCode.JoystickButton9);
        }

        return false;
    }

    bool GetButtonDown(KeyCode key)
    {
        if (!Input.GetKeyDown(key))
            return false;

        _uiButton.onClick.Invoke();

        return true;
    }
}
