namespace ALib;

static class ModInitialize
{
    public static void PreInitialize()
    {

    }
    public static void PostInitialize()
    {
        Handler.InitHandler();
    }
}
