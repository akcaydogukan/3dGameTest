using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superbcontroller2 : MonoBehaviour
{
    // Zamanın normal hızı
    public float normalTimeScale = 1f;
    // Zamanın yavaş hızı
    public float slowTimeScale = 0.1f;
    // Oyuncunun hareket ettiğini belirleyen eşik değer
    public float movementThreshold = 0.1f;
    // Oyuncunun karakter denetleyicisi
    private CharacterController characterController;

    void Start()
    {
        // Karakter denetleyicisini bul
        characterController = GetComponent<CharacterController>();
        // Zamanı yavaşlat
        Time.timeScale = slowTimeScale;
    }

    void Update()
    {
        // Oyuncunun hareket hızını hesapla
        float movementSpeed = characterController.velocity.magnitude;
        // Hareket hızı eşik değerden büyükse
        if (movementSpeed > movementThreshold)
        {
            // Zamanı normal hıza getir
            Time.timeScale = normalTimeScale;
        }
        else
        {
            // Zamanı yavaşlat
            Time.timeScale = slowTimeScale;
        }
    }
}
