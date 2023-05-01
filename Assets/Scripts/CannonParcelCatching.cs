using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonParcelCatching : MonoBehaviour
{
    private CannonController _cannonController;
    void Start()
    {
        _cannonController = gameObject.GetComponentInParent<CannonController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Parcel") return;
        
        Debug.Log("Cannon Catcher: " + this.transform.parent.transform.parent.name);
        if (_cannonController.GetIsLoaded()) return;

        col.gameObject.SetActive(false);
        StartCoroutine(destroyShortly(col.gameObject));

        _cannonController.LoadProjectile();
    }

    IEnumerator destroyShortly(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
