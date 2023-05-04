namespace Github.NET.Sdk.Model
{

    public sealed class GithubTeam
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public sealed class GithubTeamConnections
    {
        public GithubTeam[] Nodes { get; set; } = new GithubTeam[0];
    }
}
