using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coincollections : MonoBehaviour
{
    private AudioSource click;
    private void Start()
    {
        click = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            click.Play();
            StartCoroutine(Spawn(other.gameObject));
        }
    }

    IEnumerator Spawn(GameObject gameObject)
    {
        //3 saniye sonra aktif state donecek
        yield return new WaitForSeconds(3);
        gameObject.SetActive(true);

        
    }
}
