using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuperGodlyCutsceneClass : MonoBehaviour
{
    [SerializeField] private GameObject _1_1;
    [SerializeField] private GameObject _1_2;

    [SerializeField] private GameObject _2_1;
    [SerializeField] private GameObject _2_2;
    [SerializeField] private GameObject _2_3;

    [SerializeField] private GameObject _3;
    [SerializeField] private GameObject _3_pipe;
    [SerializeField] private GameObject _3_dwarfEye;
    [SerializeField] private GameObject _3_fishEyes;

    [SerializeField] private GameObject _4;
    [SerializeField] private GameObject _4_dwarfEye;

    IEnumerator Start()
    {
        _1_1.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        _1_2.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        _1_2.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _1_2.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        _1_2.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        _1_2.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        _1_1.SetActive(false);
        _1_2.SetActive(false);
        _2_1.SetActive(true);
        _2_2.SetActive(true);
        _2_3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _2_2.SetActive(true);
        yield return new WaitForSeconds(3);
        _2_1.SetActive(false);
        _2_2.SetActive(false);
        _2_3.SetActive(false);

        _3.SetActive(true);
        _3_pipe.SetActive(false);
        _3_dwarfEye.SetActive(true);
        _3_fishEyes.SetActive(true);

        //pipe
        yield return new WaitForSeconds(.15f);
        _3_pipe.SetActive(true);
        yield return new WaitForSeconds(.15f);
        _3_pipe.SetActive(false);
        yield return new WaitForSeconds(.15f);
        _3_pipe.SetActive(true);
        yield return new WaitForSeconds(.15f);
        _3_pipe.SetActive(false);
        yield return new WaitForSeconds(.15f);
        _3_pipe.SetActive(true);
        yield return new WaitForSeconds(.15f);
        _3_pipe.SetActive(false);
        yield return new WaitForSeconds(1f);

        //Close up
        _4.SetActive(true);
        _4_dwarfEye.SetActive(true);
        yield return new WaitForSeconds(2.5f);

        //Open next scene
        Loader.Load(Loader.Scene.MainMenu);
    }
}
