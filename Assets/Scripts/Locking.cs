using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locking : MonoBehaviour
{
    [SerializeField] private GameObject LockImage;
    public Transform lockingPoint;
    // Start is called before the first frame update
    void Start()
    {
        LockImage.SetActive(false);
    }

    public void Show()
    {
        LockImage.SetActive(true);
    }
    public void Hide()
    {
        LockImage.SetActive(false);
    }
}
