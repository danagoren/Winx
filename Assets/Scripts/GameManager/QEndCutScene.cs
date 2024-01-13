using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QEndCutScene : MonoBehaviour
{
    private string EndScene;

    private void   OnCollisionEnter2D(Collision 2D , collision) 
    {
        if (OnCollisionenter2D().gameObject.CompareTag("Bloom , stella , flora"))
            SceneManager.LoadScene(EndScene);
    
    }
    
}
