using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 direction;
    [SerializeField]
    private float gravity;
    [SerializeField]
    public float speed;
    [SerializeField]
    private float jumpHeight;
    public Animator _animator;
    private bool jumping;
    public bool isGrabbed;
    public bool climb;
    public Ledge currentLedge;
    public float h , updown;
    [SerializeField]
    public GameObject Model;
    private long _gold;
    private UIManager _ui;
    public bool _nearLadder;
    public Ladder ladder;
    public bool UpPosition;
    private  GameObject _start;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        _ui = FindObjectOfType<UIManager>();
        _start = GameObject.Find("Start");
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController();
        LadderMovement();
        Restart();
    }

  
    public void Restart()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(0);
        }
    }

    public long GetGold()
    {
        return _gold;
    }

    public void CharacterController()
    {
        if (_controller.isGrounded)
        {
            if(climb)
            {
                climb = false;
                _animator.SetBool("Climb", climb);
            }

            

             h = Input.GetAxisRaw("Horizontal");
            if (h < 0 && !isGrabbed)
            {
                Model.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 180f, gameObject.transform.rotation.z);
            }
            else if (h > 0 && !isGrabbed)
            {
                Model.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 0f, gameObject.transform.rotation.z);
            }
            
            direction = new Vector3(0, 0, h) * speed;

            _animator.SetFloat("Speed", Mathf.Abs(h));
            if (jumping)
            {
                jumping = false;
                _animator.SetBool("JumpRun", jumping);
            }


            if (Input.GetKey(KeyCode.Space))
            {

                direction.y += jumpHeight;
                jumping = true;
                _animator.SetBool("JumpRun", jumping);
               

            }

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                _animator.SetTrigger("Roll");
            }
        }
        else
        {
      
            float h = Input.GetAxisRaw("Horizontal");
            if (h < 0 && !isGrabbed)
            {
                Model.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 180f, gameObject.transform.rotation.z);
            }
            else if (h > 0 && !isGrabbed)
            {
                Model.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 0f, gameObject.transform.rotation.z);
            }
           
                direction = new Vector3(0, direction.y, h * speed);
           
          
        }


        if(isGrabbed )
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _ui.GrabLedgeUIOff();
                isGrabbed = false;
                _animator.SetBool("GrabLedge", isGrabbed);
                climb = true;
                _animator.SetBool("Climb", climb);
              
                
            }
        }

       


    }

   

    public void LadderMovement()
    {
        if (_nearLadder)
        {
            updown = Input.GetAxisRaw("Vertical");
            _animator.SetBool("Ladder", _nearLadder);
        }

        else
            updown = 0;





        if (_nearLadder && updown != 0 && !UpPosition)
        {
            gravity = 0;

            Debug.Log(direction.y);

            direction.y += 10.0f * updown * Time.deltaTime;

            _controller.Move(direction * Time.deltaTime);

            _animator.SetBool("Ladder", _nearLadder);
            //_animator.SetFloat("Speed", Mathf.Abs(updown));
            _animator.speed = 1.0f;

        }
      

        else if (_nearLadder && updown == 0 && !UpPosition)
        {
            gravity = 0;
            direction.y = 0;
            _animator.speed = 0.0f;

        }
      

        else if (!_nearLadder && updown == 0 && !UpPosition)
        {
           
            _animator.SetBool("Ladder", _nearLadder);

            _animator.speed = 1.0f;
            direction.y -= gravity * Time.deltaTime;
            _controller.Move(direction * Time.deltaTime);


        }

        if(UpPosition)
        {
            _animator.SetBool("Ladder", _nearLadder);
            _controller.enabled = false;
        }



    }

    public void LadderFinished()
    {

        this.gameObject.transform.position = new Vector3(ladder.gameObject.transform.position.x, ladder.gameObject.transform.position.y + 9.5f, ladder.gameObject.transform.position.z + 2f);
        direction.y = 0;
        UpPosition = false;
        ladder = null;
        gravity = 20;
        _controller.enabled = true;
       

    }
    public void ClimbFinished()
    {
        if (climb)
        {
            climb = false;
            _animator.SetBool("Climb", climb);
        }
        
        this.gameObject.transform.position = new Vector3(currentLedge.gameObject.transform.position.x, currentLedge.gameObject.transform.position.y+2f, currentLedge.gameObject.transform.position.z+2f);
       
        _controller.enabled = true;
    }

    public void GrabLedge()
    {
        _ui.GrabLedgeUIOn();
        _controller.enabled = false;
        isGrabbed = true;
        _animator.SetBool("GrabLedge", isGrabbed);
        _animator.SetBool("JumpRun", false);
        _animator.SetFloat("Speed", 0.0f);
    }

 

    public void AddGold()
    {
        _gold++;
        _ui.UpdateText(_gold);
    }
}
