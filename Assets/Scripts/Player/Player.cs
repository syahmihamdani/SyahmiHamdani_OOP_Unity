using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public Animator animator;

    public static Player Instance { get; private set; }

    private void Awake(){
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this; 
        DontDestroyOnLoad(gameObject); 
    }

    void Start() {
        playerMovement = GetComponent<PlayerMovement>();

        if(playerMovement == null){
            Debug.LogWarning("Player Movement Not Found");
        }

        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();

        if(animator == null){
 
            Debug.LogWarning("EngineEffect GameObject not found!");
        }
        
    }

    void FixedUpdate() {
        playerMovement.Move();
    }

    void LateUpdate(){
         if (animator != null){
             animator.SetBool("isMoving", playerMovement.IsMoving());
         }
    }
}

