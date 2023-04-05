using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Coincollections : MonoBehaviour
{
    private CoinInst randomizer;
    private AudioSource click;
    private GameObject _gameObject;
    private void Start()
    {
        click = GetComponent<AudioSource>();
        randomizer = gameObject.GetComponent(typeof(CoinInst)) as CoinInst;
        

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
