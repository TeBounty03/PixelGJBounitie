using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance;
    public int playerID;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal_" + playerID);
    }

    public bool GetJumpInput()
    {
        return Input.GetButtonDown("Jump_" + playerID);
    }
}