using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperbController : MonoBehaviour
{
    // Zamanın normal hızı
    public float normalTimeScale = 1f;
    // Zamanın yavaş hızı
    public float slowTimeScale = 0.1f;
    // Oyuncunun hareket ettiğini belirleyen eşik değer
    public float movementThreshold = 0.1f;
    // Oyuncunun karakter denetleyicisi
    private CharacterController characterController;
    public float moveSpeed = 2f;
    // Yerçekiminin normal değeri
    public float normalGravity = -9.81f;
    // Yerçekiminin yavaş değeri
    public float slowGravity = -0.1f;

    void Start()
    {
        // Karakter denetleyicisini bul
        characterController = GetComponent<CharacterController>();
        // Zamanı yavaşlat
        Time.timeScale = slowTimeScale;
    }

    void Update()
    {
        // Hareket vektörü oluştur
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        // Hareket vektörünü normalleştir
        moveDirection.Normalize();
        // Hareket vektörüne hız değerini ekle
        moveDirection *= moveSpeed;
    
        // Karakteri hareket ettir
        characterController.Move(moveDirection * Time.deltaTime);
    
        // Oyuncunun hareket hızını hesapla
        float movementSpeed = Mathf.Abs(characterController.velocity.x);

        // Hareket hızı eşik değerden büyükse
        // Zamanın hedef hızını belirle
        float targetTimeScale = movementSpeed > movementThreshold ? normalTimeScale : slowTimeScale;
        // Zamanın hızını hedefe doğru yavaşça değiştir
        Time.timeScale = Mathf.Lerp(Time.timeScale, targetTimeScale, Time.deltaTime);
        
        // Eğer zaman yavaş akıyorsa
        if (Time.timeScale == slowTimeScale)
        {
            // Yerçekimini yavaş değere ayarla
            Physics.gravity = new Vector3(0, slowGravity, 0);
        }
        // Eğer zaman normal veya hızlı akıyorsa
        else
        {
            // Yerçekimini normal değere ayarla
            Physics.gravity = new Vector3(0, normalGravity, 0);
        }
    }
}


