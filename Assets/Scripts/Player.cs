using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D _rb;
    private float _walkSpeed = 4f;
    private float _inputHorizantal;  // Yatay şekilde kontrol edeceğiz girdiyi
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();  // GameObjenin direkt rigidtboydsine erişiyr
    }

    // Update is called once per frame
    void Update()
    {
        _inputHorizantal = Input.GetAxisRaw("Horizontal"); // burada Yatay şekilde gitmesini istiyorum.
        // GetAxisRaw = Hareketi Klavye gamepadten gelen girdiyi almak için kullanılır
        // GetAxisRaw  -1 0 1 olarak döndürür ( -1 sola 0 sabit 1 sağa hareket etmektir.)
        // GetAxisRaw tam sayı değerleri verir -1 0 1  GetAxsis daha yumuşak dönüler -1 1 arasında verir 

        if (_inputHorizantal != 0)
        {
            _rb.AddForce(new Vector2(_inputHorizantal * _walkSpeed ,0f)); // burada Rigidbody e özellik güç veriyoruz.
            //2 boyutlu o yüzden vector2 inputHorizantal gideceği yönü veriyor hareket hızı veriyoruz.
        }
    }
}
