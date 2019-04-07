using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Vector2 targetPosition;
    private Shake shake;
    public float yIncrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public int health = 3;
    public GameObject effect;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

#if (UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE) && !UNITY_EDITOR
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began) {
                if ((touch.position.y >= Screen.height / 2) && transform.position.y < maxHeight)
                {
                    Instantiate(effect, transform.position, Quaternion.identity);
                    targetPosition = new Vector2(transform.position.x, transform.position.y + yIncrement);
                    shake.CamShake();
                }
                else if ((touch.position.y < Screen.height / 2) && transform.position.y > minHeight)
                {
                    Instantiate(effect, transform.position, Quaternion.identity);
                    targetPosition = new Vector2(transform.position.x, transform.position.y - yIncrement);
                    shake.CamShake();
                }
            }

#elif UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Input.GetKeyDown("up") && transform.position.y < maxHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPosition = new Vector2(transform.position.x, transform.position.y + yIncrement);
            shake.CamShake();
        }
        else if (Input.GetKeyDown("down") && transform.position.y > minHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPosition = new Vector2(transform.position.x, transform.position.y - yIncrement);
            shake.CamShake();
        }
#endif

    }
}
