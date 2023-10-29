using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightOther : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private bool _hitSomething = false;
    [SerializeField] private float _interactDistance = 4.3f;
    [SerializeField] private Transform rayCube;

    [SerializeField] public LightOther nextLight = null;
    [SerializeField] private LightOther prevLight = null;


    public bool isLighten = false;

    private void Update()
    {
        if (isLighten)
        {
            if (nextLight != null)
            {
                rayCube.gameObject.SetActive(true);
            }
            Ray();
            DrawRay();
            InteractionRay();
        } else if (nextLight != null && rayCube != null)
        {
            rayCube.gameObject.SetActive(false);
        }

        CheckPrev();
    }

    private void Ray()
    {
        _ray = new Ray(transform.position, transform.right);
    }

    private void CheckPrev()
    {
        if(prevLight != null && !prevLight.isLighten)
        {
            isLighten = false;
        }
    }

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _interactDistance))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _interactDistance, Color.blue);
        }

        if (_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _interactDistance, Color.red);
        }
    }

    private void OnMouseDown()
    {
        if (nextLight != null)
            transform.Rotate(0, 0, 45);
    }

    private void InteractionRay()
    {
        _hitSomething = false;
        if (Physics.Raycast(_ray, out _hit, _interactDistance))
        {
            LightOther lightOther = _hit.collider.GetComponent<LightOther>();
            if (lightOther != null)
            {
                if (lightOther.nextLight == null)
                {
                    Debug.Log("Решено");
                    // Открыть дверь (Головоломка решена)
                    lightOther.GetComponent<MeshRenderer>().material.color = Color.green;
                }

                _hitSomething = true;
                if (lightOther != prevLight)
                {
                    nextLight.isLighten = true;
                }
            }
        }
        else
        {
            if (nextLight)
            {
                nextLight.isLighten = false;
            }
        }
        //_interactionPanel.SetActive(_hitSomething);
    }
}
