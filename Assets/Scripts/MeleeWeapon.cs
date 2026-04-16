using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IAttack, IItemData
{
    Animator _anim;
    public WeaponsData data;
    private void Awake()
    {
     _anim=GetComponent<Animator>();       
    }
    public void Attack()
    {
        _anim.SetTrigger("OnAttack");
    }

    public float GetDamage() => data.damage;

    public void SetData(WeaponsData newData) => data = newData;
    public WeaponsData GetData() => data;
    public void ActionHold() { _anim.SetBool("IsHolding", true); }      
    public void ActionUp() { _anim.SetBool("IsHolding", false); }
    
        
    
}
