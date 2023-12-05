using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    private void LateUpdate()
    {
        Debug.Log("Lateupdate");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    private void OnDisable()
    {
        Debug.Log("Ondisable");
    }

    private void OnDestory()
    {
        Debug.Log("Ondestory");
    }
}
