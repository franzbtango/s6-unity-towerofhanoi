using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool ButtonA { get; private set; }
    public bool ButtonS { get; private set; }
    public bool ButtonD { get; private set; }

    public bool ButtonESC { get; private set; }

    void Update()
    {
        ButtonA = Input.GetKeyDown(KeyCode.A);
        ButtonS = Input.GetKeyDown(KeyCode.S);
        ButtonD = Input.GetKeyDown(KeyCode.D);

        ButtonESC = Input.GetKeyDown(KeyCode.Escape);
    }
}
