using UnityEngine;
using UnityEngine.SceneManagement;

public class Changer : MonoBehaviour
{
    public Animator animator;
    private int levelLoad;

    public void PlayGame()
    {
        FadeToScenes(1);
    }

    public void FadeToScenes(int ScenesIndex)
    {
        levelLoad = ScenesIndex;
        animator.SetTrigger("FadeOut");
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene(levelLoad);
    }
}
