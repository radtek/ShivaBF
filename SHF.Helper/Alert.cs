namespace SHF.Helper
{
    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";

        public string AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
        public string Icon { get; set; }
    }

    public static class AlertStyles
    {
        public const string Success = "success";
        public const string Information = "info";
        public const string Warning = "warning";
        public const string Danger = "danger";
    }

    public static class AlertIcons
    {
        public const string Success = "check";
        public const string Information = "info-circle";
        public const string Warning = "warning";
        public const string Danger = "trash-o";
    }
}