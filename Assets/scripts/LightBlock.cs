using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlock : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private bool _hitSomething = false;
    private float _interactDistance = 3f;
    [SerializeField] LightOther nextLight;

    private void Update()
    {
        Ray();
        DrawRay();
        InteractionRay();
    }

    private void Ray()
    {
        _ray = new Ray(transform.position, transform.forward);
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
        transform.Rotate(0, 45, 0);
    }

    private void InteractionRay()
    {

        _hitSomething = false;
        if (Physics.Raycast(_ray, out _hit, _interactDistance))
        {
            LightOther lightOther = _hit.collider.GetComponent<LightOther>();
            if (lightOther != null)
            {
                
                _hitSomething = true;
                //interactText.text = interactable.GetDescription();
                nextLight.isLighten = true;
            }
        } else
        {
            nextLight.isLighten = false;
        }
        //_interactionPanel.SetActive(_hitSomething);
    }
}
