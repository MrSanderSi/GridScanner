var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.GridScanner_ApiService>("apiservice");

builder.AddProject<Projects.GridScanner_Web>("webfrontend")
	.WithExternalHttpEndpoints()
	.WithReference(apiService);

builder.Build().Run();
