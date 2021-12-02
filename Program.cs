using Microsoft.AspNetCore.Components.Web;
using AdventOfCode.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AdventOfCode;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// // Add services to the container.
// builder.Services.AddRazorPages();
// builder.Services.AddServerSideBlazor();
// Register all days
builder.Services.AddSingleton<IDay[]>(p => AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => typeof(IDay).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
        .Select(t => (IDay)Activator.CreateInstance(t))
        .ToArray());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseHttpsRedirection();

// app.UseStaticFiles();

// app.UseRouting();

// app.MapBlazorHub();
// app.MapFallbackToPage("/_Host");

// app.Run();
