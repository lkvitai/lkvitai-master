using System.Text.Json;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var pluginsRoot = Path.GetFullPath(
    Path.Combine(builder.Environment.ContentRootPath, builder.Configuration["Plugins:Root"] ?? "src/Plugins")
);
builder.Services.AddSingleton(new PluginCatalog(pluginsRoot));

var app = builder.Build();

app.UseStaticFiles();

var catalog = app.Services.GetRequiredService<PluginCatalog>();
foreach (var p in catalog.Plugins)
{
    var uiPath = Path.Combine(p.PhysicalPath, "ui");
    if (Directory.Exists(uiPath))
    {
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(uiPath),
            RequestPath = $"/plugins/{p.Id}",
            ContentTypeProvider = new FileExtensionContentTypeProvider()
        });
    }
}

app.MapGet("/manifest", (PluginCatalog c) =>
{
    var items = c.Plugins.Select(p => new { id = p.Id, name = p.Name, category = p.Category ?? "Modules", path = $"/plugins/{p.Id}/index.html" });
    return Results.Json(items);
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();

public record PortalPlugin(string Id, string Name, string PhysicalPath, string? Category);

public class PluginCatalog
{
    public IReadOnlyList<PortalPlugin> Plugins { get; }
    public PluginCatalog(string root)
    {
        if (!Directory.Exists(root)) Directory.CreateDirectory(root);
        var list = new List<PortalPlugin>();
        foreach (var dir in Directory.GetDirectories(root))
        {
            var json = Path.Combine(dir, "plugin.json");
            if (!File.Exists(json)) continue;
            using var fs = File.OpenRead(json);
            using var doc = JsonDocument.Parse(fs);
            var id = doc.RootElement.GetProperty("id").GetString()!;
            var name = doc.RootElement.GetProperty("name").GetString()!;
            var category = doc.RootElement.TryGetProperty("category", out var c) ? c.GetString() : null;
            list.Add(new PortalPlugin(id, name, dir, category));
        }
        Plugins = list.OrderBy(x => x.Name).ToList();
    }
}
