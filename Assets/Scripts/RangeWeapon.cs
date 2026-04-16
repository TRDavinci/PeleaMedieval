using UnityEngine;

public class RangeWeapon : MonoBehaviour, IAttack, IItemData
{
    public WeaponsData data;
    public GameObject prefabArrow;
    Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void Attack()
    {
        _anim.ResetTrigger("OnRelease");
        _anim.SetTrigger("OnDraw");
    }
    public void LaunchProjectile()
    {
        
        Debug.Log("¡La flecha real sale volando!");
    }
    public float GetDamage() => data.damage;

    public void SetData(WeaponsData newData) => data = newData;
    public WeaponsData GetData() => data;
    public void ActionHold() { _anim.SetBool("IsHolding", true); }
    public void ActionUp() 
    {
        _anim.SetBool("IsHolding", false);
        _anim.ResetTrigger("OnDraw");
        _anim.SetTrigger("OnRelease");

    }

}
