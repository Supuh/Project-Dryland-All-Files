using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{

    private bool gathering = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check for Dialogue Triggers
        if (other.CompareTag("DialogueLocation"))
        {
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (!gathering)
        {
            // Check for Resources
            if (other.CompareTag("Stone"))
            {
                StartCoroutine(Gather("stone", 2f));
            }
            else if (other.CompareTag("Steel"))
            {
                StartCoroutine(Gather("steel", 2f));
            }
            else if (other.CompareTag("Fuel"))
            {
                StartCoroutine(Gather("fuel", 10f));
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
        gathering = false;
    }

    IEnumerator Gather(string source, float time)
    {
        gathering = true;

        // Code to execute after the delay
        if (source.Equals("stone"))
        {
            FindObjectOfType<ResourceManager>().ResourceGather("stone", 5);
        }
        else if (source.Equals("steel"))
        {
            FindObjectOfType<ResourceManager>().ResourceGather("steel", 5);
        }
        else if (source.Equals("fuel"))
        {
            FindObjectOfType<ResourceManager>().ResourceGather("fuel", 1);
        }

        yield return new WaitForSeconds(time);

        gathering = false;

    }

}
