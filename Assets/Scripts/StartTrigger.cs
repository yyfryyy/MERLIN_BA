using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StartTrigger : MonoBehaviour
{
    public GameObject startIcon;
    Vector3 startPosition;
    Vector3 startRotation;

    public Transform startIconTargetPosition;

    public Transform mainMenuTargetPosition;

    [HideInInspector]
    public bool stationStarted = false;

    public List<TextMeshPro> meshPros;
    TextMeshPro aufgabentext;

    public MeshRenderer pulseObject;

    public GameObject MaskReveal;

    public GameObject UI;

    public List<GameObject> UI_BG;

    public GameObject checklist;

    public List<GameObject> themenButtons;

    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = startIcon.transform.localPosition;
        startRotation = startIcon.transform.localEulerAngles;
        aufgabentext = meshPros[3];
        Debug.Log(startPosition);
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && !stationStarted)
        {
            Debug.Log("User entered Play Area");
            startIcon.transform.DOMove(startIconTargetPosition.position, 2f);
            startIcon.transform.DORotate(startIconTargetPosition.rotation.eulerAngles, 2f);
            for (int i = 0; i < meshPros.Count; i++)
            {
                meshPros[i].DOFade(1f, 4f).SetDelay(0.3f*i);
            }

            foreach (GameObject bg in UI_BG)
            {
                bg.transform.DOScaleY(1, 2f);
            }
            
            /*foreach (TextMeshPro text in meshPros)
            {
                text.DOFade(1f, 2f);
            }
            */
            //pulseObject.material.DOFloat(0f, "_PulseAlpha", 2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera" && !stationStarted)
        {
            Debug.Log("User left Play Area");
            startIcon.transform.DOLocalMove(startPosition, 2f);
            startIcon.transform.DOLocalRotate(startRotation, 2f);

            /*for (int i = 0; i < meshPros.Count; i++)
            {
                meshPros[i].DOFade(1f, 4f).SetDelay(0.3f * i);
            }
            */
            foreach (GameObject bg in UI_BG)
            {
                bg.transform.DOScaleY(0, 2f);
            }

            
            foreach (TextMeshPro text in meshPros)
            {
                text.DOFade(0f, 2f);
            }
            
        }
    }


    public void StartStation()
    {
        stationStarted = true;

        // Unparent Menu and move to target Position
        UI.transform.SetParent(gameObject.transform);
        UI.transform.DOMove(mainMenuTargetPosition.position, 2f);
        UI.transform.DORotate(mainMenuTargetPosition.rotation.eulerAngles, 2f).OnComplete(()=> {
            UI.transform.SetParent(mainMenuTargetPosition);
            // Show Station Beenden Button
            UI.transform.Find("Station_Beenden_Button").gameObject.SetActive(true);
        });

        // Vergrößere Main Body UI
        UI_BG[0].transform.DOScaleY(2f, 2f);
        // Ändere Aufgabentext
        aufgabentext.text = "Wähle einen der erschienen Buttons aus, um mehr über den Themenbereich zu erfahren";
        // Show Checklist
        checklist.transform.DOScaleY(1f, 2f);

        // Hide StartIcon on Stationstart
        Sequence hideStartIconSequence = DOTween.Sequence();
        hideStartIconSequence.Append(startIcon.transform.DOLocalMove(startPosition, 2f));
        hideStartIconSequence.Join(startIcon.transform.DOLocalRotate(startRotation, 2f));
        hideStartIconSequence.Join(startIcon.transform.DOScale(0, 2f)).OnComplete(()=> {
            startIcon.SetActive(false);
            });
        // Hide pulse on Stationstart
        hideStartIconSequence.Join(pulseObject.material.DOFloat(0f, "_PulseAlpha", 2f));

        // Cut Wall (Play Animation)
        MaskReveal.GetComponent<Animator>().SetTrigger("Reveal");
        //revealAudio.Play();

        // Show ThemenButtons
        foreach (GameObject button in themenButtons)
        {
            button.SetActive(true);
            button.GetComponent<AppearDissappear>().Show(-.25f,2f,4f);
            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(startIconTargetPosition.position, .25f);
    }




}
