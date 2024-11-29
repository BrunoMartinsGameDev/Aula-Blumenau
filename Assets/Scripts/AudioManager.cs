using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sons;
    public static AudioManager instance = null;

    public UnityEngine.Vector2 startTouchPosition { get; private set; }
    public UnityEngine.Vector2 endTouchPosition { get; private set; }

    //roda mesmo com o script desativado, mas somente com o gameobject ativado
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void PlayAudio(AudioClip clip)
    {
        sons.clip = clip;
        sons.Play();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began){
                startTouchPosition = touch.position;
            }
            if (touch.phase == TouchPhase.Ended){
                endTouchPosition = touch.position;
                Vector2 swipeDirection = endTouchPosition - startTouchPosition;
                if (swipeDirection.x > 0){
                    Debug.Log("Arrastou para a direita!");
                }
                else if (swipeDirection.x < 0){
                    Debug.Log("Arrastou para a esquerda!");
                }
                if (swipeDirection.y > 0){
                    Debug.Log("Arrastou para cima!");
                }
                else if (swipeDirection.y < 0){
                    Debug.Log("Arrastou para baixo!");
                }
            }
        }

    }

}
