using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
#if UNITY_EDITOR
    [SerializeField]
    bool m_loadPlayer = true;
#endif  //UNITY_EDITOR

    // Start is called before the first frame update
    void Start()
    {

#if UNITY_EDITOR
        if (m_loadPlayer)
        {
#endif  //UNITY_EDITOR
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
#if UNITY_EDITOR
        }
#endif  //UNITY_EDITOR

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
