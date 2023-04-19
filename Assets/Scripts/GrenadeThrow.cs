using UnityEngine;
using UnityEngine.UI;

public class GrenadeThrow : MonoBehaviour
{
    public Animator playerAnimator;
    public string throwAnim;
    public string inspectionAnim;
    public GameObject grenadePrefab;
    public float throwForce = 30f;
    public float throwAngle = 35f;
    public AudioSource throwSound;
    public int grenadesInt = 1;
    public GameObject grenadeGO;
    public Text grenadesIntText;
    private bool readyToThrow = true;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && grenadesInt != 0 && readyToThrow == true)
        {
            readyToThrow = false;
            playerAnimator.Play(throwAnim);
            Invoke("ThrowGrenade", 0.8f);
        }
        if (Input.GetKeyDown(KeyCode.F) && grenadesInt != 0 && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(throwAnim) == false)
        {
            Inspection();
        }

        grenadesIntText.text = "               " + grenadesInt + "x";
    }

    public void ThrowGrenade()
    { 
        Invoke("makeReadyToThrow", 2.5f);
        GameObject grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        // Вычисляем направление броска под определенным углом вверх
        Vector3 throwDirection = Quaternion.AngleAxis(throwAngle, -transform.right) * transform.forward;

        // Добавляем импульсную силу в заданном направлении
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        throwSound.Play();
        grenadesInt -= 1;
        if (grenadesInt == 0)
        {
            grenadeGO.SetActive(false);
        }
    }

    public void Inspection()
    {
        playerAnimator.Play(inspectionAnim);
    }
    public void makeReadyToThrow()
    {
        readyToThrow = true;
    }
}
