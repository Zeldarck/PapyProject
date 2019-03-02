using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    bool m_isUsable = false;

    [SerializeField]
    string m_scene1;
    [SerializeField]
    string m_scene2;


    string m_destinationScene = "";

    public string Scene1 { get => m_scene1; set => m_scene1 = value; }
    public string Scene2 { get => m_scene2; set => m_scene2 = value; }
    public bool IsUsable { get => m_isUsable; set => m_isUsable = value; }


    private void Start()
    {
        IsUsable = PortalManager.Instance.AddPortal(this);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (IsUsable)
        {
            m_destinationScene = (SceneManager.GetActiveScene().name == Scene1 ? Scene2 : Scene1);
            SceneManager.LoadScene(m_destinationScene, LoadSceneMode.Additive);
            Reposition();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsUsable)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        }
    }


    private void Reposition()
    {
        Scene scene = SceneManager.GetSceneByName(m_destinationScene);
        if (scene.isLoaded)
        {
            Vector3 offset = Vector3.zero;
            Quaternion offsetRotation = Quaternion.identity;
            GameObject[] roots = scene.GetRootGameObjects();
            Portal[] portals;
            GameObject root = null;
            Portal portal = null;

            for(int i =0; i < roots.Length; ++i)
            {
                if (roots[i].name == "Root")
                {
                    root = roots[i];
                    break;
                }
            }

            portals = root.GetComponentsInChildren<Portal>();

            for (int i =0; i < portals.Length; ++i)
            {
                portal = portals[i].GetComponent<Portal>();
                if((Scene1 == portal.Scene1 && Scene2 == portal.Scene2) || (Scene1 == portal.Scene2 && Scene2 == portal.Scene1))
                {
                    offsetRotation = Quaternion.FromToRotation(portal.transform.forward,transform.forward);

                    break;
                }             
            }

            root.transform.rotation = (root.transform.rotation * offsetRotation);

            offset = transform.position - portal.transform.position;

            root.transform.position += offset;

        }
        else
        {
            Utils.TriggerNextFrame(Reposition);
        }

    }


    private void OnDestroy()
    {
        PortalManager.Instance.RemovePortal(this);
    }

}

