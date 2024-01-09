using UnityEngine;

public class JoyStickMove : MonoBehaviour {
  [Header("Joystick")] public DynamicJoystick joystick;
  public float speed = 4f;
  [Header("Limit")] public Transform leftLimit;
  public Transform rightLimit;
  public Transform topLimit;
  public Transform bottomLimit;

  private void Start() {
    if (joystick == null) {
      joystick = FindObjectOfType<DynamicJoystick>();
    }
  }

  private void Update() {
    MovewithJoyStick();
  }

  void MovewithJoyStick() {
    Vector2 direction = GetDirection();
    Vector3 newPosition = transform.position + new Vector3(direction.x, direction.y, 0f) * speed * Time.deltaTime;

    float clampedX = Mathf.Clamp(newPosition.x, leftLimit.position.x, rightLimit.position.x);
    float clampedY = Mathf.Clamp(newPosition.y, bottomLimit.position.y, topLimit.position.y);

    transform.position = new Vector3(clampedX, clampedY, 0f);
  }

  public Vector2 GetDirection() {
    return joystick.Direction;
  }
}