using UnityEngine;

public class WeaponController : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponData _weaponData;
    private WeaponModel _weaponModel;

    void Awake()
    {
        _weaponModel = new(_weaponData);
    }

    public void Use()
    {
        _weaponModel.TryFire();
    }

    void Update()
    {
        _weaponModel.Tick(Time.deltaTime);
    }
}