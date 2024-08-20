using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float padding = 1f; // kenarlardan ne kadar uzak duracağı.
    public float minX, minY;
    public float maxX, maxY;


    public void CalculateScreenBoundaries()
    {
        Camera mainCamera = Camera.main; // Hiyerarşideki kamera
        Vector2 screenBound = 
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        // Ana kameradan Genişlik yükseklik derinlik alıyor onları Dünya eksenine çeviriyor.

        minX -= screenBound.x + padding;  // Oyun alanının sol sınırı en küçük x
        maxX = screenBound.x - padding; // oyun alanının sağ sınırı en büyük x
        minY -= screenBound.y + padding; // oyun alanın en alt sınırı en küçük y
        maxY = screenBound.y - padding; // oyun alanın en üst sınırı en büyük y
    }

    
}
