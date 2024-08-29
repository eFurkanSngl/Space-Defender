using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 7f;   // gitme hızı
    // Update is called once per frame
    void Update()
    { 
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        // yukarı Doğru ateş edecek hız ve zaman hesaplması ile

        if (!GetComponent<Renderer>().isVisible) // YANİ Renderır Görünür değilse Map dışı işe
        {
            Destroy(gameObject);
            // Renderer artık gözükmüyorsa Yok et.
        }
        
    }
}
