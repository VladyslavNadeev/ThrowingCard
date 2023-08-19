using System;
using System.Collections;
using Assets.Scripts;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private FruitType _fruitType;
    [SerializeField] private ParticleSystem _splashFX;
    [SerializeField] private ParticleSystem _hitFX;

    private ParticleSystem.MainModule _splashFXMain;
    private ParticleSystem.MainModule _hitFXMain;

    public event Action OnCutGameobject;
    
    public void CutGameObject()
    {
        Plane plane = new Plane(Vector3.right, 0);
        GameObject[] cuttedGameObjects = Slicer.Slice(plane, gameObject);
        transform.position = Vector3.zero;

        cuttedGameObjects[0].GetComponent<Rigidbody>()
            .AddForce(Vector3.left * 2f + Vector3.up * 2f, ForceMode.Impulse);
        cuttedGameObjects[1].GetComponent<Rigidbody>()
            .AddForce(Vector3.right * 2f + Vector3.up * 2f, ForceMode.Impulse);
        
        _splashFX.transform.position = cuttedGameObjects[0].transform.position;
        _splashFX.transform.parent = cuttedGameObjects[0].transform;
        
        _hitFX.transform.position = cuttedGameObjects[0].transform.position;
        _hitFX.transform.parent = cuttedGameObjects[0].transform;
        
        CheckFruitTypeToPlayVFX();

        StartCoroutine(FallCuttedGameobjectRoutine(cuttedGameObjects));
        StartCoroutine(FallParentObstacleRoutine());
        OnCutGameobject?.Invoke();
    }

    private void CheckFruitTypeToPlayVFX()
    {
        switch (_fruitType)
        {
            case FruitType.YellowFruit:
                _splashFXMain = _splashFX.main;
                _splashFXMain.startColor = Color.yellow;

                _hitFXMain = _hitFX.main;
                _hitFXMain.startColor = Color.yellow;

                _splashFX.Play();
                _hitFX.Play();
                break;
            case FruitType.RedFruit:
                _splashFXMain = _splashFX.main;
                _splashFXMain.startColor = Color.red;

                _hitFXMain = _hitFX.main;
                _hitFXMain.startColor = Color.red;

                _splashFX.Play();
                _hitFX.Play();
                break;
            case FruitType.GreenFruit:
                _splashFXMain = _splashFX.main;
                _splashFXMain.startColor = Color.green;

                _hitFXMain = _hitFX.main;
                _hitFXMain.startColor = Color.green;

                _splashFX.Play();
                _hitFX.Play();
                break;
            case FruitType.WhiteFruit:
                _splashFXMain = _splashFX.main;
                _splashFXMain.startColor = Color.white;

                _hitFXMain = _hitFX.main;
                _hitFXMain.startColor = Color.white;

                _splashFX.Play();
                _hitFX.Play();
                break;
        }
    }

    private IEnumerator FallCuttedGameobjectRoutine(GameObject[] cuttedGameObjects)
    {
        yield return new WaitForSeconds(2f);
        foreach (GameObject cuttedGameObject in cuttedGameObjects)
        {
            cuttedGameObject.GetComponent<Collider>().isTrigger = true;
            yield return new WaitForSeconds(0.5f);
            cuttedGameObject.SetActive(false);
        }
    }

    private IEnumerator FallParentObstacleRoutine()
    {
        yield return new WaitForSeconds(5f);
        _obstacle.SetActive(false);
    }
}