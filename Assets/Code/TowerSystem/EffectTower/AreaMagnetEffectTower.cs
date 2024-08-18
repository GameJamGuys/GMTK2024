namespace TowerSystem
{
    public class AreaMagnetEffectTower : AreaEffectTower<EffectTowerAreaMagnet>
    {
        protected override void Start()
        {
            base.Start(); 
            EffectTowerArea.Init(); 
            UseEffect();
        }
    }
}