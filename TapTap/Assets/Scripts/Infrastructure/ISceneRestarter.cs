using System;

namespace Infrastructure
{
    public interface ISceneRestarter 
    {
        void RestartScene(object sender, EventArgs e);
    }
}