using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float range = 10.0f;
    [SerializeField] private DirectionController directionController = null;
    [SerializeField] private Slider chargeSlider = null;
    [SerializeField] private float rotationSpeed = 20.0f;

    private Rigidbody rigidBody = null;
    private float chargeValue = 0.0f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        chargeValue += Time.deltaTime;
        chargeSlider.value = chargeValue;

        ///////////////////
        
        //Rotate();

        //if (directionController.direction != Vector2.zero) rigidBody.velocity = transform.forward * speed;
        //else rigidBody.velocity = Vector3.zero;

        //////////////////

        //////////////////

        rigidBody.velocity = new Vector3(directionController.direction.x, 0.0f, directionController.direction.y) * speed;

        ///////////////////

        if (directionController.direction == Vector2.zero)
        {
            if (chargeValue >= 1.0f)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        chargeValue = 0.0f;
        Collider[] enemies = Physics.OverlapSphere(transform.position, range);
        if (enemies.Length > 0)
        {
            Enemy closestEnemy = enemies[0].GetComponent<Enemy>();
            foreach (var currentEnemy in enemies)
            {
                if (Vector3.Distance(transform.position, currentEnemy.transform.position) < Vector3.Distance(transform.position, closestEnemy.transform.position))
                {
                    closestEnemy = currentEnemy.GetComponent<Enemy>();
                }
            }

            Destroy(closestEnemy.gameObject);
        }
    }

    private void Rotate()
    {
        if (directionController.direction != Vector2.zero)
        {
            transform.Rotate(transform.up, directionController.rotation * rotationSpeed * Time.deltaTime);
        }
    }
}
