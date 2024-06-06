using DuckGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ALib;

public sealed class Handler : IDrawable, IUpdateable
{
    private Dictionary<object, Func<object, object[], object>> _updaters;
    private Dictionary<object, Func<object, object[], object>> _drawers;

    public static void InitHandler() => new Handler();

    private Handler()
    {
        (typeof(Game).GetField("drawableComponents", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).GetValue(MonoMain.instance) as List<IDrawable>).Add(this);
        (typeof(Game).GetField("updateableComponents", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).GetValue(MonoMain.instance) as List<IUpdateable>).Add(this);

        _updaters = new Dictionary<object, Func<object, object[], object>>();
        _drawers = new Dictionary<object, Func<object, object[], object>>();

        InitMethods();
    }

    private void InitMethods()
    {
        Type[] types = Assembly.GetAssembly(typeof(Handler)).GetTypes();

        foreach (Type type in types)
        {
            UpdatableAttribute update = type.GetCustomAttribute(typeof(UpdatableAttribute)) as UpdatableAttribute;
            DrawableAttribute draw = type.GetCustomAttribute(typeof(DrawableAttribute)) as DrawableAttribute;

            if (update == null && draw == null)
                continue;
            object obj = Activator.CreateInstance(type);
            if (update != null)
            {
                foreach (string method in update.Methods)
                {
                    MethodInfo methodInfo = type.GetMethod(method, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    _updaters.Add(obj, (object obj, object[] args) => methodInfo.Invoke(obj, null));
                }
            }
            if (draw != null)
            {
                foreach(string method in draw.Methods)
                {
                    MethodInfo methodInfo = type.GetMethod(method, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    _drawers.Add(obj, (object obj, object[] args) => methodInfo.Invoke(obj, null));
                }
            }
        }
    }

    public bool Visible => true;

    public int DrawOrder => 1;

    public bool Enabled => true;

    public int UpdateOrder => 1;

    public event EventHandler<EventArgs> VisibleChanged;
    public event EventHandler<EventArgs> DrawOrderChanged;
    public event EventHandler<EventArgs> EnabledChanged;
    public event EventHandler<EventArgs> UpdateOrderChanged;

    public void Draw(GameTime gameTime)
    {
        Graphics.screen.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Microsoft.Xna.Framework.Matrix.Identity);

        foreach (var func in _drawers)
        {
            func.Value.Invoke(func.Key, null);
        }

        Graphics.screen.End();
    }

    public void Update(GameTime gameTime)
    {
        foreach (var func in _updaters)
        {
            func.Value.Invoke(func.Key, null);
        }
    }
}
