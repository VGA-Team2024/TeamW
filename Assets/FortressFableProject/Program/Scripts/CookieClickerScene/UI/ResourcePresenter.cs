namespace CookieClickerProject.CookieClickerScene.UI
{
    public class ResourcePresenter
    {
        private readonly Resource resource;
        private readonly ResourceView resourceView;

        public ResourcePresenter(Resource resource, ResourceView resourceView)
        {
            this.resource = resource;
            this.resourceView = resourceView;
            this.resourceView.OnCookieButtonClick += AddCookies; // イベントの購読
        }

        private void AddCookies()
        {
            resource.ProduceResource(1); // ここでは例として1を追加
            UpdateTotalCookies();
        }

        public void UpdateTotalCookies()
        {
            resourceView.UpdateTotalCookies(resource.TotalClicks);
        }
    }
}