using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Melee : MonoBehaviour
{
    public Animator playerAnimator;
    public AudioSource audioSource;
    public string kickAnimName;
    public string inspectionAnimName;
    Camera mainCamera;
    private float damage = 1f;
    public float distance = 2f;
    public Text ammoText;
    public Text fireModeText;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    public void Kick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAnimator.Play(kickAnimName);
            audioSource.Play();
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Enemy"))
                {
                    if (Random.value < 0.8f)
                    {
                        hit.transform.GetComponent<Enemy>().Hurt(damage);
                    }
                }
            }
            if (hit.transform.tag.Equals("Head"))
            {
                if (Random.value < 0.8f)
                {
                    hit.transform.GetComponent<EnemyHead>().headHurt(damage);
                }
            }
            if (hit.transform.tag.Equals("Limb"))
            {
                if (Random.value < 0.8f)
                {
                    hit.transform.GetComponent<EnemyArmLeg>().limbHurt(damage);
                }
            }
        }
    }
    public void Inspection()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAnimator.Play(inspectionAnimName);
        }
    }
    private void Update()
    {
        Kick();
        Inspection();
        ammoText.text = "";
        fireModeText.text = "";
    }
}
