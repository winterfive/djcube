using UnityEngine;

public class InputManager : SetAsSingleton<InputManager>
{
    // Manages all player input

    public delegate void Click();
    public static event Click OnClick;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (OnClick != null)
            {
                OnClick();
            }
        }
    }
}
