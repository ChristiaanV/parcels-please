using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParcelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CartAndCannonTouchLoader();
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Parcel Collision Detected!");
        SoundManager.Instance.RandomSoundEffect(SoundManager.Instance.BounceSFX);
    }

    private void CartAndCannonTouchLoader()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(pos, 0.5f);

        GameObject BarrelObj = null;
        GameObject CartObj = null;
            
        foreach (var obj in hitColliders)
        {
            var Barrel = obj.GetComponent<Barrel>();
            if (Barrel != null) BarrelObj = obj.gameObject;

            var Cart = obj.GetComponent<Cart>();
            if (Cart != null) CartObj = obj.gameObject;

        }

        if (CartObj != null && BarrelObj != null)
        {
            CannonController cannonController = BarrelObj.GetComponentInParent<CannonController>();
            cannonController.LoadProjectile(); 
        }
    }
}
