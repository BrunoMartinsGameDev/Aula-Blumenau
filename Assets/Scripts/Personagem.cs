using Unity.VisualScripting;
using UnityEngine;

// Classe Personagem herda de MonoBehaviour, o que permite que ela seja usada como um script em GameObjects no Unity.
public class Personagem : MonoBehaviour
{
    // Referência ao componente Rigidbody2D, usado para física no Unity.
    private Rigidbody2D rb;

    // Referência ao componente Animator, usado para controlar animações do personagem.
    private Animator animator;

    // Variável booleana para verificar se o personagem está no chão.
    [SerializeField]
    private bool isGrounded;

    // Raio usado para verificar colisão com o chão.
    private float checkRadius = 0.1f;

    // Máscara que identifica o layer representando o chão.
    public LayerMask groundLayer;

    // Velocidade de movimento do personagem.
    public float moveSpeed = 5f;

    // Força do pulo.
    public float jumpForce = 10f;

    // Referência ao objeto que verifica se o personagem está no chão.
    public Transform groundCheck;

    // Método Start é chamado uma vez antes da primeira execução do Update.
    void Start()
    {
        // Inicializa a variável rb com o componente Rigidbody2D do GameObject.
        rb = GetComponent<Rigidbody2D>();

        // Inicializa a variável animator com o componente Animator do GameObject.
        animator = GetComponent<Animator>();
    }

    // Método Update é chamado uma vez por frame.
    void Update()
    {
        // Verifica se o personagem está no chão usando uma sobreposição circular.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Obtém o valor do eixo horizontal (-1 para esquerda, 1 para direita) usando Input.
        float moveX = Input.GetAxisRaw("Horizontal");

        // Cria um vetor de movimento baseado no eixo horizontal e na velocidade de movimento.
        Vector2 movement = new Vector2(moveX, 0) * moveSpeed;

        // Ajusta a velocidade linear no eixo X.
        rb.linearVelocityX = movement.x * Time.deltaTime;

        // Define o parâmetro "speed" no Animator com o valor absoluto da velocidade no eixo X.
        animator.SetFloat("speed", Mathf.Abs(rb.linearVelocityX));

        // Chama o método que trata o pulo.
        HandleJump();

        // Verifica a direção do movimento para ajustar o flip do personagem.
        if (moveX > 0)
        {
            Flip(false); // Movimento para a direita, sem flip.
        }
        else if (moveX < 0)
        {
            Flip(true); // Movimento para a esquerda, aplica o flip.
        }
    }

    // Método que trata a lógica do pulo.
    private void HandleJump()
    {
        // Se o personagem estiver no chão e o botão de pulo for pressionado.
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Adiciona uma força para cima para fazer o personagem pular.
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    // Método para inverter o personagem horizontalmente.
    private void Flip(bool flipToLeft)
    {
        // Obtém a escala local do transform.
        Vector3 localScale = transform.localScale;

        // Define a escala no eixo X para -1 (esquerda) ou 1 (direita), dependendo do valor de flipToLeft.
        localScale.x = flipToLeft ? -1f : 1f;

        // Aplica a nova escala ao transform.
        transform.localScale = localScale;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Quando entrar no trigger acontece algo
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Quando sair do trigger acontece algo
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //Enquanto ficar no trigger acontece algo
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Quando entrar na colisão acontece algo
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        //Enquanto ficar na colisão acontece algo
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        //Quando sair da colisão acontece algo
        if (other.gameObject.CompareTag("Inimigo"))
        {
        }
    }
}
