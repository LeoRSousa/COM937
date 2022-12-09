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
    
    //Vida é o total de HP atual que pode ser aumentada por cura até a vida máxima. Vida max é o valor máximo de vida que pode ser aumentado por itens.
    private int vida = 10;
    private int vidaMax = 10;
    
    //public string[] playerItems = new string[] {"Arma", "Escudo"};
    private List<string> _playerItems = new List<string>();

    [SerializeField] public float dmgDur;

    /*[Header("Variáveis Dash")]
    [SerializeField]private float dashSpeed = 30;
    [SerializeField]private float dashDur;
    [SerializeField]private float dashCD;
    private bool canDash = true;*/

    private Life _life;
    private GameObject _death;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        _life = FindObjectOfType<Life>();
        _death = GameObject.FindWithTag("MorteUI");
        _death.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Correr();
    }
    
    void Correr(){

        playerRb.velocity = new Vector2(playerInput.x*playerVelo, playerInput.y*playerVelo);

        bool isRunning = (Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon) || (Mathf.Abs(playerRb.velocity.y) > Mathf.Epsilon);

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
        _life.SetValue(vida.ToString(), "Life");
        if (vida <= 0) Morte();
        StartCoroutine(DanoCoroutine());
    }

    IEnumerator DanoCoroutine()
    {
        playerAnimator.SetBool("isDamaged", true);
        yield return new WaitForSeconds(dmgDur);
        playerAnimator.SetBool("isDamaged", false);
    }

    public void Morte()
    {
        playerAnimator.SetBool("isDeath", true);
        _death.SetActive(true);
    }

    /// <summary>
    /// Caso a vida já estiver cheia, sai da função. Se não, aumenta a vida e atualiza a UI.
    /// </summary>
    public void Cura()
    {
        if (vida >= vidaMax) return;
        vida++;
        _life.SetValue(vida.ToString(), "Life");
    }

    public void AddLife()
    {
        vidaMax++;
        _life.SetValue(vidaMax.ToString(), "LifeMax");
    }

    public void AddItem(string item)
    {
        print("ADD ITEM: " + item);
        _playerItems.Add(item);
        foreach (var t in _playerItems)
        {
            print(t);
        }
    }
}
