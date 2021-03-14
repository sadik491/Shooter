using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player") 
        {
            animator.SetTrigger("FadeOut");
            SceneManager.LoadScene(0);
        }

    }

}
