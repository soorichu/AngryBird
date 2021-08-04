using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    Vector3 dragPosition;
    Vector3 initialPosition;
    public float birdSpeed = 500.0f;
    //    string sceneName = "Level1";
    int enemyCount = 0;
    
    void Start()
    {
        initialPosition = transform.position;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //       if (transform.position.x > Screen.width || transform.position.x<0)
        //       {
        //           SceneManager.LoadScene(sceneName);
        //      }

    }

    public void OnMouseDown()
    {
        rb.gravityScale = 1;
    }

    public void OnMouseUp()
    {
        Vector2 springForce = initialPosition - transform.position;
        sr.color = Color.white;
        sr.color = Color.red;
        rb.AddForce(birdSpeed * springForce);
    }

    public void OnMouseDrag()
    {
        dragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(dragPosition.x, dragPosition.y);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            enemyCount++;
            if (enemyCount >= 2)
            {
                GameManager.singleton.isGameover = true;
                GameManager.singleton.youwinText.SetActive(true);
            }
            
        }

        if(collision.collider.tag == "Ground")
        {
            if (enemyCount < 2)
            {
                GameManager.singleton.isGameover = true;
                GameManager.singleton.gameoverText.SetActive(true);
            }
        }
    }


}
