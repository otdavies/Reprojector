using UnityEngine;
using UnityEngine.InputSystem;

public class CloseOnEscape : MonoBehaviour
{
    private void Update()
    {
        Cursor.visible = false;
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }
}
