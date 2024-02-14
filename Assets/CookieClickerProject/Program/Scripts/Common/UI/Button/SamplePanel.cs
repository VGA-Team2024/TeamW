using UniRx;

namespace CookieClickerProject.Common
{
    public class SamplePanel : IUserInterfaceSetActive
    {
        public ReactiveProperty<bool> IsVisible { get; }

        public SamplePanel()
        {
            IsVisible = new ReactiveProperty<bool>(false);
        }

        public void SetActive(bool isActive)
        {
            IsVisible.Value = isActive;
        }
    }
}