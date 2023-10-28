using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    //[SerializeField] private GameObject _interactionPanel;
    [SerializeField] private SpriteRenderer _crosshair;
    [SerializeField] private TMP_Text interactText;
    [SerializeField] private float _interactDistance;
    private Ray _ray;
    private RaycastHit _hit;
    private bool _hitSomething = false;
    private int fir = 0, sec = 0, thr = 0, four = 0, fiv = 0;
    private int lenght = 0;

    private void Update()
    {
        Ray();
        DrawRay();
        Interact();
    }

    private void Ray()
    {
        _ray = _fpsCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
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

    private void InteractionRay()
    {
        /*_hitSomething = false;
        if (Physics.Raycast(_ray, out _hit, _interactDistance))
        {
            IInteractable interactable = _hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                _hitSomething = true;
                interactText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        _interactionPanel.SetActive(_hitSomething);*/
    }
    private void Interact()
    {
        if(_hit.transform != null && _hit.transform.gameObject.GetComponent<Bells>())
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if(_hit.transform.gameObject.tag == "bell1" && lenght == 0)
                {
                    fir++;
                    if(fir == 1) 
                    {_hit.transform.gameObject.GetComponent<Bells>().bells1();}
                    if(fir == 2)
                    {bellsend(); }
                    lenght++;
                }
                
                else if(_hit.transform.gameObject.tag == "bell2" && lenght == 1)
                {
                    sec++;
                    if (sec == 1)
                    { _hit.transform.gameObject.GetComponent<Bells>().bells2(); }
                    if (sec == 2)
                    { bellsend(); }
                    lenght++;
                }
                else if (_hit.transform.gameObject.tag == "bell3" && lenght == 2)
                {
                    thr++;
                    if (thr == 1)
                    { _hit.transform.gameObject.GetComponent<Bells>().bells3(); }
                    if (thr == 2)
                    { bellsend(); }
                    lenght++;
                }

                else if (_hit.transform.gameObject.tag == "bell4" && lenght == 3)
                {
                    four++;
                    if (four == 1)
                    { _hit.transform.gameObject.GetComponent<Bells>().bells4(); }
                    if (four == 2)
                    { bellsend(); }
                    lenght++;
                }

                else if (_hit.transform.gameObject.tag == "bell5" && lenght == 4)
                {
                    fiv++;
                    if (fiv == 1)
                    { _hit.transform.gameObject.GetComponent<Bells>().bells5(); }
                    if (fiv == 2)
                    { bellsend(); }
                    lenght++;
                    _hit.transform.gameObject.GetComponent<Bells>().bellsAcess();
                    bellsend();
                }
                
                else { bellsend(); }
            }
        }
    }
    private void bellsend()
    {
        lenght = 0;
        fir = 0; 
        sec = 0; 
        thr = 0; 
        four = 0; 
        fiv = 0;
        _hit.transform.gameObject.GetComponent<Bells>().bellend();
    }
}