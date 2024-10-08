using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Player : MainCamera
{
    public static Player Instance;

    public Rigidbody2D _rb;
    public float _walkSpeed = 2f;
    private float _inputHorizantal;  // Yatay şekilde kontrol edeceğiz girdiyi
    public GameObject bulletPrefab;  // mermi Prefab
    public Transform firePoint;     // Ateş noktası
    public float fireRate = 0.5f;   // Ateş hızı
    private float nextFireTime = 0f;
    public float bounceFactor = 0.5f; // geri sekme faktörü.
    
    public Enemies _spawnEnemies;
    public float spawnWidth = 8.50f;
    public float spawnInterval = 0.09f;
    


    private void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies",0f,spawnInterval);
        
        // StartCoroutine(SpawnEnemiesCoroutine());
        
        CalculateScreenBoundaries();
        
        _rb = gameObject.GetComponent<Rigidbody2D>();  // GameObjenin direkt rigidtboydsine erişiyr
    }
    
    public void SpawnEnemies()  // Düşman yaratma methodu
    { 
        for (int i = 0; i < Random.Range(0,3); i++)
        {
            float randomX = Random.Range(-spawnWidth / 0.9f, spawnWidth / 0.9f);
            Vector2 pos = new Vector2(randomX, y: 4.15f);
            Instantiate(_spawnEnemies,pos,Quaternion.identity);
        }
        
    }
    
    public void isGameOver()
    {
        if (PlayerScore.Instance.live == 0)
        {
            Debug.Log("GameOver");
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        MoveShip();
        
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        // _inputHorizantal = Input.GetAxisRaw("Horizontal"); // burada Yatay şekilde gitmesini istiyorum.
        // // GetAxisRaw = Hareketi Klavye gamepadten gelen girdiyi almak için kullanılır
        // // GetAxisRaw  -1 0 1 olarak döndürür ( -1 sola 0 sabit 1 sağa hareket etmektir.)
        // // GetAxisRaw tam sayı değerleri verir -1 0 1  GetAxsis daha yumuşak dönüler -1 1 arasında verir 
        //
        
        // if (_inputHorizantal != 0)
        // {
        //     _rb.AddForce(new Vector2(_inputHorizantal * _walkSpeed ,0f)); // burada Rigidbody e özellik güç veriyoruz.
        //     //2 boyutlu o yüzden vector2 inputHorizantal gideceği yönü veriyor hareket hızı veriyoruz.
        // }
        //
        
        
        // if (Input.GetMouseButtonDown(0)) //0 sol tık
        // {
        //     OnMouseDown();
        // }
        // // MouseSolClick Basılı tutunca fire calışacak
        
       
    }

    // IEnumerator SpawnEnemiesCoroutine()
    // {
    //    
    //     while (_spawnEnemy > 0)
    //     {
    //         SpawnEnemies();
    //         _spawnEnemy--;
    //         yield return new WaitForSeconds(spawnInvterval);
    //     }
    //
    // }
   

    private void MoveShip()
    {
        _inputHorizantal = Input.GetAxisRaw("Horizontal");
        if (_inputHorizantal != 0)
        {
            _rb.velocity = new Vector2(_inputHorizantal * _walkSpeed, 0f);
        }

        Vector2 newPos = _rb.position;
        bool bounced = false;
        
        if (newPos.x < minX)
        {
            newPos.x = minX;
            bounced = true;
            // eğer pozisyonum MinXten küçükse onu tanımlıyorum.
        }
        else if (newPos.x > maxX)
        {
            newPos.x = maxX;
            bounced = true;
        }

        if (bounced)
        {
            _rb.velocity = new Vector2(-_rb.velocity.x * bounceFactor, 0f);
        }

        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        // Mathf.Clamp Metodu verilen değeri belitrilen min ile max değer arasında tutar.
        _rb.position = newPos;

    }
    
    private void Fire()
    {
        if (Time.time > nextFireTime)
            // Ateş etmeyi Sınırlar.
        // Time.time oyun başladığından beri geçen süreyi saniye olarak verir.
        // NextFireTime bir sonraki ateş zamanı.
        {
            nextFireTime = Time.time + fireRate;  // burada sıradaki ateşi güncelliyor
           GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            // burada Yaratacağımız prefab yaratacılağı konum ve başlangıc rotasyonunu veridk.
            bullet.tag = "Bullet";
        }
            // Ateşi burada yarattık.
    }
}


