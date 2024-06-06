using DuckGame;

namespace ALib;

public class ALib : ClientMod
{
    public override Priority priority => base.priority;
    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();
        ModInitialize.PreInitialize();
        
    }
    protected override void OnPostInitialize()
    {
        ModInitialize.PostInitialize();

        base.OnPostInitialize();
    }
}
