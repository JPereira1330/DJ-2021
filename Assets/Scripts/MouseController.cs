using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour{

    public GameObject objInvocado;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    void OnMouseDown() {
        GameObject obj;
        obj = Instantiate(objInvocado);
        obj.transform.position = new Vector3(this.transform.position.x,this.transform.position.y+1, this.transform.position.z);
    }

}

/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float bulletVelocity;    
    public GameObject bullet1;
    public Transform Muzzle1;
    public Transform Muzzle2;    

    void Update()
    {
        MouseFollow();

        if (Input.GetButtonDown("Fire1"))
            Fire();        
    }

    void Fire()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
        
        //instanciando bala 1
        GameObject bullet = (GameObject)Instantiate(bullet1, Muzzle1.position + (Vector3)(direction * 0.5f), Muzzle1.rotation);
        //instanciando bala 2
        GameObject bullet2 = (GameObject)Instantiate(bullet1, Muzzle2.position + (Vector3)(direction * 0.5f), Muzzle2.rotation);
        
        //Aplicando velocidade para ambas as balas
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        bullet2.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;

        Destroy(bullet, 2f);
        Destroy(bullet2, 2f);
    }
    
    void MouseFollow() 
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
}

**/