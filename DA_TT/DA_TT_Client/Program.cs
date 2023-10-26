using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<CookiePolicyOptions>(option =>
{
	option.CheckConsentNeeded = context => true; // Bắt buộc người dùng đồng ý trước khi sử dụng cookie
	option.MinimumSameSitePolicy = SameSiteMode.None; // Chỉ định chế độ SameSite cho cookie
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseCookiePolicy(new CookiePolicyOptions
{
	HttpOnly = HttpOnlyPolicy.Always,
	Secure = CookieSecurePolicy.SameAsRequest, // Sử dụng "SameAsRequest" nếu bạn đang sử dụng HTTPS
	MinimumSameSitePolicy = SameSiteMode.Strict,
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
	name: "AdminHome",
	areaName: "Admin",
	pattern: "Admin/{controller=AdminHome}/{action=Index}/{id?}"
	);
	endpoints.MapAreaControllerRoute(
	name: "CustomerHome",
	areaName: "Customer",
	pattern: "Customer/{controller=CustomerHome}/{action=Index}/{id?}"
	);
	endpoints.MapAreaControllerRoute(
	name: "ShipperHome",
	areaName: "Shipper",
	pattern: "Shipper/{controller=ShipperHome}/{action=Index}/{id?}"
    );
    endpoints.MapAreaControllerRoute(
    name: "EmployeeHome",
    areaName: "Employee",
    pattern: "Employee/{controller=EmployeeHome}/{action=Index}/{id?}"
    );

    app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
		//pattern: "{controller=Product}/{action=ShowAllProductsHome}/{id?}");
});

app.Run();
