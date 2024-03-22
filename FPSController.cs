using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    // Start is called before the first frame update

    public int numberOfMushrooms = 0;
    public int numberOfStones = 0;

    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 10f;
    public float gravity = 15f;

    public int Health = 3;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController characterController;
    public Animator animator;

    private UIControllerMushrooms uiControllerMushrooms;

    private UIControllerStones uiControllerStones;

    public GameManager gameManager;

    public int PlayerAttackCount = 0;
    public Healthbar healthBar;

    public NavMeshAgent navPlayer;
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        uiControllerMushrooms = FindObjectOfType<UIControllerMushrooms>();
        uiControllerStones = FindObjectOfType<UIControllerStones>();
        gameManager = FindObjectOfType<GameManager>();
        healthBar = FindObjectOfType<Healthbar>();
        navPlayer = GetComponent<NavMeshAgent>();

        
        TESTING:
        numberOfStones = 14;

        numberOfMushrooms = 15;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        // movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //jumping

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y= movementDirectionY;
        }
        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //rotation

        characterController.Move(moveDirection * Time.deltaTime);

        bool isMoving = (curSpeedX != 0 || curSpeedY != 0);

        animator.SetBool("IsMoving", isMoving);

        if(canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            EndGame();
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            ResetGame();
        }
    }

    public void CollectStones(int point)
    {
       
        numberOfStones += point;
        uiControllerStones.UpdateStoneCount(numberOfStones);
        
    }

    public void CollectMushrooms(int point)
    {
        
        numberOfMushrooms += point;
        uiControllerMushrooms.UpdateMushroomCount(numberOfMushrooms);
        
    }

    public void IncreaseAttackCount()
    {
        PlayerAttackCount++;
        healthBar.SetHealth(healthBar.CurrentValue - 33);

        if(PlayerAttackCount >=3)
        {
            gameManager.RestartGame();
        }
    }

    void EndGame()
    {
            Application.Quit();
            
    }

    void ResetGame()
    {
            gameManager.RestartGame();
            
    }
}
