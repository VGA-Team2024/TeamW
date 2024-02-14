
using UniRx;
using UnityEngine;

namespace CookieClickerProject.Common
{
    // ゲーム内でUIManagerを使用するサンプル
    public class GameExample : MonoBehaviour
    {
        private void Start()
        {
            // UIManagerのインスタンスを取得
            UIManager uiManager = UIManager.Instance;
            
            // UIManagerにパネルを登録
            // ここでは、IUserInterfaceSetActiveを実装したパネルを登録している
            // このパネルは、SetActiveメソッドを持っているため、UIManagerから表示・非表示を切り替えることができる
            IUserInterfaceSetActive panel = new SamplePanel();
            uiManager.RegisterPanel(panel);
            
            // パネルを表示する
            uiManager.SetPanel(true, panel);
        }
    }
}