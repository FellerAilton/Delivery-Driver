using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    Collider2D package;
    SpriteRenderer spriteRenderer;
    [SerializeField] float destroyDelay = 0;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(50, 200, 25, 1);  
    // private Driver driver;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // driver = GetComponent<Driver>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage){
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            package = other;
        }
        
        if (other.tag == "Customer" && hasPackage){
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Destroy(package.gameObject, destroyDelay);
        }

        // if(other.tag == "Gas"){
        //     driver.gasAmount = 1000;
        // }
    }

    void LateUpdate()
    {
        if (hasPackage){
            package.transform.position = transform.position + new Vector3(0,-0.8f,0);
            package.transform.rotation = transform.rotation;
            package.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
    }
}

