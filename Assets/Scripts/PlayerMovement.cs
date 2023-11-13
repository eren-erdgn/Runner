using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private float switchSpeed;
    private bool _tapToStart = false;
    private int[] _roadSections;
    private int _roadIndex = 1;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _roadSections = new int[3];
        _roadSections[0] = -2;
        _roadSections[1] = 0;
        _roadSections[2] = 2;
    }
    // Start is called before the first frame update
    private void Start()
    {
        _roadIndex = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_tapToStart == false) return;
        transform.Translate(new Vector3(0, 0, 1f) * runSpeed * Time.deltaTime);
        
        
    }
    public void SetRunSpeed(float speed)
    {
        runSpeed = speed;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("ENTER PRESSED");
            _animator.SetBool("RunStart", true);
            _tapToStart=true;
        }
        if(Input.GetKeyDown (KeyCode.A))
        {
            if (_roadIndex == 0) return;
            _roadIndex -= 1;
            _animator.SetBool("RunLeft", true);
            _animator.SetBool("RunRight", false);
            

            transform.DOMoveX(_roadSections[_roadIndex], switchSpeed)
                .OnComplete(() =>
                {
                    _animator.SetBool("RunLeft", false);
                });
        }
        if(Input.GetKeyDown (KeyCode.D))
        {
            if (_roadIndex == 2) return;
            _roadIndex += 1;
            _animator.SetBool("RunLeft", false);
            _animator.SetBool("RunRight", true);
            transform.DOMoveX(_roadSections[_roadIndex], switchSpeed)
                .OnComplete(() =>
                {
                    _animator.SetBool("RunRight", false);
                });
        }

    }
}
