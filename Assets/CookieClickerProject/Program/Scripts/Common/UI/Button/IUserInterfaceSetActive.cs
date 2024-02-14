using UniRx;
namespace CookieClickerProject.Common
{
    public interface IUserInterfaceSetActive
    {
        //UIの表示状態を管理するReactiveProperty
        ReactiveProperty<bool> IsVisible { get; }
        void SetActive(bool isActive);
    }
}