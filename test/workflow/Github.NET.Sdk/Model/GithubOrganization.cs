namespace Github.NET.Sdk.Model
{
    public sealed class GithubOrganization
    {
        public string Id { get; set; } = string.Empty;
        public GithubTeamConnections? Teams { get; set; } 
    }
}
