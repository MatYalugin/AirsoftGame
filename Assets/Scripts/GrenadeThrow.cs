using UnityEngine;
using UnityEngine.UI;

public class GrenadeThrow : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float throwForce = 30f;
    public float throwAngle = 35f;
    public AudioSource throwSound;
    public int grenadesInt = 3;
    public GameObject grenadeGO;
    public Text grenadesIntText;
    private bool readyToThrow = true;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && grenadesInt != 0 && readyToThrow == true)
        {
            ThrowGrenade();
        }
        if(grenadesInt == 0)
        {
            grenadeGO.SetActive(false);
        }

        grenadesIntText.text = "               " + grenadesInt + "x";
    }

    void ThrowGrenade()
    {
        Invoke("makeReadyToThrow", 3);
        readyToThrow = false;
        GameObject grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        // Вычисляем направление броска под определенным углом вверх
        Vector3 throwDirection = Quaternion.AngleAxis(throwAngle, -transform.right) * transform.forward;

        // Добавляем импульсную силу в заданном направлении
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        throwSound.Play();
        grenadesInt -= 1;
    }
    public void makeReadyToThrow()
    {
        readyToThrow = true;
    }
}
