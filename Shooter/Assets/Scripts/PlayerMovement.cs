using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick rightJoystick;
    public Joystick leftJoystick;

    private CharacterController characterController;
    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private float turnSpeed = 4f;

    public float fireRate = 2f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform fireAt;
    public float speed;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        var rightJoystickMovement = new Vector3(rightJoystick.Horizontal, 0, rightJoystick.Vertical);
        var leftJoystickMovement = new Vector3(leftJoystick.Horizontal, 0, leftJoystick.Vertical);

        characterController.SimpleMove(leftJoystickMovement * Time.deltaTime * moveSpeed);


        if (rightJoystickMovement.magnitude > 0) 
        {
            Quaternion newDirection = Quaternion.LookRotation(rightJoystickMovement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);

            if (fireCountdown <= 0)
            {
                GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

}
