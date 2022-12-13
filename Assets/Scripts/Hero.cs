using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    Rigidbody2D playerRb;
    public Animator playerAnimator;
    BoxCollider2D boxCollider;
    float playerVelo = 3;
    Vector2 playerInput;
    
    //public string[] playerItems = new string[] {"Arma", "Escudo"};
    private List<string> _playerItems = new List<string>();

    [SerializeField] public float dmgDur;

    /*[Header("Variáveis Dash")]
    [SerializeField]private float dashSpeed = 30;
    [SerializeField]private float dashDur;
    [SerializeField]private float dashCD;
    private bool canDash = true;*/

    public Life _life;
    public GameObject _death;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        _life = FindObjectOfType<Life>();
        _death = GameObject.FindWithTag("MorteUI");
        if(_death != null) _death.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_death != null)
        {
            if(_death.activeSelf != true)
                Correr();
        }     
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

    /*IEnumerator Dash()
    {
        playerRb.velocity = new Vector2(playerInput.x*30, playerInput.y*30);
        yield return new WaitForSecondsRealtime(dashDur);
        //playerRb.velocity = new Vector2(playerInput.x*playerVelo, playerInput.y*playerVelo);
    }*/

    public IEnumerator DanoCoroutine()
    {
        playerAnimator.SetBool("isDamaged", true);
        yield return new WaitForSeconds(dmgDur);
        playerAnimator.SetBool("isDamaged", false);
    }

    public void Morrer()
    {
        _death.SetActive(true);
        ResetStatus();
    }

    private void ResetStatus()
    {
        PlayerPrefs.SetInt("vidaQt", 10);
        PlayerPrefs.SetInt("vidaMax", 10);
        PlayerPrefs.SetInt("PlayerDano", 1);
    }
    
}
