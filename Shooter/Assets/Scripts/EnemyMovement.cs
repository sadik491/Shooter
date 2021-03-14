using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float radius;
    public Transform partToRotate;

    public float fireRate = 2f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float firingSpeed;

    void LateUpdate()
    {
        Vector3 direction = player.position - this.transform.position;

        if (direction.magnitude < radius) 
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = lookRotation.eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (fireCountdown <= 0)
            {
                GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        
    }

}
