using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationOperator : MonoBehaviour
{
    public Animator[] WelcomeSetupPage;
    public Animator[] SaveSetupPage;
    public Animator[] UserSetupPage;
    // public Animator transitionToOS;
    // public float transitionToOSTime;

    public float transitionTime = 1f;

    public int currentProcedureNumber;

    void Update()
    {
        // if (Input.GetButtonDown("Jump"))
        // {
        //     currentProcedureNumber += 1;
        //     LoadNextSetupProcedure(currentProcedureNumber);
        // }
    }

    public void LoadNextSetupProcedure(int nextProcedureNumber)
    {
        StartCoroutine(LoadSetupProcedure(nextProcedureNumber));
    }

    IEnumerator LoadSetupProcedure(int procedureNumber)
    {
        if(procedureNumber == 1)
        {
            foreach (var item in WelcomeSetupPage)
            {
                item.SetTrigger("Continue");
            }
        }
        else if(procedureNumber == 2)
        {
            foreach (var item in SaveSetupPage)
            {
                item.SetTrigger("Continue");
            }
        }
        else if (procedureNumber == 3)
        {
            foreach (var item in UserSetupPage)
            {
                item.SetTrigger("Continue");
            }
        }

        yield return new WaitForSeconds(transitionTime);

        if (procedureNumber == 1)
        {
            foreach (var item in SaveSetupPage)
            {
                item.SetTrigger("Start");
            }
        }
        else if (procedureNumber == 2)
        {
            foreach (var item in UserSetupPage)
            {
                item.SetTrigger("Start");
            }
        }
        else if (procedureNumber == 3)
        {
            foreach (var item in UserSetupPage){
                item.SetTrigger("Continue");
            }
            yield return new WaitForSeconds(transitionTime + 0.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
