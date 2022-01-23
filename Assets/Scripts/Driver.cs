using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.001f;
    [SerializeField] float gasSpeed = 1f;

    float steerAmount;
    float moveAmount;
    float gasAmount = 0;

    float damageTaken = 0;
    float damageCoefficient = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump") && gasAmount > 0){
            gasSpeed = 2f;
            gasAmount--;
            Debug.Log("GasAmount: " + gasAmount);
        } else {
            gasSpeed = 1f;
        }
        
        steerAmount = -Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * gasSpeed * damageCoefficient * Time.deltaTime;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);

        if(damageTaken > 3){
            damageTaken = 0;
            damageCoefficient -= 0.2f;
            Debug.Log("You are damaging the car, so we are slowing you down.");

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Gas"){
            gasAmount = 1000;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        damageTaken++;
        Debug.Log("DamageTaken = " + damageTaken);
    }
}
