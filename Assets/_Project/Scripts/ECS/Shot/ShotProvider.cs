using Assets._Project.Scripts.ECS.Shot;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;

public class ShotProvider : MonoProvider<ShotComponent>
{
    private void Start()
    {
        Invoke(nameof(DisposeEntity), 5f);
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Entity.Dispose();
    }

    private void DisposeEntity()
    {
        Entity.Dispose();
    }
}
