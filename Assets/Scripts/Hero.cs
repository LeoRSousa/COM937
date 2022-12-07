using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnimator;
    BoxCollider2D boxCollider;
    float playerVelo = 3;
    Vector2 playerInput;
    private int vida = 10;
    //public string[] playerItems = new string[] {"Arma", "Escudo"};
    private List<string> _playerItems = new List<string>();

    /*[Header("Variáveis Dash")]
    [SerializeField]private float dashSpeed = 30;
    [SerializeField]private float dashDur;
    [SerializeField]private float dashCD;
    private bool canDash = true;*/

    public Life _life;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        _life = FindObjectOfType<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        Correr();
    }
    
    void Correr(){

        playerRb.velocity = new Vector2(playerInput.x*playerVelo, playerInput.y*playerVelo);

        bool isRunning = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;

        playerAnimator.SetBool("isRunning",isRunning);

        if(isRunning)
            FlipSprite();
    }
    
    void FlipSprite(){
        transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x),1); 
    }

    void OnMove(InputValue inputValue){
        playerInput = inputValue.Get<Vector2>();
    }

    void OnDash(InputValue inputValue)
    {
        print("Can Dash");
        
        //StartCoroutine(Dash());
    }

    /*IEnumerator Dash()
    {
        playerRb.velocity = new Vector2(playerInput.x*30, playerInput.y*30);
        yield return new WaitForSecondsRealtime(dashDur);
        //playerRb.velocity = new Vector2(playerInput.x*playerVelo, playerInput.y*playerVelo);
    }*/

    public void TomaDano(int val)
    {
        vida -= val;
        _life.SetDamage(vida.ToString());
        //print("Vida: "+vida);
    }

    public void AddItem(string item)
    {
        print("ADD ITEM: " + item);
        _playerItems.Add(item);
        //print("Contagem dos items: ");
        foreach (var t in _playerItems)
        {
            print(t);
        }
        //print("\n Último item: " + playerItems[playerItems.Length]);
    }
}
