using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    // Oyuncunun ateş ettiğini belirleyen değişken
private bool isShooting = false;
// Oyuncunun ateş ettiğinde zamanın hızlanacağı oran
public float shootingTimeScale = 2f;
// Oyuncunun ateş ettiğinde zamanın hızlanacağı süre
public float shootingTimeDuration = 0.5f;
// Oyuncunun ateş ettiğinden beri geçen süre
private float shootingTimeElapsed = 0f;

// Oyuncunun düşman vurduğunu belirleyen değişken
private bool isHitting = false;
// Oyuncunun düşman vurduğunda zamanın yavaşlayacağı oran
public float hittingTimeScale = 0.05f;
// Oyuncunun düşman vurduğunda zamanın yavaşlayacağı süre
public float hittingTimeDuration = 1f;
// Oyuncunun düşman vurduğundan beri geçen süre
private float hittingTimeElapsed = 0f;

void Update()
{
    // Diğer kodlar...

    // Eğer oyuncu ateş ediyorsa
    if (Input.GetMouseButtonDown(0))
    {
        // Ateş etme durumunu true yap
        isShooting = true;
        // Ateş etme süresini sıfırla
        shootingTimeElapsed = 0f;
    }

    // Eğer oyuncu ateş ediyorsa ve süre dolmadıysa
    if (isShooting && shootingTimeElapsed < shootingTimeDuration)
    {
        // Zamanın hızını ateş etme oranına ayarla
        Time.timeScale = shootingTimeScale;
        // Ateş etme süresini arttır
        shootingTimeElapsed += Time.deltaTime;
    }
    // Eğer oyuncu ateş etmiyorsa veya süre dolduysa
    else
    {
        // Ateş etme durumunu false yap
        isShooting = false;
    }

    // Eğer oyuncu düşman vuruyorsa
    if (Input.GetKeyDown(KeyCode.Space))
    {
        // Vuruş durumunu true yap
        isHitting = true;
        // Vuruş süresini sıfırla
        hittingTimeElapsed = 0f;
    }

    // Eğer oyuncu düşman vuruyorsa ve süre dolmadıysa
    if (isHitting && hittingTimeElapsed < hittingTimeDuration)
    {
        // Zamanın hızını vuruş oranına ayarla
        Time.timeScale = hittingTimeScale;
        // Vuruş süresini arttır
        hittingTimeElapsed += Time.deltaTime;
    }
    // Eğer oyuncu düşman vurmuysa veya süre dolduysa
    else
    {
        // Vuruş durumunu false yap
        isHitting = false;
    }
}
}
