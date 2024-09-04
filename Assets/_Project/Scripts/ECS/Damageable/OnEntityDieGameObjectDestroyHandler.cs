using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Project.Scripts.ECS.Enemy
{
    public sealed class OnEntityDieGameObjectDestroyHandler : EntityProvider
    {
        private void Update()
        {
            if (Entity.IsDisposed())
                Destroy(gameObject);
        }
    }
}
