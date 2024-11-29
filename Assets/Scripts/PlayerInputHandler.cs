using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HandleMove();
    }
    public void OnMove(InputValue input)
    {
        direction = input.Get<Vector2>();
    }
    public void OnNavigate(InputValue input){
        // print("movimento: " + input.Get<Vector2>());
    }
    public void OnJump(){
        // print("pulou!!!");
        
                     // objeto     //posicao inicial    //rotacao inicial
        Instantiate(rb.gameObject,transform.position,Quaternion.identity);
    }
    private void HandleMove()
    {
        float speed = 50f;
        direction = direction.normalized;
        direction = new Vector2(direction.x * speed * Time.deltaTime, rb.linearVelocityY);
        rb.linearVelocityX = direction.x;
        print("movimento: " + direction);
    }


}
