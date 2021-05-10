using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] bool isLocked;

    [Space(20)]
    [SerializeField] private float openSpeed;
    [SerializeField] private float closeSpeed;
    [SerializeField] private float closeDelay;
    [SerializeField] private Vector3 openDirection;

    [Space(20), Header("Sounds")]
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    private AudioSource audioSrc;
    private Vector3 targetPos;
    private float moveSpeed;
    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        targetPos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    public void LockUnlockDoor()
    {
        if (isLocked) isLocked = false;
        else isLocked = true;
    }



    public void Interact()
    {
        StartCoroutine(OpenDoor());
    }

    public IEnumerator OpenDoor()
    {
        if (!isLocked)
        {
            PlayOpenSound();
            moveSpeed = openSpeed;

            var tempPos = transform.position;
            targetPos = new Vector3(transform.position.x + openDirection.x,
                                        transform.position.y + openDirection.y,
                                        transform.position.z + openDirection.z);

            yield return new WaitForSeconds(closeDelay);

            PlayCloseSound();
            targetPos = tempPos;
            moveSpeed = closeSpeed;
        }
    }

    private void PlayCloseSound()
    {
        audioSrc.clip = closeSound;
        audioSrc.Play();
    }

    private void PlayOpenSound()
    {
        audioSrc.clip = openSound;
        audioSrc.Play();
    }

}
