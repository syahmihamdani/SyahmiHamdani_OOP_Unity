using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    Animator animator;

    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    //[SerializeField] bool playerHasWeapon;
    Vector2 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("SceneTransition").GetComponent<Animator>();
        ChangePosition();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(playerHasWeapon){
            float dist = Vector2.Distance(transform.position, newPosition);

            if(dist < 0.5f){
                ChangePosition();
            }
            else{
                transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            }
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        //}

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Player collided with asteroid");
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if(levelManager != null){
                levelManager.LoadScene("Main");
            }   
        }
    }

    void ChangePosition(){
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-5f, 5f);

        newPosition = new Vector2(x, y);
    }

    IEnumerator Delay(){
    yield return new WaitForSeconds(1);
    }


}