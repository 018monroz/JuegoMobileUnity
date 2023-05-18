using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonInput : MonoBehaviour
{
    float inputValue = 0f;
    public bool isPressed = false;
    [SerializeField] LeftButtonInput leftInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isPressed) inputValue = 1;
        else if(!leftInput.isPressed)
        {
            inputValue = 0;
        }
        else
        {
            inputValue = -1;
        }
        PlayerController.instance.horizontalInput = inputValue;
    }
    public void OnPointerDown()
    {
        isPressed = true;
    }

    public void OnPointerUp()
    {
        isPressed = false;
    }
}
