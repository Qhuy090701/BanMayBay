using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    public DynamicJoystick joystick;  // reference to the dynamic joystick component
    public float speed = 4f;  // character movement speed

    private void Start()
    {
        if (joystick == null)
        {
            joystick = FindObjectOfType<DynamicJoystick>();
        }
    }
    private void Update()
    {
        MovewithJoyStick();
    }
    void MovewithJoyStick()
    {
        Vector2 direction = GetDirection();
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public Vector2 GetDirection()
    {
        return joystick.Direction;
    }
}