using Github.NET.Sdk.Model;

namespace Github.NMSAcion.NET.Sdk.Model
{
    public sealed class IssueTemplateConfiguration
    {
        public string PanelName { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string? PanelDescription { get; set; }
        public string? PullRequestPrefix { get; set; }
        public GithubLabelBase[] PullRequestLabels { get; set; } = new GithubLabelBase[0];
        public GithubLabelBase[] OtherOptionLabels { get; set; }= new GithubLabelBase[0];
        public string FileType { get; set; } = "yml";
    }
}
